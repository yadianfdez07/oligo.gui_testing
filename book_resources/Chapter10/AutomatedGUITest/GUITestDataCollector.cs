using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using GUITestLibrary;
 
namespace AutomatedGUITest
{
	/// <summary>
	/// Summary description for GUITestDataCollector.
	/// </summary>
	public class GUITestDataCollector : System.Windows.Forms.Form
	{
		public GUITestUtility.GUIInfo guiInfo;
		public ArrayList ControlNameList;
		public ArrayList controlTypeList;

		private System.Windows.Forms.Label lblWindowText;
		private System.Windows.Forms.TextBox txtWindowText;
		private System.Windows.Forms.TextBox txtClassName;
		private System.Windows.Forms.Label lblClassName;
		private System.Windows.Forms.TextBox txtParentText;
		private System.Windows.Forms.Label lablParentText;
		private System.Windows.Forms.Label lblControlName;
		private System.Windows.Forms.ComboBox cmbControlName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblControlType;
		private System.Windows.Forms.ComboBox cmbControlType;
		public System.Windows.Forms.CheckedListBox chckLstMembersToVerify;
		private System.Windows.Forms.GroupBox grpVerifyMethod;
		public System.Windows.Forms.RadioButton rdSimple;
		public System.Windows.Forms.RadioButton rdLumpsum;
		public System.Windows.Forms.RadioButton rdJustEnough;
		private System.Windows.Forms.Button btnResetSpecificVerify;
		private System.Windows.Forms.Label lblExpectedResult;
		public System.Windows.Forms.RichTextBox txtExpectedResult;
		public System.Windows.Forms.RadioButton rdSpecific;
		private System.Windows.Forms.Label lblAvailableMembers;
		private System.Windows.Forms.CheckBox chckCustomDiglog;
		private System.Windows.Forms.Label lblTextEntry;
		private System.Windows.Forms.TextBox txtTextEntry;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GUITestDataCollector()
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
				if(components != null)
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
			this.lblWindowText = new System.Windows.Forms.Label();
			this.txtWindowText = new System.Windows.Forms.TextBox();
			this.txtClassName = new System.Windows.Forms.TextBox();
			this.lblClassName = new System.Windows.Forms.Label();
			this.txtParentText = new System.Windows.Forms.TextBox();
			this.lablParentText = new System.Windows.Forms.Label();
			this.lblControlName = new System.Windows.Forms.Label();
			this.cmbControlName = new System.Windows.Forms.ComboBox();
			this.cmbControlType = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblControlType = new System.Windows.Forms.Label();
			this.chckLstMembersToVerify = new System.Windows.Forms.CheckedListBox();
			this.grpVerifyMethod = new System.Windows.Forms.GroupBox();
			this.rdSpecific = new System.Windows.Forms.RadioButton();
			this.rdJustEnough = new System.Windows.Forms.RadioButton();
			this.rdLumpsum = new System.Windows.Forms.RadioButton();
			this.rdSimple = new System.Windows.Forms.RadioButton();
			this.btnResetSpecificVerify = new System.Windows.Forms.Button();
			this.txtExpectedResult = new System.Windows.Forms.RichTextBox();
			this.lblExpectedResult = new System.Windows.Forms.Label();
			this.lblAvailableMembers = new System.Windows.Forms.Label();
			this.chckCustomDiglog = new System.Windows.Forms.CheckBox();
			this.lblTextEntry = new System.Windows.Forms.Label();
			this.txtTextEntry = new System.Windows.Forms.TextBox();
			this.grpVerifyMethod.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblWindowText
			// 
			this.lblWindowText.Location = new System.Drawing.Point(24, 88);
			this.lblWindowText.Name = "lblWindowText";
			this.lblWindowText.Size = new System.Drawing.Size(80, 23);
			this.lblWindowText.TabIndex = 0;
			this.lblWindowText.Text = "Window Text";
			// 
			// txtWindowText
			// 
			this.txtWindowText.Location = new System.Drawing.Point(112, 88);
			this.txtWindowText.Name = "txtWindowText";
			this.txtWindowText.Size = new System.Drawing.Size(216, 20);
			this.txtWindowText.TabIndex = 1;
			this.txtWindowText.Text = "textBox1";
			// 
			// txtClassName
			// 
			this.txtClassName.Location = new System.Drawing.Point(112, 120);
			this.txtClassName.Name = "txtClassName";
			this.txtClassName.Size = new System.Drawing.Size(216, 20);
			this.txtClassName.TabIndex = 3;
			this.txtClassName.Text = "textBox2";
			// 
			// lblClassName
			// 
			this.lblClassName.Location = new System.Drawing.Point(24, 120);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(80, 23);
			this.lblClassName.TabIndex = 2;
			this.lblClassName.Text = "Class Name";
			// 
			// txtParentText
			// 
			this.txtParentText.Location = new System.Drawing.Point(112, 152);
			this.txtParentText.Name = "txtParentText";
			this.txtParentText.Size = new System.Drawing.Size(216, 20);
			this.txtParentText.TabIndex = 5;
			this.txtParentText.Text = "textBox3";
			// 
			// lablParentText
			// 
			this.lablParentText.Location = new System.Drawing.Point(24, 152);
			this.lablParentText.Name = "lablParentText";
			this.lablParentText.Size = new System.Drawing.Size(80, 23);
			this.lablParentText.TabIndex = 4;
			this.lablParentText.Text = "Parent Text";
			// 
			// lblControlName
			// 
			this.lblControlName.Location = new System.Drawing.Point(24, 24);
			this.lblControlName.Name = "lblControlName";
			this.lblControlName.Size = new System.Drawing.Size(80, 23);
			this.lblControlName.TabIndex = 6;
			this.lblControlName.Text = "Control Name";
			// 
			// cmbControlName
			// 
			this.cmbControlName.Location = new System.Drawing.Point(112, 24);
			this.cmbControlName.Name = "cmbControlName";
			this.cmbControlName.Size = new System.Drawing.Size(216, 21);
			this.cmbControlName.TabIndex = 7;
			this.cmbControlName.Text = "comboBox1";
			// 
			// cmbControlType
			// 
			this.cmbControlType.Location = new System.Drawing.Point(112, 56);
			this.cmbControlType.Name = "cmbControlType";
			this.cmbControlType.Size = new System.Drawing.Size(216, 21);
			this.cmbControlType.TabIndex = 8;
			this.cmbControlType.Text = "comboBox1";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(440, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(336, 376);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblControlType
			// 
			this.lblControlType.Location = new System.Drawing.Point(24, 56);
			this.lblControlType.Name = "lblControlType";
			this.lblControlType.Size = new System.Drawing.Size(80, 23);
			this.lblControlType.TabIndex = 11;
			this.lblControlType.Text = "Control Type";
			// 
			// chckLstMembersToVerify
			// 
			this.chckLstMembersToVerify.CheckOnClick = true;
			this.chckLstMembersToVerify.HorizontalScrollbar = true;
			this.chckLstMembersToVerify.Location = new System.Drawing.Point(24, 248);
			this.chckLstMembersToVerify.Name = "chckLstMembersToVerify";
			this.chckLstMembersToVerify.Size = new System.Drawing.Size(232, 124);
			this.chckLstMembersToVerify.TabIndex = 12;
			this.chckLstMembersToVerify.SelectedIndexChanged += new System.EventHandler(this.chckLstMembersToVerify_SelectedIndexChanged);
			// 
			// grpVerifyMethod
			// 
			this.grpVerifyMethod.Controls.Add(this.rdSpecific);
			this.grpVerifyMethod.Controls.Add(this.rdJustEnough);
			this.grpVerifyMethod.Controls.Add(this.rdLumpsum);
			this.grpVerifyMethod.Controls.Add(this.rdSimple);
			this.grpVerifyMethod.Location = new System.Drawing.Point(352, 16);
			this.grpVerifyMethod.Name = "grpVerifyMethod";
			this.grpVerifyMethod.Size = new System.Drawing.Size(168, 128);
			this.grpVerifyMethod.TabIndex = 18;
			this.grpVerifyMethod.TabStop = false;
			this.grpVerifyMethod.Text = "Verification Method:";
			// 
			// rdSpecific
			// 
			this.rdSpecific.Location = new System.Drawing.Point(32, 42);
			this.rdSpecific.Name = "rdSpecific";
			this.rdSpecific.TabIndex = 4;
			this.rdSpecific.Text = "Specific";
			this.rdSpecific.CheckedChanged += new System.EventHandler(this.rdSpecific_CheckedChanged);
			// 
			// rdJustEnough
			// 
			this.rdJustEnough.Location = new System.Drawing.Point(32, 95);
			this.rdJustEnough.Name = "rdJustEnough";
			this.rdJustEnough.TabIndex = 3;
			this.rdJustEnough.Text = "Just Enough";
			this.rdJustEnough.CheckedChanged += new System.EventHandler(this.rdJustEnough_CheckedChanged);
			// 
			// rdLumpsum
			// 
			this.rdLumpsum.Location = new System.Drawing.Point(32, 68);
			this.rdLumpsum.Name = "rdLumpsum";
			this.rdLumpsum.TabIndex = 2;
			this.rdLumpsum.Text = "Lump Sum";
			this.rdLumpsum.CheckedChanged += new System.EventHandler(this.rdLumpsum_CheckedChanged);
			// 
			// rdSimple
			// 
			this.rdSimple.Location = new System.Drawing.Point(32, 16);
			this.rdSimple.Name = "rdSimple";
			this.rdSimple.TabIndex = 0;
			this.rdSimple.Text = "Simple";
			this.rdSimple.CheckedChanged += new System.EventHandler(this.rdSimple_CheckedChanged);
			// 
			// btnResetSpecificVerify
			// 
			this.btnResetSpecificVerify.Location = new System.Drawing.Point(24, 380);
			this.btnResetSpecificVerify.Name = "btnResetSpecificVerify";
			this.btnResetSpecificVerify.Size = new System.Drawing.Size(144, 23);
			this.btnResetSpecificVerify.TabIndex = 23;
			this.btnResetSpecificVerify.Text = "Reset Specific Member";
			this.btnResetSpecificVerify.Click += new System.EventHandler(this.btnResetSpecificVerify_Click);
			// 
			// txtExpectedResult
			// 
			this.txtExpectedResult.Location = new System.Drawing.Point(288, 248);
			this.txtExpectedResult.Name = "txtExpectedResult";
			this.txtExpectedResult.Size = new System.Drawing.Size(232, 120);
			this.txtExpectedResult.TabIndex = 20;
			this.txtExpectedResult.Text = "";
			// 
			// lblExpectedResult
			// 
			this.lblExpectedResult.Location = new System.Drawing.Point(288, 224);
			this.lblExpectedResult.Name = "lblExpectedResult";
			this.lblExpectedResult.Size = new System.Drawing.Size(224, 24);
			this.lblExpectedResult.TabIndex = 21;
			this.lblExpectedResult.Text = "Expected Results:";
			// 
			// lblAvailableMembers
			// 
			this.lblAvailableMembers.Location = new System.Drawing.Point(24, 224);
			this.lblAvailableMembers.Name = "lblAvailableMembers";
			this.lblAvailableMembers.Size = new System.Drawing.Size(224, 23);
			this.lblAvailableMembers.TabIndex = 22;
			this.lblAvailableMembers.Text = "Select Fields and Properties to Verify:";
			// 
			// chckCustomDiglog
			// 
			this.chckCustomDiglog.Location = new System.Drawing.Point(352, 152);
			this.chckCustomDiglog.Name = "chckCustomDiglog";
			this.chckCustomDiglog.Size = new System.Drawing.Size(168, 24);
			this.chckCustomDiglog.TabIndex = 24;
			this.chckCustomDiglog.Text = "Custom Dialog Box";
			// 
			// lblTextEntry
			// 
			this.lblTextEntry.Location = new System.Drawing.Point(24, 184);
			this.lblTextEntry.Name = "lblTextEntry";
			this.lblTextEntry.Size = new System.Drawing.Size(80, 23);
			this.lblTextEntry.TabIndex = 25;
			this.lblTextEntry.Text = "Text Entry";
			// 
			// txtTextEntry
			// 
			this.txtTextEntry.Location = new System.Drawing.Point(112, 184);
			this.txtTextEntry.Name = "txtTextEntry";
			this.txtTextEntry.Size = new System.Drawing.Size(216, 20);
			this.txtTextEntry.TabIndex = 26;
			this.txtTextEntry.Text = "textBox4";
			// 
			// GUITestDataCollector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 410);
			this.Controls.Add(this.lblTextEntry);
			this.Controls.Add(this.txtTextEntry);
			this.Controls.Add(this.txtParentText);
			this.Controls.Add(this.txtWindowText);
			this.Controls.Add(this.txtClassName);
			this.Controls.Add(this.chckCustomDiglog);
			this.Controls.Add(this.lblAvailableMembers);
			this.Controls.Add(this.lblExpectedResult);
			this.Controls.Add(this.txtExpectedResult);
			this.Controls.Add(this.grpVerifyMethod);
			this.Controls.Add(this.chckLstMembersToVerify);
			this.Controls.Add(this.lblControlType);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblControlName);
			this.Controls.Add(this.lablParentText);
			this.Controls.Add(this.lblClassName);
			this.Controls.Add(this.lblWindowText);
			this.Controls.Add(this.cmbControlName);
			this.Controls.Add(this.cmbControlType);
			this.Controls.Add(this.btnResetSpecificVerify);
			this.Name = "GUITestDataCollector";
			this.Text = "GUI Test Data Collector";
			this.grpVerifyMethod.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		public void PopulateGUIInfo()
		{
			cmbControlName.DataSource = ControlNameList;
			cmbControlType.DataSource = controlTypeList;

			cmbControlName.Text = guiInfo.GUIControlName;
			cmbControlType.Text = guiInfo.GUIControlType;
			txtWindowText.Text = guiInfo.GUIText.ToString();
			txtClassName.Text = guiInfo.GUIClassName.ToString();
			txtParentText.Text = guiInfo.GUIParentText.ToString();
			txtTextEntry.Text = guiInfo.TextEntry;//chapter 10
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			guiInfo.GUIControlName = cmbControlName.Text;
			guiInfo.GUIControlType = cmbControlType.Text;
			guiInfo.GUIText = txtWindowText.Text;
			guiInfo.GUIClassName = txtClassName.Text;
			guiInfo.GUIParentText = txtParentText.Text;
			guiInfo.TextEntry = txtTextEntry.Text;//chapter 10
		}

		
		//chapter 8		
		private static string SpecificType;
		private static string SpecificMember;
		public string startupForm;
		
