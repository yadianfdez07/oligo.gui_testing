using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.IO;
using GUITestLibrary;
using System.Text;

namespace AutomatedGUITest
{
	
	public class GUITestScript : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer tmrStopScript;
		private System.Windows.Forms.Timer tmrAutomatedTest;
		private System.Windows.Forms.Timer tmrRunScript; 
		
		private string guiTestDataStore;
		private string progDir;
		
		private Form AUT;
		private GUITestUtility.GUIInfoSerializable seqGUIUT;

		private string guiTestActionLib;
		
		private TypeVerification testResult;
		private int MaxLen = 10000;
		private System.Windows.Forms.Timer tmrVerifyTest;
		private int clickNum;

		public GUITestScript()
		{
			InitializeComponent();
		}

		public GUITestScript(string _testDataStore, string _progDir)
		{
			InitializeComponent();
			guiTestDataStore = _testDataStore;
			progDir = _progDir;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tmrAutomatedTest = new System.Windows.Forms.Timer(this.components);
			this.tmrRunScript = new System.Windows.Forms.Timer(this.components);
			this.tmrStopScript = new System.Windows.Forms.Timer(this.components);
			this.tmrVerifyTest = new System.Windows.Forms.Timer(this.components);
			// 
			// tmrAutomatedTest
			// 
			this.tmrAutomatedTest.Enabled = true;
			this.tmrAutomatedTest.Tick += new System.EventHandler(this.tmrAutomatedTest_Tick);
			// 
			// tmrRunScript
			// 
			this.tmrRunScript.Tick += new System.EventHandler(this.tmrRunScript_Tick);
			// 
			// tmrStopScript
			// 
			this.tmrStopScript.Tick += new System.EventHandler(this.tmrStopScript_Tick);
			// 
			// tmrVerifyTest
			// 
			this.tmrVerifyTest.Tick += new System.EventHandler(this.tmrVerifyTest_Tick);
			// 
			// GUITestScript
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 154);
			this.Name = "GUITestScript";
			this.Text = "Form1";

		}
		#endregion
		
		
		private void tmrAutomatedTest_Tick(object sender, System.EventArgs e)
		{
			StartAUT();

			tmrAutomatedTest.Enabled = false;
			tmrRunScript.Enabled = true;
			
			//resultList = new ArrayList();
			testResult = new TypeVerification();
			testResult.AUTPath = seqGUIUT.AUTPath;
			testResult.TypeName = seqGUIUT.AUTStartupForm;
		}
		
		private void StartAUT()
		{
			seqGUIUT = new GUITestUtility.GUIInfoSerializable();
			object obj = (object)seqGUIUT;
			GUITestUtility.DeSerializeInfo(guiTestDataStore, ref obj);
			seqGUIUT = (GUITestUtility.GUIInfoSerializable)obj;

			string AUTPath = seqGUIUT.AUTPath;
			string startupType = seqGUIUT.AUTStartupForm;

			if (AUT == null)
				AUT = (Form)GUITestUtility.StartAUT(AUTPath, startupType);

			int hwnd = (int)AUT.Handle;
			StringBuilder sbClsName = new StringBuilder(128);
			GUITestActions.GetClassName(hwnd, sbClsName, 128);
			string clsName = sbClsName.ToString();
			string winText = AUT.Text;
			string pText = "";
			GUITestActions.SynchronizeWindow(ref hwnd, ref winText, ref clsName, ref pText); 
		}

		private void tmrRunScript_Tick(object sender, System.EventArgs e)
		{
			RunsScript();
			tmrRunScript.Enabled = false;
		
		}

		private void RunsScript()
		{
			guiTestActionLib = Path.Combine(progDir, "GUITestActionLib.xml");

			GUITestUtility.GUIInfo guiUnit = (GUITestUtility.GUIInfo)seqGUIUT.GUIList[clickNum];
				
			string ctrlAction = GUITestUtility.GetAGUIAction(guiTestActionLib, guiUnit.GUIControlType);
			
			StringBuilder sb = new StringBuilder(10000);

			Control ctrlTested = (Control)GUITestUtility.VerifyField(AUT, guiUnit.GUIControlName);
			GUITestActions.GetWindowText((int)ctrlTested.Handle, sb, 10000);
			
			object[] paramArr = new object[4];
			paramArr[0] = 0;
			paramArr[1] = sb.ToString();//.Replace("\r\n", "\n");
			paramArr[2] = guiUnit.GUIClassName;
			paramArr[3] = guiUnit.GUIParentText;
			
			Type guiTestLibType = new GUITestActions().GetType();
			object obj = Activator.CreateInstance(guiTestLibType);
			MethodInfo mi = guiTestLibType.GetMethod(ctrlAction);
				
			try
			{
				mi.Invoke(obj, paramArr);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			if (clickNum < seqGUIUT.GUIList.Count)
			{
				clickNum++;
				tmrRunScript.Enabled = false;
				tmrStopScript.Enabled = true;
			}

		}

		private void tmrStopScript_Tick(object sender, System.EventArgs e)
		{
			AddTestVerification();

			//			GUITestUtility.GUIInfo guiUnit = (GUITestUtility.GUIInfo)seqGUIUT.GUIList[clickNum - 1];
			//			Control ctrlTested;
			//			ctrlTested = (Control)GUITestUtility.VerifyField(AUT, "txtSelected");
			//			resultList.Add(ctrlTested.Text);

			if (clickNum >= seqGUIUT.GUIList.Count)
			{
				tmrRunScript.Enabled = false;
				tmrStopScript.Enabled = false;
				tmrVerifyTest.Enabled = true;
				try
				{
					AUT.Dispose();
				}
				catch{}
				
			}
			else
			{
				tmrRunScript.Enabled = true;
				tmrStopScript.Enabled = false;
			}
			
		}

		
		private void tmrVerifyTest_Tick(object sender, System.EventArgs e)
		{
			tmrVerifyTest.Enabled = false;

			string resultDataStore = guiTestDataStore.Replace(".xml", "_result.xml");
			//GUITestUtility.SerilizeInfo(resultDataStore, resultList);
			GUITestUtility.SerilizeInfo(resultDataStore, testResult);
			
			//Display the test result
			try
			{
				XmlTreeViewer.Form1 xmlTV = new XmlTreeViewer.Form1();
				xmlTV.OpenXmlDoc(resultDataStore);
				xmlTV.Show();
			}
			catch{}

			//Test completed
			this.Dispose();
		}

		//chapter 8
		private void AddTestVerification()
		{
			if (AUT == null)
				return;

			string VerifyDataStore = guiTestDataStore.Replace(".xml", "_verify.xml");

			TypeVerificationSerializable verifyTypes = new TypeVerificationSerializable();
			object obj = (object)verifyTypes;
			GUITestUtility.DeSerializeInfo(VerifyDataStore, ref obj);
			verifyTypes = (TypeVerificationSerializable)obj;

			TypeVerification oneType = (TypeVerification)verifyTypes.TypeList[clickNum - 1];
			object resulted = null;
			
			foreach (TestExpectation fieldName in oneType.MemberList)
			{
				TestExpectation tested = fieldName;
				try
				{
					resulted =  GUITestUtility.VerifyField(AUT, tested.VerifyingMember);
					tested.isField = true;

					
				}
				catch(Exception ex4)
				{
					resulted =  GUITestUtility.VerifyProperty(AUT, tested.VerifyingMember);
					tested.isProperty = true;
				}
				
				VerifyAlphanumericResult(ref tested, resulted); 
				VerifyClipboard(ref tested, resulted);

				//Chapter 9
				VerifyLabel(ref tested, resulted);
				VerifyGroupBox(ref tested, resulted);
				
			}
		}

		
		private void VerifyAlphanumericResult(ref TestExpectation fieldName, object resulted)
		{
			try
			{
				Control cntl = (Control)resulted;
				fieldName.isGUI = true;
				fieldName.ActualResult = cntl.Text;
				StringBuilder sb = new StringBuilder(MaxLen);
				GUITestActions.GetWindowText((int)cntl.Handle, sb, MaxLen);
				fieldName.ScreenSnapshot = sb.ToString();
			}
			catch (InvalidCastException ex1)
			{
				fieldName.ActualResult = resulted.ToString() + "\n" + ex1.Message;
			}
			catch (Exception ex2)
			{
				fieldName.ActualResult = fieldName.VerifyingMember + " is not found as a member.\n" + ex2.Message;
			}

			fieldName.AssertAlphanumericTest(fieldName.ExpectAlphaNumericEqual);
			testResult.MemberList.Add(fieldName);
		}

		private void VerifyClipboard(ref TestExpectation fieldName, object resulted)
		{
			fieldName.ActualClpbrdObj = Clipboard.GetDataObject().GetData(DataFormats.Text);
			try
			{
				Control cntl = (Control)resulted;
				fieldName.ExpectedClpbrdObj = cntl.Text;
				fieldName.AssertClipboardTest(fieldName.ExpectClipBrdEqual);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		//Chapter 9

		private void VerifyCosmeticGUIs(ref TestExpectation fieldName, object resulted)
		{
			try
			{
				Control cntl = (Control)resulted;
				fieldName.ActualCosmeticStr = "Caption: " + cntl.Text + "\n Size: " + cntl.Size + 
					"\n Child GUIs: " + cntl.Controls.Count + "\n Font: " + cntl.Font + 
					"\n Location: " + cntl.Location + "\n Back Color: " + cntl.BackColor +
					"\n Fore Color: " + cntl.ForeColor + "\n Enabled: " + cntl.Enabled +
					"\n Visible: " + cntl.Visible + "\n hasChildren: " + cntl.HasChildren;
				
				fieldName.AssertCosmeticGUITest();
			}
			catch (Exception ex)
			{
				fieldName.ActualCosmeticStr = ex.Message;
			}
		}

		private void VerifyLabel(ref TestExpectation fieldName, object resulted)
		{
			try
			{
				Label lbl = (Label)resulted;
				VerifyCosmeticGUIs(ref fieldName, lbl);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void VerifyGroupBox(ref TestExpectation fieldName, object resulted)
		{
			try
			{
				GroupBox grp = (GroupBox)resulted;
				VerifyCosmeticGUIs(ref fieldName, grp);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		
	}
}
