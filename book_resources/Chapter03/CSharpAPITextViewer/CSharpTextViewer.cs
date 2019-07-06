using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace CSharpAPITextViewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mnuMainAPI;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuFileOpen;
		private System.Windows.Forms.MenuItem mnuFileExit;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.MenuItem mnuFileSep;
		private System.Windows.Forms.OpenFileDialog opnFileDialog;
		private System.Windows.Forms.Label lblAPITypes;
		private System.Windows.Forms.ComboBox cmbAPITypes;
		private System.Windows.Forms.Label lblLookfor;
		private System.Windows.Forms.TextBox txtLookfor;
		private System.Windows.Forms.Label lblAvailablefuncs;
		public System.Windows.Forms.ListBox lstAvailableFuncs;
		private System.Windows.Forms.RichTextBox txtSelected;
		private System.Windows.Forms.Label lblSelected;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.GroupBox grpScope;
		private System.Windows.Forms.RadioButton rdPublic;
		private System.Windows.Forms.RadioButton rdPrivate;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnCopy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.mnuMainAPI = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuFileOpen = new System.Windows.Forms.MenuItem();
			this.mnuFileSep = new System.Windows.Forms.MenuItem();
			this.mnuFileExit = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.opnFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.lblAPITypes = new System.Windows.Forms.Label();
			this.cmbAPITypes = new System.Windows.Forms.ComboBox();
			this.lblLookfor = new System.Windows.Forms.Label();
			this.txtLookfor = new System.Windows.Forms.TextBox();
			this.lblAvailablefuncs = new System.Windows.Forms.Label();
			this.lstAvailableFuncs = new System.Windows.Forms.ListBox();
			this.txtSelected = new System.Windows.Forms.RichTextBox();
			this.lblSelected = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.grpScope = new System.Windows.Forms.GroupBox();
			this.rdPrivate = new System.Windows.Forms.RadioButton();
			this.rdPublic = new System.Windows.Forms.RadioButton();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.grpScope.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMainAPI
			// 
			this.mnuMainAPI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuFile,
																					   this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFileOpen,
																					this.mnuFileSep,
																					this.mnuFileExit});
			this.mnuFile.Text = "File";
			// 
			// mnuFileOpen
			// 
			this.mnuFileOpen.Index = 0;
			this.mnuFileOpen.Text = "Open";
			this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
			// 
			// mnuFileSep
			// 
			this.mnuFileSep.Index = 1;
			this.mnuFileSep.Text = "-";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Index = 2;
			this.mnuFileExit.Text = "Exit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 1;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuHelpAbout});
			this.mnuHelp.Text = "Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "About C# API Text Viewer";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// lblAPITypes
			// 
			this.lblAPITypes.Location = new System.Drawing.Point(16, 8);
			this.lblAPITypes.Name = "lblAPITypes";
			this.lblAPITypes.TabIndex = 0;
			this.lblAPITypes.Text = "API Type:";
			// 
			// cmbAPITypes
			// 
			this.cmbAPITypes.Location = new System.Drawing.Point(16, 26);
			this.cmbAPITypes.Name = "cmbAPITypes";
			this.cmbAPITypes.Size = new System.Drawing.Size(208, 21);
			this.cmbAPITypes.TabIndex = 1;
			this.cmbAPITypes.TextChanged += new System.EventHandler(this.cmbAPITypes_TextChanged);
			this.cmbAPITypes.SelectedIndexChanged += new System.EventHandler(this.cmbAPITypes_SelectedIndexChanged);
			// 
			// lblLookfor
			// 
			this.lblLookfor.Location = new System.Drawing.Point(16, 48);
			this.lblLookfor.Name = "lblLookfor";
			this.lblLookfor.Size = new System.Drawing.Size(312, 16);
			this.lblLookfor.TabIndex = 2;
			this.lblLookfor.Text = "Type the first few letters of the function name you look for:";
			// 
			// txtLookfor
			// 
			this.txtLookfor.Location = new System.Drawing.Point(16, 64);
			this.txtLookfor.Name = "txtLookfor";
			this.txtLookfor.Size = new System.Drawing.Size(312, 20);
			this.txtLookfor.TabIndex = 3;
			this.txtLookfor.Text = "Look for functions";
			this.txtLookfor.TextChanged += new System.EventHandler(this.txtLookfor_TextChanged);
			// 
			// lblAvailablefuncs
			// 
			this.lblAvailablefuncs.Location = new System.Drawing.Point(16, 88);
			this.lblAvailablefuncs.Name = "lblAvailablefuncs";
			this.lblAvailablefuncs.Size = new System.Drawing.Size(272, 16);
			this.lblAvailablefuncs.TabIndex = 4;
			this.lblAvailablefuncs.Text = "Available functions:";
			// 
			// lstAvailableFuncs
			// 
			this.lstAvailableFuncs.Location = new System.Drawing.Point(16, 104);
			this.lstAvailableFuncs.Name = "lstAvailableFuncs";
			this.lstAvailableFuncs.Size = new System.Drawing.Size(312, 95);
			this.lstAvailableFuncs.TabIndex = 5;
			// 
			// txtSelected
			// 
			this.txtSelected.Location = new System.Drawing.Point(16, 224);
			this.txtSelected.Name = "txtSelected";
			this.txtSelected.Size = new System.Drawing.Size(312, 136);
			this.txtSelected.TabIndex = 6;
			this.txtSelected.Text = "Selected functions";
			this.txtSelected.GotFocus += new System.EventHandler(this.txtSelected_GotFocus);
			// 
			// lblSelected
			// 
			this.lblSelected.Location = new System.Drawing.Point(16, 208);
			this.lblSelected.Name = "lblSelected";
			this.lblSelected.Size = new System.Drawing.Size(272, 16);
			this.lblSelected.TabIndex = 7;
			this.lblSelected.Text = "Selected functions:";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(344, 104);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(120, 23);
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// grpScope
			// 
			this.grpScope.Controls.Add(this.rdPrivate);
			this.grpScope.Controls.Add(this.rdPublic);
			this.grpScope.Location = new System.Drawing.Point(344, 136);
			this.grpScope.Name = "grpScope";
			this.grpScope.Size = new System.Drawing.Size(120, 72);
			this.grpScope.TabIndex = 9;
			this.grpScope.TabStop = false;
			this.grpScope.Text = "Scope";
			// 
			// rdPrivate
			// 
			this.rdPrivate.Location = new System.Drawing.Point(24, 40);
			this.rdPrivate.Name = "rdPrivate";
			this.rdPrivate.Size = new System.Drawing.Size(64, 24);
			this.rdPrivate.TabIndex = 1;
			this.rdPrivate.Text = "private";
			// 
			// rdPublic
			// 
			this.rdPublic.Location = new System.Drawing.Point(24, 16);
			this.rdPublic.Name = "rdPublic";
			this.rdPublic.Size = new System.Drawing.Size(56, 24);
			this.rdPublic.TabIndex = 0;
			this.rdPublic.Text = "public";
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(344, 232);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(120, 24);
			this.btnRemove.TabIndex = 10;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnRemove.GotFocus += new System.EventHandler(this.btnRemove_GotFocus);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(344, 264);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(120, 23);
			this.btnClear.TabIndex = 11;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(344, 336);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(120, 23);
			this.btnCopy.TabIndex = 12;
			this.btnCopy.Text = "Copy";
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 401);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.grpScope);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lblSelected);
			this.Controls.Add(this.txtSelected);
			this.Controls.Add(this.lstAvailableFuncs);
			this.Controls.Add(this.lblAvailablefuncs);
			this.Controls.Add(this.txtLookfor);
			this.Controls.Add(this.lblLookfor);
			this.Controls.Add(this.cmbAPITypes);
			this.Controls.Add(this.lblAPITypes);
			this.Menu = this.mnuMainAPI;
			this.MinimumSize = new System.Drawing.Size(480, 428);
			this.Name = "Form1";
			this.Text = "C# API Text Viewer";
			this.Resize += new System.EventHandler(this.RenewResize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grpScope.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void mnuHelpAbout_Click(object sender, System.EventArgs e)
		{
			string msg = "Effective GUI Test Automation: Developing an Automated GUI Testing Tool\n\n"; 
			msg += "by Kanglin Li\n";
			msg += "Publisher: Sybex Inc.\n";
			msg += "Copyright 2004\n";
			msg += "ISBN: 0-7821-4351-2\n\n";
			msg += "Please visit www.sybex.com for the most current update.";
			MessageBox.Show(msg, "Effective GUI Test Automation by Kanglin Li");
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			txtSelected.Text = "";
		}

		private void mnuFileExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnRemove_GotFocus(object sender, System.EventArgs e)
		{
			if (txtSelected.Text.Length > 0)
				btnRemove.Enabled = true;
			else
				btnRemove.Enabled = false;
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			try
			{
				string selectFuncs = txtSelected.Text;
				int currCursorPos = txtSelected.SelectionStart;

				int funcStartAt = currCursorPos - 1;
				int funcEndAt = currCursorPos + 1;
				GetFunctionStartPosition(selectFuncs, ref funcStartAt, true);
				GetFunctionStartPosition(selectFuncs, ref funcEndAt, false);

				string postRmStr = "";
				if (funcStartAt > 0)
					postRmStr = selectFuncs.Substring(0, funcStartAt);
				postRmStr += selectFuncs.Substring(funcEndAt);
				txtSelected.Text = postRmStr;
			}
			catch
			{
			}
		}

		private int GetFunctionStartPosition(string txt, ref int currCP, bool lookForStart)
		{
			if (currCP < 0)
				return 0;
			if (currCP > txt.Length - 1)
			{
				currCP = txt.Length;
				return 0;
			}
			char[] chr = txt.ToCharArray();
			while (chr[currCP] != '\n')
			{
				if (lookForStart)
				{
					if (currCP > 0)
						currCP -=1;
					else
						break;
				}
				else
				{
					if (currCP < txt.Length-1)
						currCP += 1;
					else
						break;
				}
			}
			return 0;
		}

		private void txtSelected_GotFocus(object sender, System.EventArgs e)
		{
			if (txtSelected.Text.Length > 0)
				btnRemove.Enabled = true;
			else
				btnRemove.Enabled = false;
		}

		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			Clipboard.SetDataObject(txtSelected.Text, true);
		}

		protected void RenewResize(object sender, System.EventArgs e)
		{

			SetControlWidth(txtLookfor);
			SetControlWidth(lstAvailableFuncs);
			SetControlWidth(txtSelected);
			SetControlHeight(txtSelected);

			SetControlLocation(btnAdd);
			SetControlLocation(grpScope);
			SetControlLocation(btnRemove);
			SetControlLocation(btnClear);
			SetControlLocation(btnCopy);
		}

		private void SetControlWidth(Control ctrl)
		{
			ctrl.Width = this.Width - 168;
		}

		private void SetControlLocation(Control ctrl)
		{
			Point pt = new Point(this.Width - 136, ctrl.Location.Y);
			ctrl.Location = pt;
		}

		private void SetControlHeight(Control ctrl)
		{
			ctrl.Height = this.Height - 300;
		}

		
		private void mnuFileOpen_Click(object sender, System.EventArgs e)
		{
			string filename = "";
			if (opnFileDialog.ShowDialog() == DialogResult.OK)
			{
				filename = opnFileDialog.FileName;
				OpenAPITextFile(filename);
			}
			else
			{
				return;
			}
			
		}

		private ConstantViewer constViewer;
		private StructViewer structViewer;
		private DllImportViewer dllImportViewer;
		
		private void OpenAPITextFile(string filename)
		{
			FillAPITypeCombobox();

			constViewer = new ConstantViewer(filename);
			Thread tConst = new Thread(new ThreadStart(constViewer.ParseText));
			tConst.Start();
			structViewer = new StructViewer(filename);
			Thread tStruct = new Thread(new ThreadStart(structViewer.ParseText));
			tStruct.Start();
			dllImportViewer = new DllImportViewer(filename);
			Thread tDllImport = new Thread(new ThreadStart(dllImportViewer.ParseText));
			tDllImport.Start();
			
			
			System.Threading.Thread.Sleep(1000);
			this.cmbAPITypes.Text = this.cmbAPITypes.Items[1].ToString();
		}

		private void cmbAPITypes_TextChanged(object sender, System.EventArgs e)
		{
			cmbAPITypes.SelectedIndex = cmbAPITypes.FindString(cmbAPITypes.Text);
			
		}
		private void cmbAPITypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Thread tConst;
			
			switch (cmbAPITypes.Text)
			{
                case "Constants":
                    UpdateConstants();
					break;
				case "Declares":
                    UpdateDllImports();
					break;
				case "Types":
                    UpdateStructs();
					break;
			}
		}

		private void FillAPITypeCombobox()
		{
			cmbAPITypes.Items.Clear();
			cmbAPITypes.Items.Add("Constants");
			cmbAPITypes.Items.Add("Declares");
			cmbAPITypes.Items.Add("Types");
		}
		private void UpdateConstants()
		{
			int i;
			Monitor.Enter(this);
			this.lstAvailableFuncs.Items.Clear();
			for (i = 0; i < constViewer.Count; i++)
			{
				this.lstAvailableFuncs.Items.Add(constViewer.GetKey(i));
			}
			Monitor.Exit(this);
		}
		private void UpdateDllImports()
		{
			int i;
			Monitor.Enter(this);
			this.lstAvailableFuncs.Items.Clear();
			for (i = 0; i < dllImportViewer.Count; i++)
			{
				lstAvailableFuncs.Items.Add(dllImportViewer.GetKey(i));
				
			}
			Monitor.Exit(this);
		}

		private void UpdateStructs()
		{
			int i;
			Monitor.Enter(this);
			lstAvailableFuncs.Items.Clear();
			for (i = 0; i < structViewer.Count; i++)
			{
				lstAvailableFuncs.Items.Add(structViewer.GetKey(i));
			}
			Monitor.Exit(this);
		}

		private void txtLookfor_TextChanged(object sender, System.EventArgs e)
		{
			lstAvailableFuncs.SelectedIndex = lstAvailableFuncs.FindString(txtLookfor.Text);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string cSharpCode = "";
			switch (this.cmbAPITypes.Text)
			{
				case "Types":
					cSharpCode = structViewer.GetCSharpSyntax(lstAvailableFuncs.SelectedIndex);
					break;
				case "Declares":
					cSharpCode = dllImportViewer.GetCSharpSyntax(lstAvailableFuncs.SelectedIndex);
					break;
				case "Constants":
					cSharpCode = constViewer.GetCSharpSyntax(lstAvailableFuncs.SelectedIndex);
					break;
			}
			if (rdPrivate.Checked)
			{
				cSharpCode = cSharpCode.Replace(APIUtility.CSHP_SCOPE, rdPrivate.Text.ToLower());
			}
			else
			{
				cSharpCode = cSharpCode.Replace(APIUtility.CSHP_SCOPE, rdPublic.Text.ToLower());
			}
			
			if (txtSelected.Text.IndexOf(cSharpCode) < 0)
				txtSelected.AppendText(cSharpCode + "\n");
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			txtLookfor.Clear();
			txtSelected.Clear();
			try
			{
				OpenAPITextFile(@"W:\_projects\oligo.gui_testing\book_resources\Chapter03\WIN32API.TXT");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
