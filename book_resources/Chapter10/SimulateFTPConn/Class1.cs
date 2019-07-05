using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimulateFTPConn
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
			//Start a DOS command prompt 
			Process p = new Process();
			p.StartInfo.FileName = "cmd";
			p.Start();

			//Enter DOS command      
			SendKeys.Flush();
			SendKeys.SendWait("CD C:\\Temp{ENTER}");
			SendKeys.SendWait("dir{ENTER}");

			//Simulate a FTP connection
			SendKeys.SendWait("ftp ftp.your_ftp_site.com{ENTER}");
			SendKeys.SendWait("your_user_id{ENTER}");
			SendKeys.SendWait("your_password{ENTER}");
			SendKeys.SendWait("cd your_folder{ENTER}");
			SendKeys.SendWait("put readme.txt{ENTER}");
			SendKeys.SendWait("bye{ENTER}");

			//p.Kill();
		}

	}
}
