using System;
using System.Reflection;

namespace LateBindingGUIAction
{
	
	class Class1
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			string programName = @"C:\GUISourceCode\Chapter04\GUITestLibrary\bin\Debug\GUITestLibrary.dll";
			
			Assembly asm = Assembly.LoadFrom(programName);
			Type type = asm.GetType("GUITestLibrary.GUITestActions");
			object obj = Activator.CreateInstance(type);
			MethodInfo mi = type.GetMethod("HandleCommandButton");
			object[] paramArr = new object[4];
			paramArr[0] = 0;     //initialize a handle integer
			paramArr[1] = "Add"; //GUI window Text
			paramArr[2] = "WindowsForms10.BUTTON.app3"; //GUI class name
			paramArr[3] = "C# API Text Viewer"; //Parent window text

			mi.Invoke(obj, paramArr);

			for (int i = 0; i < paramArr.Length; i++)
			{
				Console.WriteLine(paramArr[i].ToString());
			}
			Console.ReadLine();

		}
	}
}
