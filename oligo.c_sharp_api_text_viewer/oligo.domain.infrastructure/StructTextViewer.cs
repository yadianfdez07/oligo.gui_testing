using System.IO;

namespace oligo.domain.infrastructure
{
    public interface IStructTextViewer: IApiTextViewer
    {
        string DefineCShpStructBody(string input);
        string DefineCShpStruct(string input, ref string sKey);
        bool IsStruct(string input);
    }

    public class StructTextViewer : ApiTextViewerBase, IStructTextViewer
    {
        public override void ParseText()
		{
			bool structStart = false;
			bool structEnd = false;

			string cSharpCode = "";
			string structKey = "";
			StreamReader sr = new StreamReader(FileName);
			string input = sr.ReadLine();
			

			while (null != input)
			{
				while (input.Trim().StartsWith("'"))
					input = sr.ReadLine();

				ApiUtility.RemoveExtraSpace(ref input);
				
				if (IsStruct(input))
				{
					structStart = true;
					structEnd = false;		
					cSharpCode += DefineCShpStruct(input, ref structKey);
					input = sr.ReadLine();
					continue;
				}
				if (structStart)
				{
					if (input.Trim().StartsWith(ApiUtility.VB_END_TYPE))
					{
						structStart = false;
						structEnd = true;

						cSharpCode +="}\n";
						AddCSharpCode(structKey, cSharpCode);
						structKey = "";
						cSharpCode = "";
						input = sr.ReadLine();
						continue;
					}
					else if (!structEnd) 
					{
						cSharpCode += DefineCShpStructBody(input);
						input = sr.ReadLine();
						continue;
					}
				}
				input = sr.ReadLine();
			}
			sr.Close();
		}

        public string DefineCShpStructBody(string input)
		{
			if (input == "")
			{
				return "";
			}
			input = input.Replace(" as ", ApiUtility.VB_AS);
			input = input.Replace(ApiUtility.VB_AS, " ^ ");
			string[] pieces = input.Split('^');

			string cSharpStruct = "";
			if (input.IndexOf("*") > 0)
			{
				cSharpStruct=ApiUtility.CSHP_MARSHAL_EXP_1.Replace(ApiUtility.REPLACEABlE, input.Split('*')[1].Trim());
				pieces[1] = pieces[1].Replace("* " + input.Split('*')[1].Trim(), "");
			}
			if (pieces[0].IndexOf("(") > 0)
			{
				string[] arrSeps = pieces[0].Split('(');
				pieces[0] = arrSeps[0];
				cSharpStruct=ApiUtility.CSHP_MARSHAL_EXP_2.Replace(ApiUtility.REPLACEABlE, arrSeps[1]);

			}

			cSharpStruct += ApiUtility.CSHP_SCOPE + " ";
			ApiUtility.GetCSharpStyle(ref pieces[1]);
			cSharpStruct += pieces[1] + " ";
			cSharpStruct += pieces[0].Trim() + ";\n";
			cSharpStruct = cSharpStruct.Replace(" '", "; //");
			cSharpStruct = cSharpStruct.Replace("'", "; //");
			return "   " + cSharpStruct;
		}

        public string DefineCShpStruct(string input, ref string sKey)
		{
			string[] structInfo = input.Split(' ');
			string cSharpStruct = ApiUtility.CSHP_MARSHAL_EXP_6;
			cSharpStruct += ApiUtility.CSHP_SCOPE + " struct " + structInfo[1] + "\n{\n";
			cSharpStruct= cSharpStruct.Replace("'", "//");
			sKey = structInfo[1];
			return cSharpStruct;
		}

        public bool IsStruct(string input)
		{
			if (input.Trim().StartsWith("Type"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
    }
}