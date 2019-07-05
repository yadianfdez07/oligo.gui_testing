using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace ControlSerializer
{
	
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Button btnSerialize;
		private System.Windows.Forms.Button btnDeserialize;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.OpenFileDialog ofdDeserialize;
		private System.Windows.Forms.SaveFileDialog sfdSerialize;
		private System.Windows.Forms.Button btnReset;
		#region Windows Form Designer generated code

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

		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblText = new System.Windows.Forms.Label();
			this.txtType = new System.Windows.Forms.TextBox();
			this.lblType = new System.Windows.Forms.Label();
			this.btnSerialize = new System.Windows.Forms.Button();
			this.btnDeserialize = new System.Windows.Forms.Button();
			this.txtText = new System.Windows.Forms.TextBox();
			this.ofdDeserialize = new System.Windows.Forms.OpenFileDialog();
			this.sfdSerialize = new System.Windows.Forms.SaveFileDialog();
			this.btnReset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(24, 32);
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Control Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(136, 32);
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// lblText
			// 
			this.lblText.Location = new System.Drawing.Point(24, 64);
			this.lblText.Name = "lblText";
			this.lblText.TabIndex = 2;
			this.lblText.Text = "Control Text";
			// 
			// txtType
			// 
			this.txtType.Location = new System.Drawing.Point(136, 96);
			this.txtType.Name = "txtType";
			this.txtType.TabIndex = 5;
			this.txtType.Text = "";
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(24, 96);
			this.lblType.Name = "lblType";
			this.lblType.TabIndex = 4;
			this.lblType.Text = "Control Type";
			// 
			// btnSerialize
			// 
			this.btnSerialize.Location = new System.Drawing.Point(40, 144);
			this.btnSerialize.Name = "btnSerialize";
			this.btnSerialize.TabIndex = 6;
			this.btnSerialize.Text = "Serialize";
			this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
			// 
			// btnDeserialize
			// 
			this.btnDeserialize.Location = new System.Drawing.Point(160, 144);
			this.btnDeserialize.Name = "btnDeserialize";
			this.btnDeserialize.TabIndex = 7;
			this.btnDeserialize.Text = "Deserialize";
			this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
			// 
			// txtText
			// 
			this.txtText.Location = new System.Drawing.Point(136, 64);
			this.txtText.Name = "txtText";
			this.txtText.TabIndex = 3;
			this.txtText.Text = "";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(160, 184);
			this.btnReset.Name = "btnReset";
			this.btnReset.TabIndex = 8;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 234);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnDeserialize);
			this.Controls.Add(this.btnSerialize);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.lblText);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblName);
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

		private void btnSerialize_Click(object sender, System.EventArgs e)
		{
			//initialize a GUIControlProperties object
			GUIControlProperties GuiCtrlProp;
			GuiCtrlProp = new GUIControlProperties();
			GuiCtrlProp.GUIName = txtName.Text;
			GuiCtrlProp.GUIText = txtText.Text;
			GuiCtrlProp.GUIType = txtType.Text;

			//make a filename to serialize the object
			string filename = "";
			sfdSerialize.Filter = "Serializing Files (*.bin; *.soap; *.xml)|*.bin;*.soap;*.xml|All Files|*.*";
			if (sfdSerialize.ShowDialog() == DialogResult.OK)
			{
				filename = sfdSerialize.FileName;
			}
			else
			{
				return;
			}

			//Start serialization
			FileInfo fi = new FileInfo(filename);
			switch (fi.Extension)
			{
				case ".bin":
					BinarySerialization(filename, GuiCtrlProp);
					break;
				case ".soap":
					SoapSerialization(filename, GuiCtrlProp);
					break;
				case ".xml":
					XmlSerialization(filename, GuiCtrlProp);
					break;
			}
		}

		private void BinarySerialization(string filename, GUIControlProperties obj)
		{
			//Create a file stream object
			FileStream serializeStream = File.Create(filename);
			
			//Start Serialization
			BinaryFormatter binFmt = new BinaryFormatter();
			binFmt.Serialize(serializeStream, obj);
			serializeStream.Close();

		}

		
		private void btnDeserialize_Click(object sender, System.EventArgs e)
		{
			//Get the serilized file name
			string filename = "";
			ofdDeserialize.Filter = "Serializing Files (*.bin; *.soap; *.xml)|*.bin;*.soap;*.xml|All Files|*.*";
			if (ofdDeserialize.ShowDialog() == DialogResult.OK)
			{
				filename = ofdDeserialize.FileName;
			}
			else
			{
				return;
			}

			//reconstruct the object from a file
			GUIControlProperties GuiCtrlProp = null;
			FileInfo fi = new FileInfo(filename);
            switch (fi.Extension)
			{
				case ".bin":
					GuiCtrlProp = BinaryDeSerialization(filename);
					break;
				case ".soap":
					GuiCtrlProp = SoapDeSerialization(filename);
					break;
				case ".xml":
					GuiCtrlProp = XmlDeSerialization(filename);
					break;
			}
			
			//populate the text of the GUI controls on the form
			txtName.Text = GuiCtrlProp.GUIName;
			txtText.Text = GuiCtrlProp.GUIText;
			txtType.Text = GuiCtrlProp.GUIType;
		}

		private GUIControlProperties BinaryDeSerialization(string filename)
		{
			GUIControlProperties GuiCtrlProp;

			//Create a file stream object
			FileStream serializeStream = File.OpenRead(filename);
			
			//Start Serialization
			BinaryFormatter binFmt = new BinaryFormatter();
			GuiCtrlProp = (GUIControlProperties)binFmt.Deserialize(serializeStream);
			serializeStream.Close();
			return GuiCtrlProp;
		}

		private void SoapSerialization(string filename, GUIControlProperties obj)
		{
			//Create a file stream object
			FileStream serializeStream = File.Create(filename);
			
			//Start Serialization
			SoapFormatter soapFmt = new SoapFormatter();
			soapFmt.Serialize(serializeStream, obj);
			serializeStream.Close();

		}

		private GUIControlProperties SoapDeSerialization(string filename)
		{
			GUIControlProperties GuiCtrlProp;

			//Create a file stream object
			FileStream serializeStream = File.OpenRead(filename);
			
			//Start Serialization
			SoapFormatter soapFmt = new SoapFormatter();
			GuiCtrlProp = (GUIControlProperties)soapFmt.Deserialize(serializeStream);
			serializeStream.Close();
			return GuiCtrlProp;
			
		}

		private void XmlSerialization(string filename, GUIControlProperties obj)
		{
			//Create a file stream object
			FileStream serializeStream = File.Create(filename);
			
			//Start Serialization
			XmlSerializer xmlFmt = new XmlSerializer(obj.GetType());
			xmlFmt.Serialize(serializeStream, obj);
			serializeStream.Close();

		}

		private GUIControlProperties XmlDeSerialization(string filename)
		{
			GUIControlProperties GuiCtrlProp = new GUIControlProperties();

			//Create a file stream object
			FileStream serializeStream = File.OpenRead(filename);
			
			//Start Serialization
			XmlSerializer xmlFmt = new XmlSerializer(GuiCtrlProp.GetType());
			GuiCtrlProp = (GUIControlProperties)xmlFmt.Deserialize(serializeStream);
			serializeStream.Close();
			return GuiCtrlProp;
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			txtName.Clear();
			txtText.Clear();
			txtType.Clear();
		}
	}
}
