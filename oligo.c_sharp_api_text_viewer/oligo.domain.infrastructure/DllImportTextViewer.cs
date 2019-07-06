using System.Collections;
using System.IO;

namespace oligo.domain.infrastructure
{
    public interface IDllImportTextViewer: IApiTextViewer
    {
        string CompleteDllImportCoding(string dllName, string retType, string funcName, string paramStr);
        string ParseParameters(string input);
        string MakeAParameter(string paramA);
        string GetDllName(string dllName);
        string GetFunctionReturnType(string[] pieces);
    }

    public class DllImportTextViewer: ApiTextViewerBase, IDllImportTextViewer
    {
        public override void ParseText()
		{
			StreamReader sr = new StreamReader(FileName);
			string input =sr.ReadLine();
			
			while (null != input)
			{
				while (input.Trim().StartsWith("'"))
					input=sr.ReadLine();
				
                ApiUtility.RemoveExtraSpace(ref input);
				if (input.StartsWith("Declare "))
				{
					string[] pieces = input.Split(' ');
				
					string returnType = GetFunctionReturnType(pieces);
					string funcName = pieces[2];
					string dllName = GetDllName(pieces[4]);
					string paramStr = ParseParameters(input);
					string cSharpCode = CompleteDllImportCoding(dllName, returnType, funcName, paramStr);
					AddCSharpCode(funcName, cSharpCode);
				}

				input = sr.ReadLine();
			}
			sr.Close();

		}

        public string CompleteDllImportCoding(string dllName, string retType, string funcName, string paramStr)
		{
			string dllCode = ApiUtility.CSHP_MARSHAL_EXP_3.Replace(ApiUtility.REPLACEABlE, dllName);
			dllCode += ApiUtility.CSHP_SCOPE + ApiUtility.CSHP_MARSHAL_EXP_4 + retType + " ";
			dllCode += funcName + paramStr + ";\n";
			return dllCode;
		}

        public string ParseParameters(string input)
		{
			int ArrParamCount = 0;
			string tempInput = input;
			foreach (char chr1 in input.ToCharArray())
			{
				if (chr1 == '(')
					ArrParamCount ++;
			}
			if (ArrParamCount > 1)
			{
				input = input.Replace("()", "[]");
			}

			string paramStr = input.Substring(input.IndexOf("("));
			if (!paramStr.EndsWith(")"))
				paramStr = paramStr.Substring(0, paramStr.IndexOf(")")+1);

			if (paramStr == "()")
				return paramStr;

			paramStr = paramStr.Replace("(", "");
			paramStr = paramStr.Replace(")", "");

			string[] paramArr  = paramStr.Split(',');
			paramStr = "";
			for (int i = 0; i < paramArr.Length; i++)
			{
				if (i == paramArr.Length - 1)
					paramStr += MakeAParameter(paramArr[i]);
				else
					paramStr += MakeAParameter(paramArr[i]) + ", ";
				
			}
			return "(" + paramStr + ")";
		}


        public string MakeAParameter(string paramA)
		{
			paramA = paramA.Trim().Replace(" As ", " ");
			string[] pPieces = paramA.Split(' ');
			int pLen = pPieces.Length;

			if (pPieces[0].Trim() == "ByRef")
			{
                ApiUtility.GetCSharpStyle(ref pPieces[pLen-1], true);
				return "ref " + pPieces[pLen-1] + " " + pPieces[pLen-2];
			}

			if (!ApiUtility.GetCSharpStyle(ref pPieces[pLen-1]))
			{
				pPieces[pLen-1] = ApiUtility.CSHP_MARSHAL_EXP_5 + pPieces[pLen-1];
			}

            ApiUtility.GetCSharpStyle(ref pPieces[pLen-1], true);
			return pPieces[pLen-1] + " " + pPieces[pLen-2];
		}

        public string GetDllName(string dllName)
		{
			if (dllName.ToLower().IndexOf(".dll")>0)
				return dllName;

			dllName = dllName.Replace("\"", "").Trim();
			dllName = "\"" + dllName + ".dll" + "\"";
			return dllName;
		}

        public string GetFunctionReturnType(string[] pieces)
		{
			if (pieces[1].Trim() == "Sub")
			{
				return "void";
			}
			else
			{
                ApiUtility.GetCSharpStyle(ref pieces[pieces.Length-1]);
				return pieces[pieces.Length-1];
			}
		}
    }
}