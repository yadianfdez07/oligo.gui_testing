using System;
using System.Xml;

namespace XMLExtractor
{
	class Class1
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			string xmlFile = @"C:\GUISourceCode\Chapter05\XMLCreator\bin\Debug\GUITestActionLib.xml";
			XmlTextReader xmlR = new XmlTextReader(xmlFile);

			while (xmlR.Read())
			{
				if (xmlR.Value.Trim().Length > 0)
					Console.WriteLine(xmlR.Value);
			}

			//hold the screen
			Console.ReadLine();

		}
	}
}
