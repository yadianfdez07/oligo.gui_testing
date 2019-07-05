using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowClassDiscovery
{
  
	class Win32API
	{
		//Prepare two functions from the user32.dll API
		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		private static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "GetClassName")]
		private static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);

		[STAThread]
		static void Main(string[] args)
		{
			//Initialize a StringBuilder object, not a string
			//value 100 is the maxmum length of a string
			StringBuilder clsName = new StringBuilder(100);
      
			//Call the FindWindow to find the Windows handle
			//of an open Notepad application
			int iHandle = FindWindow(null, "Untitled - Notepad");

			//call the GetClassName custom function 
			int clsHandle = GetClassName(iHandle, clsName, 100);
      
			//Print the class name on the screen
			Console.WriteLine(clsName.ToString());

			//Hold the screen for you to view the result
			//You need to hit enter to terminate this session
			string waitToExit = Console.ReadLine();
		}
	}
}
