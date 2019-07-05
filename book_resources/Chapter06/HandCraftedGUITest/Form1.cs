using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using GUITestLibrary;
using System.Text;

namespace HandCraftedGUITest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStartApp;
		private System.Windows.Forms.Button btnStartScript;
		private System.Windows.Forms.Button btnVerifyScript;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
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
			this.btnStartScript = new System.Windows.Forms.Button();
			this.btnStartApp = new System.Windows.Forms.Button();
			this.btnVerifyScript = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnStartScript
			// 
			this.btnStartScript.Location = new System.Drawing.Point(48, 56);
			this.btnStartScript.Name = "btnStartScript";
			this.btnStartScript.Size = new System.Drawing.Size(152, 24);
			this.btnStartScript.TabIndex = 0;
			this.btnStartScript.Text = "Start Script";
			this.btnStartScript.Click += new System.EventHandler(this.btnStartScript_Click);
			// 
			// btnStartApp
			// 
			this.btnStartApp.Location = new System.Drawing.Point(48, 16);
			this.btnStartApp.Name = "btnStartApp";
			this.btnStartApp.Size = new System.Drawing.Size(152, 23);
			this.btnStartApp.TabIndex = 1;
			this.btnStartApp.Text = "Start Application to Test";
			this.btnStartApp.Click += new System.EventHandler(this.btnStartApp_Click);
			// 
			// btnVerifyScript
			// 
			this.btnVerifyScript.Location = new System.Drawing.Point(48, 96);
			this.btnVerifyScript.Name = "btnVerifyScript";
			this.btnVerifyScript.Size = new System.Drawing.Size(152, 23);
			this.btnVerifyScript.TabIndex = 2;
			this.btnVerifyScript.Text = "Verify Script";
			this.btnVerifyScript.Click += new System.EventHandler(this.btnVerifyScript_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 138);
			this.Controls.Add(this.btnVerifyScript);
			this.Controls.Add(this.btnStartApp);
			this.Controls.Add(this.btnStartScript);
			this.Name = "Form1";
			this.Text = "Form1";
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
		
		private object AUTobj;
		private ArrayList statusCollection;
		private int clickNum;

		private void btnStartApp_Click(object sender, System.EventArgs e)
		{
			string AppUT = @"C:\GUISourceCode\Chapter03\CSharpAPITextViewer\bin\Debug\CSharpAPITextViewer.exe";
			string TypeUT = "CSharpAPITextViewer.Form1";
			AUTobj = GUITestUtility.StartAUT(AppUT, TypeUT);
			
		}

		private void btnStartScript_Click(object sender, System.EventArgs e)
		{
			timer2.Enabled = true;
			statusCollection = new ArrayList();
			clickNum = 0;
		} 

		private void btnVerifyScript_Click(object sender, System.EventArgs e)
		{
			object obj1 = statusCollection[0];
			int clickNum1 = 0;
			foreach (object obj2 in statusCollection)
			{
				clickNum1++;
				string verification = "After click # " + clickNum1 + 
					" the text is:\n" + obj2.ToString() + "\n"  + 
					"Before click # " + clickNum1 + 
					" the text is:\n" + obj1.ToString();

				if (obj1.Equals(obj2))
				{
					MessageBox.Show("Text not Changed by the current event\n\n" + verification);
				}
				else
				{
					MessageBox.Show("Text Changed by the current event\n\n" + verification);
				}
				obj1 = obj2;
			}
		
		}

		
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			
			if (clickNum < 7)
			{
				clickNum++;
				timer1.Enabled = false;
				timer2.Enabled = true;
			}

			int hwnd = 0;
			string winText = "";
			string clsName = "";
			string pText = "";
			
			switch (clickNum)
			{
				case 1:
					//1. click the list box
					hwnd = 0;
					winText = "";
					clsName = "WindowsForms10.LISTBOX.app3";
					pText = "C# API Text Viewer";
					GUITestActions.HandleListBox(ref hwnd, ref winText, ref clsName, ref pText);
					break;
				case 2:
					//2. click the Add button
					winText = "Add";
					clsName = "";
					GUITestActions.HandleCommandButton(ref hwnd, ref winText, ref clsName, ref pText);
					break;

				case 3:
					//3. Click the Copy button
					winText = "Copy";
					clsName = "";
					GUITestActions.HandleCommandButton(ref hwnd, ref winText, ref clsName, ref pText);
					
					break;
				case 4:
					//4. Click the text box
					Control ctrlTested;
					ctrlTested = (Control)GUITestUtility.VerifyField(AUTobj, "txtSelected");
					StringBuilder sb = new StringBuilder(1000);
					GUITestActions.GetWindowText((int) ctrlTested.Handle, sb, 1000);
					winText = sb.ToString();
					clsName = "WindowsForms10.RichEdit20W.app3";
					GUITestActions.HandleTextBox(ref hwnd, ref winText, ref clsName, ref pText);
					break;
					
				case 5:
					//5. Click the Remove button to remove one line of code
					winText = "Remove";
					clsName = "";
					GUITestActions.HandleCommandButton(ref hwnd, ref winText, ref clsName, ref pText);
					break;

				case 6:
					//6. Click the Clear button to clear the text box
					winText = "Clear";
					clsName = "";
					pText = "C# API Text Viewer";
					GUITestActions.HandleCommandButton(ref hwnd, ref winText, ref clsName, ref pText);
					break;
				default:
			      //Complet this clicking sequence
					timer1.Enabled = false;
					timer2.Enabled = false;
					break;
			
			}
			
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			if (clickNum>0)
			{
				Control ctrlTested;
				ctrlTested = (Control)GUITestUtility.VerifyField(AUTobj, "txtSelected");
				statusCollection.Add(ctrlTested.Text);
			}
			timer1.Enabled = true;
			timer2.Enabled = false;
		}
	}
}
