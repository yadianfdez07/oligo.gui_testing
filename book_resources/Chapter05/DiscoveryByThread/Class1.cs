using System;
using System.Reflection;
using System.Threading;

namespace DiscoveryByThread
{
	
	class Class1
	{
		

		private static Assembly asm;

		[STAThread]
		static void Main(string[] args)
		{
			string programName = @"C:\GUISourceCode\Chapter04\GUITestLibrary\bin\Debug\GUITestLibrary.dll";
			if (args.Length > 0)
			{
				programName = args[0];
			}

			asm = Assembly.LoadFrom(programName);

			Thread TypeDiscThread = new Thread(new ThreadStart(DiscoverAllTypes));
			TypeDiscThread.Start();

			//Hold the screen
			Console.ReadLine();
		}

		private static void DiscoverAllTypes()
		{
			Console.WriteLine(asm.FullName + " has the following types:");
			foreach (Type type in asm.GetTypes())
			{
				Console.WriteLine(type.Name + " has the following members:");
				foreach (MemberInfo mi in type.GetMembers())
				{
					Console.WriteLine("    " + mi.Name);
				}
			}
		}
	}
}
