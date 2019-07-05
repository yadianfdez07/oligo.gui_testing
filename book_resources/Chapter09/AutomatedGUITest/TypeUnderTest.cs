using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutomatedGUITest
{
	public class TypeUnderTest : System.Windows.Forms.Form
	{
		public System.Windows.Forms.CheckedListBox chckListType;
		public System.Windows.Forms.Label lblTypeAvailable;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;

		public TypeUnderTest()
		{
			InitializeComponent();
		}

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
			this.chckListType = new System.Windows.Forms.CheckedListBox();
			this.lblTypeAvailable = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chckListType
			// 
			this.chckListType.CheckOnClick = true;
			this.chckListType.Location = new System.Drawing.Point(16, 48);
			this.chckListType.Name = "chckListType";
			this.chckListType.Size = new System.Drawing.Size(392, 184);
			this.chckListType.TabIndex = 0;
			// 
			// lblTypeAvailable
			// 
			this.lblTypeAvailable.Location = new System.Drawing.Point(16, 8);
			this.lblTypeAvailable.Name = "lblTypeAvailable";
			this.lblTypeAvailable.Size = new System.Drawing.Size(392, 40);
			this.lblTypeAvailable.TabIndex = 1;
			this.lblTypeAvailable.Text = "Select data types to test from the available list:";
			this.lblTypeAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(280, 242);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(56, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(352, 242);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// TypeUnderTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 273);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblTypeAvailable);
			this.Controls.Add(this.chckListType);
			this.Name = "TypeUnderTest";
			this.Text = "Types under Test";
			this.ResumeLayout(false);
		}
		#endregion
	}
}
