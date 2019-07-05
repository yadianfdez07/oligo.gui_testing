using System;
using System.Runtime.InteropServices;

namespace TestMonkey
{
	public enum MonkeyButtons
	{
		btcLeft,
		btcRight,
		btcWheel,
	}

	public class MouseAPI
	{
		public MouseAPI()
		{
		}

		private const int MOUSEEVENTF_ABSOLUTE = 0x8000 ; // absolute move;
		private const int MOUSEEVENTF_LEFTDOWN = 0x2 ; // left button down;
		private const int MOUSEEVENTF_LEFTUP = 0x4 ; // left button up;
		private const int MOUSEEVENTF_MOVE = 0x1 ; // mouse move;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x8 ; // right button down;
		private const int MOUSEEVENTF_RIGHTUP = 0x10 ; // right button up;
		private const int MOUSEEVENTF_WHEEL = 0x800 ; //mouse wheel turns

		private const int SM_CXSCREEN = 0;
		private const int SM_CYSCREEN = 1;
		private const int MOUSE_MICKEYS = 65535;

		[DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
		
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		

		public static bool ClickMouse(MonkeyButtons mbClick, int pixelX, int pixelY, int wlTurn, int dwExtraInfo)
		{
			int mEvent;
    
			switch (mbClick)
			{
				case MonkeyButtons.btcLeft:
					mEvent = MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
					break;
				case MonkeyButtons.btcRight:
					mEvent = MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
					break;
				case MonkeyButtons.btcWheel:
					mEvent =MOUSEEVENTF_WHEEL;
					break;
				
				default:
					return false;
			}
			mouse_event(mEvent, pixelX, pixelY, wlTurn, dwExtraInfo);
			return true;
		}	


		private static void PixelXYToMickeyXY(ref int pixelX, ref int pixelY)
		{
			//pixelX and pixelY have pixel as their units for input parameter
			int resX = 0;
			int resY = 0;
			resX = GetSystemMetrics(SM_CXSCREEN);
			resY =  GetSystemMetrics(SM_CYSCREEN);
			pixelX %= resX+1;
			pixelY %= resY+1;
			int cMickeys = MOUSE_MICKEYS;

			//Convert pixelX and pixelY into mickey steps as the output result
			pixelX = (int)(pixelX * (cMickeys / resX));
			pixelY = (int)(pixelY * (cMickeys / resY));
		}  
  
		public static void MoveMouse(int iHndl, int pixelX, int pixelY)
		{
			PixelXYToMickeyXY(ref pixelX, ref pixelY);
			mouse_event (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, 
				pixelX, pixelY, 0, 0);
		}
	}
}

