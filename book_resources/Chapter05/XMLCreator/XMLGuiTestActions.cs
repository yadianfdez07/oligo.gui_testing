using System;
using System.Xml;

namespace XMLCreator
{
	
	class XMLGuiTestActions
	{
		[STAThread]
		static void Main(string[] args)
		{
			//create an XmlTextWriter instance
			XmlTextWriter xmlW = new XmlTextWriter("GUITestActionLib.xml", System.Text.Encoding.UTF8);
			
			//Format the XML document
			xmlW.Formatting = Formatting.Indented;
			xmlW.Indentation = 2;

			//Start a root element
			xmlW.WriteStartElement("GUIActions");
			
			//add child elements by calling the helper method
			WriteChildElement(xmlW, "System.Windows.Forms.ListBox", "HandleListBox");
			WriteChildElement(xmlW, "System.Windows.Forms.RichTextBox", "HandleTextBox");
			WriteChildElement(xmlW, "System.Windows.Forms.Button", "HandleCommandButton");
			WriteChildElement(xmlW, "Field", "VerifyField");
			WriteChildElement(xmlW, "Property", "VerifyProperty");
			WriteChildElement(xmlW, "Synchronization", "SynchronizeWindow");

			//close the root element and the XML document
			xmlW.WriteEndElement();
			xmlW.Close();
		}

		
		private static void WriteChildElement(XmlTextWriter xmlW, string GUIType, string GUILibMethod)
		{
			//Write each GUI action as a child element
			xmlW.WriteStartElement(GUIType);
			xmlW.WriteString(GUILibMethod);
			xmlW.WriteEndElement();
		}
	}
}
