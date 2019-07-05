using System;
using System.Collections;
using System.IO;

namespace CSharpAPITextViewer
{

	public class StructViewer : APITextViewer
	{
		public StructViewer(string m_filename) : base(m_filename)
		{
		}

		public override void ParseText()
		{
			bool structStart = false;
			bool structEnd = false;

			string cSharpCode = "";
			string structKey = "";
			StreamReader sr = new StreamReader(filename);
			string input = sr.ReadLine();
			

			while (null != input)
			{
				while (input.Trim().StartsWith("'"))
					input = sr.ReadLine();

				APIUtility.GetRidExtraSpaces(ref input);
				
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
					if (input.Trim().StartsWith(APIUtility.VB_END_TYPE))
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

		private string DefineCShpStructBody(string input)
		{
			if (input == "")
			{
				return "";
			}
			input = input.Replace(" as ", APIUtility.VB_AS);
			input = input.Replace(APIUtility.VB_AS, " ^ ");
			string[] pieces = input.Split('^');

			string cSharpStruct = "";
			if (input.IndexOf("*") > 0)
			{
				cSharpStruct=APIUtility.CSHP_MARSHAL_EXP_1.Replace(APIUtility.REPLACEABlE, input.Split('*')[1].Trim());
				pieces[1] = pieces[1].Replace("* " + input.Split('*')[1].Trim(), "");
			}
			if (pieces[0].IndexOf("(") > 0)
			{
				string[] arrSeps = pieces[0].Split('(');
				pieces[0] = arrSeps[0];
				cSharpStruct=APIUtility.CSHP_MARSHAL_EXP_2.Replace(APIUtility.REPLACEABlE, arrSeps[1]);

			}

			cSharpStruct += APIUtility.CSHP_SCOPE + " ";
			APIUtility.GetCSharpStyle(ref pieces[1]);
			cSharpStruct += pieces[1] + " ";
			cSharpStruct += pieces[0].Trim() + ";\n";
			cSharpStruct = cSharpStruct.Replace(" '", "; //");
			cSharpStruct = cSharpStruct.Replace("'", "; //");
			return "   " + cSharpStruct;
		}

		private string DefineCShpStruct(string input, ref string sKey)
		{
			string[] structInfo = input.Split(' ');
			string cSharpStruct = APIUtility.CSHP_MARSHAL_EXP_6;
			cSharpStruct += APIUtility.CSHP_SCOPE + " struct " + structInfo[1] + "\n{\n";
			cSharpStruct= cSharpStruct.Replace("'", "//");
			sKey = structInfo[1];
			return cSharpStruct;
		}
		
		private bool IsStruct(string input)
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
