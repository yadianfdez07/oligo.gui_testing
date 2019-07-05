using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using GUITestLibrary;

namespace GUIScriptSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStartApp;
		private System.Windows.Forms.Button btnStartStop;
		private System.Windows.Forms.Timer tmrAddDefinition;
		private System.ComponentModel.IContainer components;

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
			this.components = new System.ComponentModel.Container();
			this.btnStartApp = new System.Windows.Forms.Button();
			this.btnStartStop = new System.Windows.Forms.Button();
			this.tmrAddDefinition = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnStartApp
			// 
			this.btnStartApp.Location = new System.Drawing.Point(56, 40);
			this.btnStartApp.Name = "btnStartApp";
			this.btnStartApp.Size = new System.Drawing.Size(120, 23);
			this.btnStartApp.TabIndex = 0;
			this.btnStartApp.Text = "Start AUT";
			this.btnStartApp.Click += new System.EventHandler(this.btnStartApp_Click);
			// 
			// btnStartStop
			// 
			this.btnStartStop.Location = new System.Drawing.Point(56, 80);
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.Size = new System.Drawing.Size(120, 23);
			this.btnStartStop.TabIndex = 1;
			this.btnStartStop.Text = "Start";
			this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
			// 
			// tmrAddDefinition
			// 
			this.tmrAddDefinition.Interval = 3000;
			this.tmrAddDefinition.Tick += new System.EventHandler(this.tmrAddDefinition_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 146);
			this.Controls.Add(this.btnStartStop);
			this.Controls.Add(this.btnStartApp);
			this.Name = "Form1";
			this.Text = "GUI Script Sample";
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

		private void btnStartApp_Click(object sender, System.EventArgs e)
		{
			string AUT = @"C:\GUISourceCode\Chapter03\CSharpAPITextViewer\bin\Debug\CSharpAPITextViewer.exe";
			Process p = new Process();
			p.StartInfo.FileName = AUT;
			
			p.Start();
		}

		
		private void btnStartStop_Click(object sender, System.EventArgs e)
		{
			if (!tmrAddDefinition.Enabled)
			{
				tmrAddDefinition.Enabled = true;
				btnStartStop.Text = "Stop";
			}
			else
			{
				tmrAddDefinition.Enabled = false;
				btnStartStop.Text = "Start";
			}
		}

		private void tmrAddDefinition_Tick(object sender, System.EventArgs e)
		{

			int hwnd = 0;
			string winText = "";
			string clsName = "WindowsForms10.LISTBOX.app3";
			string pText = "C# API Text Viewer";
			GUITestActions.HandleListBox(ref hwnd, ref winText, ref clsName, ref pText);

			winText = "Add";
			clsName = "";
			pText = "C# API Text Viewer";
			GUITestActions.HandleCommandButton(ref hwnd, ref winText, ref clsName, ref pText);
			
			
		}

	}

}