		private void rdSpecific_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdSpecific.Checked)
			{
				try
				{
					GetSpecificVerifyMember(chckLstMembersToVerify);
					AddExpectedContent();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
				
		}

		private void GetSpecificVerifyMember(CheckedListBox chckLst)
		{
			if (SpecificType == null)
			{
				ArrayList selectedMems = new ArrayList();
				for (int i = 0; i < chckLst.Items.Count; i ++)
				{
					if (chckLst.GetItemChecked(i))
					{
						selectedMems.Add(chckLst.GetItemText(chckLst.Items[i]));
					}
				}
				if (selectedMems.Count == 2)
				{
					SpecificType = (string)selectedMems[0];
					SpecificMember = (string)selectedMems[1];
					SpecificMember = SpecificMember.Trim();
				}
			}
			SetSimpleVerification(SpecificType, SpecificMember, chckLst);
			
		}

		private void SetSimpleVerification(string typeName, string memName, CheckedListBox chckLst)
		{
			int index1 = 0;
			int index2 = 0;

			try
			{
				index1 = chckLst.FindString(typeName);
				index2 = chckLst.FindString("\t" + memName, index1);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			if (index2 > index1)
			{
				chckLst.SetItemChecked(index1, true);
				chckLst.SetItemChecked(index2, true);
			}
		}

		private void AddExpectedContent()
		{
			string expectedStr = "";
			for (int i = 0; i<chckLstMembersToVerify.Items.Count; i++)
			{
				if (chckLstMembersToVerify.GetItemChecked(i))
				{
					string typeMember = chckLstMembersToVerify.GetItemText(chckLstMembersToVerify.Items[i]);
					if (typeMember.StartsWith("\t"))
					{
						expectedStr += "<" + typeMember.Trim() + ">\n|";
					}
				}
			}
			txtExpectedResult.Text = expectedStr;
		}

		private void rdSimple_CheckedChanged(object sender, System.EventArgs e)
		{
			MakeAllChecked(chckLstMembersToVerify, false);

			if (rdSimple.Checked)
			{
				SetSimpleVerification(startupForm, cmbControlName.Text, chckLstMembersToVerify);
				AddExpectedContent();
			}
		}

		private void MakeAllChecked(CheckedListBox chckLst, bool checkAll)
		{
			for (int i = 0; i < chckLst.Items.Count; i++)
			{	
				chckLst.SetItemChecked(i, checkAll);
			}
		}


		private void rdLumpsum_CheckedChanged(object sender, System.EventArgs e)
		{
			MakeAllChecked(chckLstMembersToVerify, rdLumpsum.Checked);
			AddExpectedContent();
		}

		private void rdJustEnough_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdJustEnough.Checked)
			{
				MakeAllChecked(chckLstMembersToVerify, false);
			}
		}

		private void chckLstMembersToVerify_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			AddExpectedContent();
		}

		private void btnResetSpecificVerify_Click(object sender, System.EventArgs e)
		{
			SpecificType = null;
			SpecificMember = null;
			MakeAllChecked(chckLstMembersToVerify, false);
		}
	}
}
