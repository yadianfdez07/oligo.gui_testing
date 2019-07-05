using System;
using System.Xml.XPath;

namespace XmlNavigator
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{

			string xmlFile = @"C:\GUISourceCode\Chapter05\XMLCreator\bin\Debug\GUITestActionLib.xml";
			XPathDocument xmlDoc = new XPathDocument(xmlFile);
			XPathNavigator xmlNavy = xmlDoc.CreateNavigator();

			xmlNavy.MoveToRoot();
			NavigateXMLDoc(xmlNavy);

			//hold the screen
			Console.ReadLine();
		}

		//Recursive method
		private static void NavigateXMLDoc(XPathNavigator xmlNavy)
		{
			//Print the value of the current element
			if (xmlNavy.NodeType == XPathNodeType.Text)
				Console.WriteLine(xmlNavy.Value);

			if (xmlNavy.HasChildren)
			{
				xmlNavy.MoveToFirstChild();
				NavigateXMLDoc(xmlNavy);

				while (xmlNavy.MoveToNext())
					NavigateXMLDoc(xmlNavy);

				xmlNavy.MoveToParent();
			}
		}
	}
} 
