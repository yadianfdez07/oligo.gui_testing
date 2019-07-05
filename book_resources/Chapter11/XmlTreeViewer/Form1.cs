using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace XmlTreeViewer
{
	public class Form1 : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.TreeView tvXml;
		private System.Windows.Forms.Button btnView;
		private System.Windows.Forms.OpenFileDialog opnXMLFile;
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

		//#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tvXml = new System.Windows.Forms.TreeView();
			this.btnView = new System.Windows.Forms.Button();
			this.opnXMLFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// tvXml
			// 
			this.tvXml.ImageIndex = -1;
			this.tvXml.Location = new System.Drawing.Point(32, 48);
			this.tvXml.Name = "tvXml";
			this.tvXml.SelectedImageIndex = -1;
			this.tvXml.Size = new System.Drawing.Size(368, 200);
			this.tvXml.TabIndex = 0;
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(192, 272);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(104, 32);
			this.btnView.TabIndex = 1;
			this.btnView.Text = "View XML";
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 314);
			this.Controls.Add(this.btnView);
			this.Controls.Add(this.tvXml);
			this.Name = "Form1";
			this.Text = "XML Document Viewer";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			opnXMLFile.Filter = "XML files (*.xml)|*.xml|All Files (*.*)|*.*";
			if (opnXMLFile.ShowDialog() == DialogResult.OK)
			{
				string xmlFile = opnXMLFile.FileName;
				OpenXmlDoc(xmlFile);
			}

		}

		public void OpenXmlDoc(string xmlFile)
		{
			tvXml.Nodes.Clear();

			//Initailize XML objects
			XmlTextReader xmlR = new XmlTextReader(xmlFile);
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlR);
			xmlR.Close();

			//navigate inside the XLM document & populate the tree
			TreeNode tnXML = new TreeNode("GUI Test XML");
			tvXml.Nodes.Add(tnXML);

			XmlNode xnGuiNode = xmlDoc.DocumentElement;
			XMLRecursion(xnGuiNode, tnXML);

			tvXml.ExpandAll();
			
		}

		private void XMLRecursion(XmlNode xnGuiNode, TreeNode tnXML)
		{
			TreeNode tmpTN = new TreeNode(xnGuiNode.Name + " " + xnGuiNode.Value);

			if (xnGuiNode.Value == "false")
			{
				tmpTN.ForeColor = System.Drawing.Color.Red;
			}

			tnXML.Nodes.Add(tmpTN);

			//preparing recursive call
			if (xnGuiNode.HasChildNodes)
			{
				XmlNode tmpXN = xnGuiNode.FirstChild;
				while (tmpXN != null)
				{
					XMLRecursion(tmpXN, tmpTN);
					tmpXN = tmpXN.NextSibling;
				}
			}
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			tvXml.Width = this.Width - 456+ 368;
			tvXml.Height = this.Height - 352 + 210;

			Point pnt = new Point(this.Width/2 - btnView.Width/2, this.Height - 352 + 272);
			btnView.Location = pnt;
		}
	}
}
