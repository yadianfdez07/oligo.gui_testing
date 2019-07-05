namespace oligo.domain.infrastructure
{
    public class ApiUtility
    {
        public const string CSHP_MARSHAL_EXP_1 = "[MarshalAs(UnmanagedType.ByValTStr,SizeConst =<<REPLACEABLE>> )]\n   ";
        public const string CSHP_MARSHAL_EXP_2 = "[MarshalAs(UnmanagedType.ByValArray,SizeConst =<<REPLACEABLE>> ]\n   ";
        public const string CSHP_MARSHAL_EXP_3 = "[DllImport(<<REPLACEABLE>>)]\n";
        public const string CSHP_MARSHAL_EXP_4 = " static extern ";
        public const string CSHP_MARSHAL_EXP_5 = "[MarshalAs(UnmanagedType.Struct)] ref  ";
        public const string CSHP_MARSHAL_EXP_6 = "[StructLayout(LayoutKind.Sequential)]\n";
        public const string CSHP_SCOPE = "CSHARP_SCOPE";
        public const string CSHP_CONST_LEADING = "const ";
        public const string CSHP_HEX_EXP = "0x";
        public const string CSHP_OR = " | ";
        public const string CSHP_COMMENT = "; //";
        public const string CSHP_END_TYPE = "}\n";

        public const string VB_CONST_LEADING = "Const";
        public const string VB_HEX_EXP = "&H";
        public const string VB_OR = " Or ";
        public const string VB_COMMENT = "'";
        public const string VB_END_TYPE = "End Type";
        public const string VB_AS = " As ";
		
        public const string REPLACEABlE = "<<REPLACEABLE>>";

        public static void RemoveExtraSpace(ref string input)
        {
            while (input.IndexOf("  ")>0)
            {
                input = input.Replace("  ", " ");
            }

            input = input.Trim();
        }

        public static bool GetCSharpStyle(ref string vbStyle)
        {
            string returnType = "";
            if (vbStyle.Trim() == "Long") returnType = "int";
            if (vbStyle.Trim() == "Integer") returnType = "int";
            if (vbStyle.Trim() == "String") returnType = "string";
            if (vbStyle.Trim() == "Double") returnType = "float";
            if (vbStyle.Trim() == "Any") returnType = "int";
            if (vbStyle.Trim() == "Boolean") returnType = "bool";

            if (returnType == "") 
            {
                returnType = vbStyle;
                return false;
            }

            vbStyle = returnType;
            return true;
        }

        public static bool GetCSharpStyle(ref string vbStyle, bool forFunction)
        {
            GetCSharpStyle(ref vbStyle);
            if (forFunction)
            {
                if (vbStyle.Trim() == "string")
                {
                    vbStyle = "StringBuilder";
                }
            }
            return true;
        }
    }
}