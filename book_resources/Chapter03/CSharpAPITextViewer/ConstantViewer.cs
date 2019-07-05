using System;
using System.Collections;
using System.IO;

namespace CSharpAPITextViewer
{
	
	public class ConstantViewer : APITextViewer
	{
		public ConstantViewer(string m_Filename) : base(m_Filename)
		{
		}
		
		public override void ParseText()
		{
			StreamReader sr = new StreamReader(filename);
			string input =sr.ReadLine();
			
			while (null != input)
			{
				// Ignore comments
				while (input.Trim().StartsWith("'"))
					input=sr.ReadLine();
				
				APIUtility.GetRidExtraSpaces(ref input);
				
				if (input.StartsWith("Const "))
				{
					string cKey = input.Split(' ')[1];

					string cshpType = "int";
					if (input.IndexOf(" As ")>0)
					{
						input = input.Replace(" As ", " : ");
						cshpType = input.Split(':')[1].Trim();
						cshpType = cshpType.Substring(0, cshpType.IndexOf(" "));
						input = input.Replace(": " + cshpType, "");
						APIUtility.GetCSharpStyle(ref cshpType);
					}

					
					string cSharpCode = APIUtility.CSHP_SCOPE + " " + input + ";\n";
					cSharpCode = cSharpCode.Replace(APIUtility.VB_CONST_LEADING, APIUtility.CSHP_CONST_LEADING + cshpType);
					cSharpCode = cSharpCode.Replace(APIUtility.VB_HEX_EXP, APIUtility.CSHP_HEX_EXP);
					cSharpCode = cSharpCode.Replace(APIUtility.VB_OR, APIUtility.CSHP_OR);
					cSharpCode = cSharpCode.Replace("&'", "; //");
					cSharpCode = cSharpCode.Replace("'", "; //");
					cSharpCode = cSharpCode.Replace("&;", ";");
					
					AddCSharpCode(cKey, cSharpCode);
					cSharpCode = "";
				}
				input = sr.ReadLine();
			}
			sr.Close();
		}
	}
}