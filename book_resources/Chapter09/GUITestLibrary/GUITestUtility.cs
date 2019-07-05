using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Collections;
using System.Reflection;

namespace GUITestLibrary
{
	public class GUITestUtility
	{
		public GUITestUtility()
		{
			
		}

		public static void DeSerializeInfo(string FileName, ref object obj)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(obj.GetType());
				TextReader reader1 = new StreamReader(FileName);
				obj = serializer.Deserialize(reader1);
				reader1.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		public static void SerilizeInfo(string FileName, object obj)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(obj.GetType());
				StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
				serializer.Serialize(sw, obj);
				sw.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static string GetAGUIAction(string xmlFile, string actionOnType)
		{
			XmlReader reader = new XmlTextReader(File.OpenRead(xmlFile));
			XmlDocument doc = new XmlDocument();
			doc.Load(reader);
			reader.Close();
			XmlNodeList rootList = doc.GetElementsByTagName("GUIActions");
			XmlNode rootNode = rootList[0];

			XmlNodeList actionList = rootNode.ChildNodes;
			foreach (XmlNode action in actionList)
			{
				if (action.Name == actionOnType)
				{
					return action.InnerText;
				}
			}			   
			return "";
		}

		private static BindingFlags allFlags = BindingFlags.Public | BindingFlags.NonPublic |
			BindingFlags.Static | BindingFlags.Instance;

		public static object StartAUT(string applicationPath, string typeName)	
		{
			try
			{
				Assembly asm = Assembly.LoadFrom(applicationPath);
				Type typeUT = asm.GetType(typeName);
				object obj = Activator.CreateInstance(typeUT);
				MethodInfo mi = typeUT.GetMethod("Show", allFlags);
				mi.Invoke(obj, null);
				return obj;
			}
			catch{}
			return null;
		}

		
		public static object VerifyField(object typeUnderTest, string fieldName)
		{
			Type t = typeUnderTest.GetType();
			FieldInfo fiUT = t.GetField(fieldName, allFlags);
			return fiUT.GetValue(typeUnderTest);
		}

		public static object VerifyProperty(object typeUnderTest, string propertyName)
		{
			Type t = typeUnderTest.GetType();
			PropertyInfo piUT = t.GetProperty(propertyName, allFlags);
			return piUT.GetValue(typeUnderTest, new object[0]);
		}

		
	
		[Serializable]public struct GUIInfo
		{

			public int GUIHandle;
			public string GUIText;
			public string GUIClassName;
			public string GUIParentText;
			public string GUIControlName;
			public string GUIControlType;
			public string GUIMemberType;
		}

		[Serializable]public class GUIInfoSerializable
		{
			public string AUTPath;
			public string AUTStartupForm;

			[XmlArray("GUIInfoSerializable")]
			[XmlArrayItem("GUIInfo",typeof(GUIInfo))]
			public ArrayList GUIList = new ArrayList();
		}


	}
}
