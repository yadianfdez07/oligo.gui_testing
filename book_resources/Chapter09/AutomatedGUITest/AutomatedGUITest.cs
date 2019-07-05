using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using GUITestLibrary;
using System.Threading;

namespace AutomatedGUITest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStartGUITest;
		private System.Windows.Forms.Button btnRunTest;
		private System.Windows.Forms.OpenFileDialog opnAUT;
		private System.Windows.Forms.SaveFileDialog sveDataStore;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnGUISurvey;
		private System.Windows.Forms.DataGrid dgAvailableGUIs;
		private System.Windows.Forms.Button btnRerun;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string currDir = Environment.CurrentDirectory;
		private string applicationUT;
		private string startupForm;
		private Form formUT;
		
		private GUISurveyClass guiSurveyCls;

		private GUITestDataCollector GUITDC;
		private GUITestUtility.GUIInfoSerializable GUITestSeqList;
		private ArrayList TempList;

		private string GuiProperty;
		private System.Windows.Forms.Label lblAvailabelGUI;
		
		private string TestCaseStore;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.btnStartGUITest = new System.Windows.Forms.Button();
			this.btnRunTest = new System.Windows.Forms.Button();
			this.opnAUT = new System.Windows.Forms.OpenFileDialog();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnGUISurvey = new System.Windows.Forms.Button();
			this.dgAvailableGUIs = new System.Windows.Forms.DataGrid();
			this.btnRerun = new System.Windows.Forms.Button();
			this.sveDataStore = new System.Windows.Forms.SaveFileDialog();
			this.lblAvailabelGUI = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgAvailableGUIs)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStartGUITest
			// 
			this.btnStartGUITest.Location = new System.Drawing.Point(24, 24);
			this.btnStartGUITest.Name = "btnStartGUITest";
			this.btnStartGUITest.Size = new System.Drawing.Size(88, 23);
			this.btnStartGUITest.TabIndex = 0;
			this.btnStartGUITest.Text = "Start GUI Test";
			this.btnStartGUITest.Click += new System.EventHandler(this.btnStartGUITest_Click);
			// 
			// btnRunTest
			// 
			this.btnRunTest.Location = new System.Drawing.Point(232, 24);
			this.btnRunTest.Name = "btnRunTest";
			this.btnRunTest.Size = new System.Drawing.Size(80, 23);
			this.btnRunTest.TabIndex = 1;
			this.btnRunTest.Text = "Run Test";
			this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(440, 24);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnGUISurvey
			// 
			this.btnGUISurvey.Location = new System.Drawing.Point(128, 24);
			this.btnGUISurvey.Name = "btnGUISurvey";
			this.btnGUISurvey.Size = new System.Drawing.Size(88, 23);
			this.btnGUISurvey.TabIndex = 3;
			this.btnGUISurvey.Text = "GUI Survey";
			this.btnGUISurvey.Click += new System.EventHandler(this.btnGUISurvey_Click);
			// 
			// dgAvailableGUIs
			// 
			this.dgAvailableGUIs.DataMember = "";
			this.dgAvailableGUIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAvailableGUIs.Location = new System.Drawing.Point(24, 88);
			this.dgAvailableGUIs.Name = "dgAvailableGUIs";
			this.dgAvailableGUIs.Size = new System.Drawing.Size(504, 256);
			this.dgAvailableGUIs.TabIndex = 6;
			this.dgAvailableGUIs.DoubleClick += new System.EventHandler(this.dgAvailableGUIs_DoubleClick);
			this.dgAvailableGUIs.CurrentCellChanged += new System.EventHandler(this.dgAvailableGUIs_CurrentCellChanged);
			// 
			// btnRerun
			// 
			this.btnRerun.Location = new System.Drawing.Point(328, 24);
			this.btnRerun.Name = "btnRerun";
			this.btnRerun.Size = new System.Drawing.Size(88, 24);
			this.btnRerun.TabIndex = 7;
			this.btnRerun.Text = "Rerun Test";
			this.btnRerun.Click += new System.EventHandler(this.btnRerun_Click);
			// 
			// lblAvailabelGUI
			// 
			this.lblAvailabelGUI.Location = new System.Drawing.Point(32, 64);
			this.lblAvailabelGUI.Name = "lblAvailabelGUI";
			this.lblAvailabelGUI.Size = new System.Drawing.Size(144, 23);
			this.lblAvailabelGUI.TabIndex = 8;
			this.lblAvailabelGUI.Text = "Available GUI components:";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 362);
			this.Controls.Add(this.lblAvailabelGUI);
			this.Controls.Add(this.btnRerun);
			this.Controls.Add(this.dgAvailableGUIs);
			this.Controls.Add(this.btnGUISurvey);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnRunTest);
			this.Controls.Add(this.btnStartGUITest);
			this.Name = "frmMain";
			this.Text = "Automated GUI Test Form";
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dgAvailableGUIs)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnStartGUITest_Click(object sender, System.EventArgs e)
		{
			TypesToVerify = new TypeVerificationSerializable();
			GUISequence = 0;//added for chapter 8

			GUITestSeqList = new GUITestUtility.GUIInfoSerializable();

			opnAUT.Title = "Specify an Application Under Test";
			opnAUT.Filter = "GUI Applications(*.EXE; *.DLL)|*.EXE;*.DLL|All files (*.*)|*.*";
			if (opnAUT.ShowDialog() == DialogResult.OK)
			{
				applicationUT = opnAUT.FileName;
				GUITestSeqList.AUTPath = applicationUT;

				GetTypeToTestFromAUT();
				try
				{
					formUT = (Form)GUITestUtility.StartAUT(applicationUT, startupForm);
				}
				catch (InvalidCastException ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				return;
			}
		}

		private void GetTypeToTestFromAUT()
		{
			if (applicationUT.Length <= 0)
			{
				return;
			}
			TypeUnderTest typeDUT = new TypeUnderTest();
			try
			{
				Assembly asm = Assembly.LoadFrom(applicationUT);
				Type[] tys = asm.GetTypes();
				foreach (Type ty in tys)
				{
					typeDUT.chckListType.Items.Add(ty.Namespace + "." + ty.Name);
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
				
			if (typeDUT.ShowDialog() == DialogResult.OK)
			{
				GetSelectedTypesUT(typeDUT);
			}
			else
			{
				return;
			}
			
		}

		private void GetSelectedTypesUT(TypeUnderTest typeDUT)
		{
			
			startupForm = "";
			for (int i = 0; i<typeDUT.chckListType.Items.Count; i++)
			{
				if (typeDUT.chckListType.GetItemChecked(i))
					startupForm = typeDUT.chckListType.GetItemText(typeDUT.chckListType.Items[i]);
			}
			
		}

		
		private void btnGUISurvey_Click(object sender, System.EventArgs e)
		{
			
			this.WindowState = FormWindowState.Minimized;
			
			try
			{
				guiSurveyCls = new GUISurveyClass((int)formUT.Handle);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			guiSurveyCls.StartGUISurvey();
			SetGUIListToTest();

			this.WindowState = FormWindowState.Normal;
		}

		private void SetGUIListToTest()
		{
			DataTable dtGUITable = new DataTable();

			MakeDataTableColumn(dtGUITable, "Handle", "System.Int32");
			MakeDataTableColumn(dtGUITable, "Window Text", "System.String");
			MakeDataTableColumn(dtGUITable, "Class Name", "System.String");
			MakeDataTableColumn(dtGUITable, "Parent Text", "System.String");

			for (int i = 0; i < guiSurveyCls.GUISortedList.Count; i++)
			{
				GUITestUtility.GUIInfo gui = (GUITestUtility.GUIInfo)guiSurveyCls.GUISortedList.GetByIndex(i);// obj;
				DataRow dtRow;
				dtRow = dtGUITable.NewRow();
				dtRow["Handle"] = gui.GUIHandle;
				dtRow["Window Text"] = gui.GUIText;
				dtRow["Class Name"] = gui.GUIClassName;
				dtRow["Parent Text"] = gui.GUIParentText;
				dtGUITable.Rows.Add(dtRow);

			}

			dgAvailableGUIs.DataSource = dtGUITable;
			
			
		}

		private void MakeDataTableColumn(DataTable dtAvailableGUIs, string colName, string dataType)
		{
			DataColumn guiColumn = new DataColumn(colName, Type.GetType(dataType));
			guiColumn.ReadOnly = true;
			guiColumn.AllowDBNull = true;
			guiColumn.Unique = false;
			dtAvailableGUIs.Columns.Add(guiColumn);
		}

		private void dgAvailableGUIs_CurrentCellChanged(object sender, System.EventArgs e)
		{
			GUITestActions.IndicateSelectedGUI((int)guiSurveyCls.GUISortedList.GetKey(dgAvailableGUIs.CurrentCell.RowNumber));
		}
		

		//chapter 8
        
		private GUITestVerification guiTestVrfy;
		private int GUISequence;
		TypeVerificationSerializable TypesToVerify;// = new TypeVerificationSerializable();

		private void dgAvailableGUIs_DoubleClick(object sender, System.EventArgs e)
		{

			GUITDC = new GUITestDataCollector();
			
			GUITDC.guiInfo = (GUITestUtility.GUIInfo)guiSurveyCls.GUISortedList.GetByIndex(dgAvailableGUIs.CurrentCell.RowNumber);
			
			TempList = new ArrayList();
			GUITDC.guiInfo.GUIControlName = PopulateGUINameTypeLists((Control)formUT, GUITDC.guiInfo.GUIHandle, true);
			TempList.Sort();
			GUITDC.ControlNameList = TempList;

			TempList = new ArrayList();
			GUITDC.guiInfo.GUIControlType = PopulateGUINameTypeLists((Control)formUT, GUITDC.guiInfo.GUIHandle, false);
			TempList.Sort();
			GUITDC.controlTypeList = TempList;
			
			GUITDC.PopulateGUIInfo();
			
			//chapter 8
			GUITDC.startupForm = startupForm; //for simple verification
			guiTestVrfy = new GUITestVerification(applicationUT, startupForm, GUITDC.guiInfo.GUIControlName);
			guiTestVrfy.FindMembersToVerify(applicationUT, GUITDC);

			//chapter 7
			if (GUITDC.ShowDialog() == DialogResult.OK)
			{
				GUITDC.guiInfo.GUIMemberType = GetMemberType(GUITDC.guiInfo.GUIControlName);
				GUITestSeqList.GUIList.Add(GUITDC.guiInfo);

				//chapter 8
				GUISequence++;
				guiTestVrfy.BuildVerificationList(GUITDC, GUISequence, ref TypesToVerify);
			}
		}

		private string PopulateGUINameTypeLists(Control formUT, int hwnd, bool enforceName)
		{
			if (formUT == null)
				return "";
		
			foreach( Control ctrl in formUT.Controls)
			{
				if (enforceName)
				{
                    TempList.Add(ctrl.Name);
					if ((int)ctrl.Handle == hwnd)
						GuiProperty = ctrl.Name;
				}
				else
				{
					if (!TempList.Contains(ctrl.GetType().ToString()))
						TempList.Add(ctrl.GetType().ToString());
					if ((int)ctrl.Handle == hwnd)
						GuiProperty = ctrl.GetType().ToString();
				}
				PopulateGUINameTypeLists(ctrl, hwnd, enforceName);
			}
			return GuiProperty;
		}

		private string GetMemberType(string ctrlName)
		{
			if (formUT == null)
				return "";

			BindingFlags allFlags = BindingFlags.Public | BindingFlags.NonPublic |
				BindingFlags.Static | BindingFlags.Instance;

			Type StartupForm = formUT.GetType();
			FieldInfo[] fis = StartupForm.GetFields(allFlags);
			foreach (FieldInfo fi in fis)
			{
				if (fi.Name == ctrlName)
				{
					return "VerifyField";
				}
			}

			PropertyInfo[] ppis = StartupForm.GetProperties(allFlags);
			foreach (PropertyInfo ppi in ppis)
			{
				if (ppi.Name == ctrlName)
				{
					return "VerifyProperty";
				}
			}
			return "";
		}


		private void btnRunTest_Click(object sender, System.EventArgs e)
		{
			sveDataStore.Title = "Location to save GUI test data";
			sveDataStore.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			if (sveDataStore.ShowDialog() == DialogResult.OK)
			{
				TestCaseStore = sveDataStore.FileName;
			}
			else
			{
				return;
			}

			
			GUITestSeqList.AUTStartupForm = startupForm;

            GUITestUtility.SerilizeInfo(TestCaseStore, GUITestSeqList);

			//chapter 8			
			string verifyStore = TestCaseStore.Replace(".xml", "_verify.xml");
			GUITestUtility.SerilizeInfo(verifyStore, TypesToVerify);
			
			GUITestScript guiTS = new GUITestScript(TestCaseStore, currDir);

			GUITestSeqList = null;
		}

		private void btnRerun_Click(object sender, System.EventArgs e)
		{
			opnAUT.Title = "Select an existing data store";
			opnAUT.Filter = "XLM test cases (*.xml)|*.xml|All Files (*.*)|*.*";

			if (opnAUT.ShowDialog() == DialogResult.OK)
			{
				GUITestScript guiTS = new GUITestScript(opnAUT.FileName, currDir);
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void frmMain_Resize(object sender, System.EventArgs e)
		{
			dgAvailableGUIs.Width = this.Width - 48;
			dgAvailableGUIs.Height = this.Height - 144;
		}
	}
}
