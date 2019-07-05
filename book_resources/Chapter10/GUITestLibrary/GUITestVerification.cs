using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Xml.Serialization;

namespace AutomatedGUITest
{
	/// <summary>
	/// Summary description for GUITestVerification.
	/// </summary>
	public class GUITestVerification
	{
		private string AUT;
		private string StartForm;
		private string GUIEvent;

		public GUITestVerification()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public GUITestVerification(string _aut, string _startForm, string _guiEvent)
		{
			AUT = _aut;
			StartForm = _startForm;
			GUIEvent = _guiEvent;
		}

		public void FindMembersToVerify(string AUT, GUITestDataCollector guiTDC)
		{
			Assembly asm = Assembly.LoadFrom(AUT);
			Type[] types = asm.GetTypes();

			BindingFlags allFlags = BindingFlags.Public | BindingFlags.NonPublic |
				BindingFlags.Static | BindingFlags.Instance;

			foreach(Type typ in types)
			{
				if (typ.Namespace + "." + typ.Name ==  StartForm)
				{
					guiTDC.chckLstMembersToVerify.Items.Add(typ.Namespace + "." + typ.Name);
					foreach (FieldInfo fld in typ.GetFields(allFlags))
					{
						guiTDC.chckLstMembersToVerify.Items.Add("\t" + fld.Name);
					}
					
					foreach (PropertyInfo prpty in typ.GetProperties(allFlags))
					{
						guiTDC.chckLstMembersToVerify.Items.Add("\t" + prpty.Name);
					
					}
				}
			}
		}

				
		public void BuildVerificationList(GUITestDataCollector guiTDC, int guiSeq, ref TypeVerificationSerializable TypesToVerify)
		{
			TypesToVerify.AUTPath = AUT;
			TypesToVerify.AUTStartupForm = StartForm;

			TypeVerification typeVerify = new TypeVerification();
			GetSelectedMembers(guiTDC, guiSeq, ref typeVerify);
			TypesToVerify.TypeList.Add(typeVerify);
		}
		

		private void GetSelectedMembers(GUITestDataCollector guiTDC, int guiSeq, ref TypeVerification typeVerify)
		{
			int itemCounter = 0;
			string typeMember = "";
			string[] expectedItems = GetExpectedOutcome(guiTDC.txtExpectedResult);

			for (int i = 0; i<guiTDC.chckLstMembersToVerify.Items.Count; i++)
			{
				if (guiTDC.chckLstMembersToVerify.GetItemChecked(i))
				{
					typeMember = guiTDC.chckLstMembersToVerify.GetItemText(guiTDC.chckLstMembersToVerify.Items[i]);
					if (!typeMember.StartsWith("\t"))
					{
						typeVerify.TypeName = typeMember;
						typeVerify.GUIEvent = GUIEvent;
					}
					else
					{
						TestExpectation individualTest = new TestExpectation();
						individualTest.EventMember = GUIEvent;
						individualTest.VerifyingMember = typeMember.Trim();
						individualTest.ExpectingResult = expectedItems[itemCounter];
						individualTest.GUIActionSequence = guiSeq;
						itemCounter++;

						typeVerify.MemberList.Add(individualTest);
						
					}
				}
			}
		}

		private string[] GetExpectedOutcome(RichTextBox rtfBox)
		{
			string[] expectedItems = rtfBox.Text.Split('|');
			
			for (int i = 0; i< expectedItems.Length; i++)
			{
				string tempItem = expectedItems[i].Trim();
				if (tempItem.StartsWith("<"))
					expectedItems[i] = tempItem.Substring(tempItem.IndexOf(">") + 1).Trim();
			}
			return expectedItems;
		}

	}

	[Serializable]public class TestExpectation
	{
		// for general purpose
		public string EventMember;
		public string VerifyingMember;
		public int GUIActionSequence;

		// for existence verification
		public bool isGUI = false;
		public bool isField = false;
		public bool isProperty = false;
		
		// for alphanumeric verification
		public string ExpectingResult="";
		public string ActualResult="";
		public string ScreenSnapshot = "";
		public bool ExpectAlphaNumericEqual = true;
		public bool AlphanumericPass = true;

		// For clipboard verification
		public object actualClpbrdObj;
		public object expectedClpbrdObj;
		public bool ExpectClipBrdEqual = true;
		public bool ClipboardPass = true;

		// For file existence and content verification
		public object actualFileobj;
		public object expectedFileObj;
		public bool FileTestPass = true;

		// object verification
		public object actualObj;
		public object expectedObj;
		public bool OjectTestPass = true;

		// image verification
		public object actualImg;
		public object expectedImg;
		public object ImageTestPass = true;

		
		public void AssertAlphanumericTest(bool expectedEqual)
		{
			bool actual = true;
			if (ExpectingResult.Trim().Equals(""))
			{
				if (!ScreenSnapshot.Trim().Equals(""))
				{
					if (!ActualResult.Trim().Equals(ScreenSnapshot.Trim()))
					{
						actual = false;
					}
				}
			}
			else
			{
				if (ScreenSnapshot.Trim().Equals(""))
				{
					if (!ExpectingResult.Trim().Equals(ScreenSnapshot.Trim()))
					{
						actual = false;
					}
				}
				else if ((!ExpectingResult.Equals(ScreenSnapshot)) ||
					(!ExpectingResult.Equals(ActualResult)) ||
					(!ActualResult.Equals(ScreenSnapshot)))
				{
					actual = false;
				}
			}
			if (actual == expectedEqual)
				AlphanumericPass = true;
			else
				AlphanumericPass = false;
		}

		public void AssertClipboardTest(bool expectedEqual)
		{
			bool actual = false;
			if (actualClpbrdObj.ToString() == expectedClpbrdObj.ToString())
				actual = true;

			if (actual == expectedEqual)
				ClipboardPass = true;
			else
				ClipboardPass = false;
		}

	}

	[Serializable]public class TypeVerification
	{
		public string AUTPath;
		public string TypeName;
		public string GUIEvent;
		
		[XmlArray("TestEvents")]
		[XmlArrayItem("TestAndVerify",typeof(TestExpectation))]
		public ArrayList MemberList = new ArrayList();
	}

	[Serializable]public class TypeVerificationSerializable
	{
		public string AUTPath;
		public string AUTStartupForm;

		[XmlArray("TypeVerificationSerializable")]
		[XmlArrayItem("FormUnderTest",typeof(TypeVerification))]
		public ArrayList TypeList = new ArrayList();
	}
}
