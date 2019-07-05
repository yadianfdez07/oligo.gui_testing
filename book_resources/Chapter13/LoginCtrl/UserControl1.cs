using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LoginCtrl
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class UserControl1 : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblUserID;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.Label lblPwd;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControl1()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblUserID = new System.Windows.Forms.Label();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.lblPwd = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblUserID
			// 
			this.lblUserID.Location = new System.Drawing.Point(16, 16);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(72, 23);
			this.lblUserID.TabIndex = 0;
			this.lblUserID.Text = "User ID";
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(88, 16);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(128, 20);
			this.txtUserID.TabIndex = 1;
			this.txtUserID.Text = "textBox1";
			// 
			// lblPwd
			// 
			this.lblPwd.Location = new System.Drawing.Point(16, 48);
			this.lblPwd.Name = "lblPwd";
			this.lblPwd.Size = new System.Drawing.Size(64, 23);
			this.lblPwd.TabIndex = 2;
			this.lblPwd.Text = "Password";
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(88, 48);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.Size = new System.Drawing.Size(128, 20);
			this.txtPwd.TabIndex = 3;
			this.txtPwd.Text = "textBox2";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 80);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(120, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			// 
			// UserControl1
			// 
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.lblPwd);
			this.Controls.Add(this.txtUserID);
			this.Controls.Add(this.lblUserID);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(232, 120);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
