using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestMonkey
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer tmrMonkey;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numInterval;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.tmrMonkey = new System.Windows.Forms.Timer(this.components);
			this.btnStart = new System.Windows.Forms.Button();
			this.numInterval = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// tmrMonkey
			// 
			this.tmrMonkey.Interval = 2000;
			this.tmrMonkey.Tick += new System.EventHandler(this.tmrMonkey_Tick);
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
			this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStart.Location = new System.Drawing.Point(32, 24);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(88, 32);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// numInterval
			// 
			this.numInterval.Location = new System.Drawing.Point(32, 88);
			this.numInterval.Name = "numInterval";
			this.numInterval.TabIndex = 1;
			this.numInterval.Value = new System.Decimal(new int[] {
																	  3,
																	  0,
																	  0,
																	  0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(37, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Interval (sec.)";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 130);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numInterval);
			this.Controls.Add(this.btnStart);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Test Monkey";
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
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

		
		private void btnStart_Click(object sender, System.EventArgs e)
		{
			if (tmrMonkey.Enabled)
			{
				tmrMonkey.Enabled = false;
				btnStart.Text = "Start";
			}
			else
			{
				tmrMonkey.Enabled = true;
				btnStart.Text = "Stop";
				this.WindowState = FormWindowState.Minimized;
			}
		}

		private void tmrMonkey_Tick(object sender, System.EventArgs e)
		{
			tmrMonkey.Interval = (int)numInterval.Value * 1000;
			Random rnd = new Random();
			int x = rnd.Next();
			int y = rnd.Next();
			MouseAPI.MoveMouse(this.Handle.ToInt32(), x, y);
			MouseAPI.ClickMouse(MonkeyButtons.btcLeft, 0, 0, 0, 0);
		}
				
	}
}
