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
		private System.Windows.Forms.Label lblClassName;
		private System.Windows.Forms.Label lablParentText;
		private System.Windows.Forms.Label lblControlName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblControlType;
		private System.Windows.Forms.ComboBox cmbControlType;
		private System.Windows.Forms.TextBox txtClassName;
		private System.Windows.Forms.TextBox txtParentText;
		private System.Windows.Forms.ComboBox cmbControlName;
		private System.Windows.Forms.TextBox txtWindowText;
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
			this.lblClassName = new System.Windows.Forms.Label();
			this.lablParentText = new System.Windows.Forms.Label();
			this.lblControlName = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblControlType = new System.Windows.Forms.Label();
			this.cmbControlType = new System.Windows.Forms.ComboBox();
			this.txtClassName = new System.Windows.Forms.TextBox();
			this.txtParentText = new System.Windows.Forms.TextBox();
			this.cmbControlName = new System.Windows.Forms.ComboBox();
			this.txtWindowText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblWindowText
			// 
			this.lblWindowText.Location = new System.Drawing.Point(16, 88);
			this.lblWindowText.Name = "lblWindowText";
			this.lblWindowText.TabIndex = 0;
			this.lblWindowText.Text = "Window Text";
			// 
			// lblClassName
			// 
			this.lblClassName.Location = new System.Drawing.Point(16, 120);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.TabIndex = 2;
			this.lblClassName.Text = "Class Name";
			// 
			// lablParentText
			// 
			this.lablParentText.Location = new System.Drawing.Point(16, 152);
			this.lablParentText.Name = "lablParentText";
			this.lablParentText.TabIndex = 4;
			this.lablParentText.Text = "Parent Text";
			// 
			// lblControlName
			// 
			this.lblControlName.Location = new System.Drawing.Point(16, 24);
			this.lblControlName.Name = "lblControlName";
			this.lblControlName.TabIndex = 6;
			this.lblControlName.Text = "Control Name";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(240, 296);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(136, 296);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblControlType
			// 
			this.lblControlType.Location = new System.Drawing.Point(16, 56);
			this.lblControlType.Name = "lblControlType";
			this.lblControlType.TabIndex = 11;
			this.lblControlType.Text = "Control Type";
			// 
			// cmbControlType
			// 
			this.cmbControlType.Location = new System.Drawing.Point(120, 55);
			this.cmbControlType.Name = "cmbControlType";
			this.cmbControlType.Size = new System.Drawing.Size(192, 21);
			this.cmbControlType.TabIndex = 16;
			this.cmbControlType.Text = "comboBox1";
			// 
			// txtClassName
			// 
			this.txtClassName.Location = new System.Drawing.Point(120, 119);
			this.txtClassName.Name = "txtClassName";
			this.txtClassName.Size = new System.Drawing.Size(192, 20);
			this.txtClassName.TabIndex = 13;
			this.txtClassName.Text = "textBox2";
			// 
			// txtParentText
			// 
			this.txtParentText.Location = new System.Drawing.Point(120, 151);
			this.txtParentText.Name = "txtParentText";
			this.txtParentText.Size = new System.Drawing.Size(192, 20);
			this.txtParentText.TabIndex = 14;
			this.txtParentText.Text = "textBox3";
			// 
			// cmbControlName
			// 
			this.cmbControlName.Location = new System.Drawing.Point(120, 23);
			this.cmbControlName.Name = "cmbControlName";
			this.cmbControlName.Size = new System.Drawing.Size(192, 21);
			this.cmbControlName.TabIndex = 15;
			this.cmbControlName.Text = "comboBox1";
			// 
			// txtWindowText
			// 
			this.txtWindowText.Location = new System.Drawing.Point(120, 87);
			this.txtWindowText.Name = "txtWindowText";
			this.txtWindowText.Size = new System.Drawing.Size(192, 20);
			this.txtWindowText.TabIndex = 12;
			this.txtWindowText.Text = "textBox1";
			// 
			// GUITestDataCollector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 338);
			this.Controls.Add(this.cmbControlType);
			this.Controls.Add(this.txtClassName);
			this.Controls.Add(this.txtParentText);
			this.Controls.Add(this.cmbControlName);
			this.Controls.Add(this.txtWindowText);
			this.Controls.Add(this.lblControlType);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblControlName);
			this.Controls.Add(this.lablParentText);
			this.Controls.Add(this.lblClassName);
			this.Controls.Add(this.lblWindowText);
			this.Name = "GUITestDataCollector";
			this.Text = "GUI Test Data Collector";
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
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			guiInfo.GUIControlName = cmbControlName.Text;
			guiInfo.GUIControlType = cmbControlType.Text;
			guiInfo.GUIText = txtWindowText.Text;
			guiInfo.GUIClassName = txtClassName.Text;
			guiInfo.GUIParentText = txtParentText.Text;
		}

	}
}
