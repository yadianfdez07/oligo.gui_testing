using System.Collections;
using System.IO;

namespace oligo.domain.infrastructure
{
    public interface IConstantTextViewer: IApiTextViewer
    {
        
    }

    public class ConstantTextViewer : ApiTextViewerBase, IConstantTextViewer
    {
        public override void ParseText()
        {
            StreamReader sr = new StreamReader(FileName);
            string input = sr.ReadLine();

            while (null != input)
            {
                // Ignore comments
                // ReSharper disable once PossibleNullReferenceException
                while (input.Trim().StartsWith("'"))
                    input = sr.ReadLine();

                ApiUtility.RemoveExtraSpace(ref input);

                if (input.StartsWith("Const "))
                {
                    string cKey = input.Split(' ')[1];

                    string cshpType = "int";
                    
                    if (input.IndexOf(" As ") > 0)
                    {
                        input = input.Replace(" As ", " : ");
                        cshpType = input.Split(':')[1].Trim();
                        cshpType = cshpType.Substring(0, cshpType.IndexOf(" "));
                        input = input.Replace(": " + cshpType, "");
                        ApiUtility.GetCSharpStyle(ref cshpType);
                    }


                    string cSharpCode = ApiUtility.CSHP_SCOPE + " " + input + ";\n";
                   
                    cSharpCode = cSharpCode.Replace(ApiUtility.VB_CONST_LEADING, ApiUtility.CSHP_CONST_LEADING + cshpType);
                    cSharpCode = cSharpCode.Replace(ApiUtility.VB_HEX_EXP, ApiUtility.CSHP_HEX_EXP);
                    cSharpCode = cSharpCode.Replace(ApiUtility.VB_OR, ApiUtility.CSHP_OR);
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