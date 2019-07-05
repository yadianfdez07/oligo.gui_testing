using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms; //chapter 10

namespace GUITestLibrary
{

	[StructLayout(LayoutKind.Sequential)]
	public struct POINTAPI
	{
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
	}

	public enum MonkeyButtons
	{
		btcLeft,
		btcRight,
		btcWheel,
	}

	public enum GUIInfoType
	{
		guiText,
		guiTextClass,
		guiTextParent,
		guiClassParent,
		guiTextClassParent,
	}

	public enum RectPosition
	{
		LeftTop,
		LeftBottom,
		MiddleTop,
		MiddleBottom,
		RightTop,
		RightBottom,
		AnySpot,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MENUITEMINFO
	{
		public int cbSize;
		public int fMask;
		public int fType;
		public int fState;
		public int wID;
		public int hSubMenu;
		public int hbmpChecked;
		public int hbmpUnchecked;
		public int dwItemData;
		public string dwTypeData;
		public int cch;
	}

	/// <summary>
	/// Summary description for GUITestActions.
	/// </summary>
	public class GUITestActions
	{
		public GUITestActions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public const int WM_GETTEXT = 0xD;
		public const int WM_GETTEXTLENGTH = 0xE;

		public const int MOUSEEVENTF_ABSOLUTE = 0x8000 ; // absolute move;
		public const int MOUSEEVENTF_LEFTDOWN = 0x2 ; // left button down;
		public const int MOUSEEVENTF_LEFTUP = 0x4 ; // left button up;
		public const int MOUSEEVENTF_MOVE = 0x1 ; // mouse move;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x8 ; // right button down;
		public const int MOUSEEVENTF_RIGHTUP = 0x10 ; // right button up;
		public const int MOUSEEVENTF_WHEEL = 0x800 ; //mouse wheel turns
		private const int MOUSE_MICKEYS = 65535; //65535 mickeys steps across screen both horizontally and vertically
		public const int SM_CXSCREEN = 0;
		public const int SM_CYSCREEN = 1;

		public const int GWL_ID = (-12);
		public const int GW_HWNDNEXT = 2;
		public const int GW_CHILD = 5;

		public const int IDANI_CAPTION  = 0x3;
		public const int IDANI_CLOSE  = 0x2;
		public const int IDANI_OPEN  = 0x1;

		[DllImport("user32.dll")]
		public static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int SetWindowText(int hwnd, StringBuilder lpString);

		[DllImport("user32.dll")]
		public static extern int GetFocus();

		[DllImport("user32.dll")]
		public static extern int GetDlgItem(int hDlg, int nIDDlgItem);

		[DllImport("user32.dll")]
		public static extern int GetCursorPos([MarshalAs(UnmanagedType.Struct)] ref  POINTAPI lpPoint);

		[DllImport("user32.dll")]
		public static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll")]
		public static extern int WindowFromPoint(int xPoint, int yPoint);

		[DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, [MarshalAs(UnmanagedType.Struct)] ref  RECT lpRect);

		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(int hwnd);

		[DllImport("user32.dll")]
		public static extern int GetWindow(int hwnd, int wCmd);

		[DllImport("user32.dll")]
		public static extern int GetDesktopWindow();

		[DllImport("user32.dll")]
		public static extern int GetWindowLong(int hwnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern int GetParent(int hwnd);

		[DllImport("user32.dll")]
		public static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);

		[DllImport("user32.dll")]
		public static extern int GetWindowTextLength(int hwnd);

		[DllImport("user32.dll")]
		public static extern int GetDlgCtrlID(int hwnd);

		[DllImport("user32.dll")]
		public static extern int GetMenu(int hwnd);

		[DllImport("user32.dll")]
		public static extern int GetMenuItemCount(int hMenu);

		[DllImport("user32.dll")]
		public static extern int GetMenuItemRect(int hWnd, int hMenu, int uItem, [MarshalAs(UnmanagedType.Struct)] ref  RECT lprcItem);

		[DllImport("user32.dll")]
		public static extern int GetMenuItemInfo(int hMenu, int un, int b, [MarshalAs(UnmanagedType.Struct)] ref  MENUITEMINFO lpMenuItemInfo);

		[DllImport("user32.dll")]
		public static extern int GetMessageExtraInfo();


		[DllImport("user32.dll")]
		public static extern int SetRect([MarshalAs(UnmanagedType.Struct)] ref  RECT lpRect, int X1, int Y1, int X2, int Y2);

		[DllImport("user32.dll")]
		public static extern int DrawAnimatedRects(int hwnd, int idAni, [MarshalAs(UnmanagedType.Struct)] ref  RECT lprcFrom, [MarshalAs(UnmanagedType.Struct)] ref  RECT lprcTo);

		
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

		public static void PixelXYToMickeyXY(ref int pixelX, ref int pixelY)
		{
			int resX = 0;
			int resY = 0;
			GetDisplayResolution(ref resX, ref resY);

			pixelX %= resX+1;
			pixelY %= resY+1;
			int cMickeys = MOUSE_MICKEYS;
			pixelX = (int)(pixelX * (cMickeys / resX));
			pixelY = (int)(pixelY * (cMickeys / resY));
		} 


		public static void MoveMouse(int iHndl, int pixelX, int pixelY)
		{
			PixelXYToMickeyXY(ref pixelX, ref pixelY);
			mouse_event (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, 
				pixelX, pixelY, 0, 0);
		}

		public static void GetSmartInfo(ref int wHdl, ref StringBuilder clsName, ref StringBuilder wndText)
		{
			POINTAPI Pnt = new POINTAPI();
			
			GetCursorPos(ref Pnt);
			wHdl = WindowFromPoint(Pnt.x, Pnt.y);
			GetClassName(wHdl, clsName, 128);
			GetWindowText(wHdl, wndText, 128);
		}

		//Chapter 4
		private static int level = 0;
		private static int maxLen = 10000; //need to modify text chapter 4
		public static int FindGUILike(ref int hWndTarget, int hWndStart, 
			ref string windowText, ref string className, ref string parentText)
		{
			int hwnd=0;
			int r=0;
			//int level = 0;
			StringBuilder sWindowText=new StringBuilder();
			StringBuilder sClassname=new StringBuilder();
			StringBuilder sParentText = new StringBuilder();
			
			if (level == 0)
			{
				hWndTarget = 0;
				if (hWndStart == 0) hWndStart = GetDesktopWindow();
			}
			level = level + 1;
			
			hwnd = GetWindow(hWndStart, GW_CHILD);
		

			while (hwnd != 0) 
			{
				r = FindGUILike(ref hWndTarget, hwnd, ref windowText, ref className, ref parentText);

				sWindowText.Capacity = maxLen; //need to modify text chapter 4
				r = GetWindowText(hwnd, sWindowText, maxLen);
				sClassname.Capacity= maxLen;
				r = GetClassName(hwnd, sClassname, maxLen);
				sParentText.Capacity = maxLen;
				r = GetWindowText(GetParent(hwnd), sParentText, maxLen);
				
				GUIInfoType guiInfoType = GetGUIInfoType(windowText, className, parentText);
				
				ResetGUIInfo(guiInfoType, hwnd, ref hWndTarget, ref windowText, ref className, ref parentText, sWindowText, sClassname, sParentText);
				// Get next child window:
				hwnd = GetWindow(hwnd, GW_HWNDNEXT);
			}
			//  Decrement recursion counter:
			level = level - 1;
			return 0;
		}

		public static void GetDisplayResolution(ref int pixelX, ref int pixelY)
		{
			pixelX = GetSystemMetrics(SM_CXSCREEN);
			pixelY = GetSystemMetrics(SM_CYSCREEN);
		}

		
		public static bool CenterMouseOn(int hwnd) 
		{
			int x = 0;
			int y=0;
			int maxX=0;
			int maxY=0;
			RECT crect = new RECT();
			int gFound=0;

			GetDisplayResolution(ref maxX, ref maxY);
			gFound = GetWindowRect(hwnd, ref crect);
    
			//if (gFound>0)
		{
			x = crect.Left + ((crect.Right - crect.Left) / 2);
			y = crect.Top + ((crect.Bottom - crect.Top) / 2);
			if ((x >= 0 && x <= maxX) && (y >= 0 && y <= maxY))
			{
				MoveMouse(hwnd, x, y);
				return true;
			} 
		}
			return false;
		}

		
		public static void MoveMouseInsideHwnd(int hwnd,  int xPos, int yPos, RectPosition rctPos)
		{
			int xPixel = xPos;//10;
			int yPixel = yPos;//10;
			if (!rctPos.Equals(RectPosition.AnySpot))
			{
				xPixel = 4;
				yPixel = 4;
			}
			
			CenterMouseOn(hwnd);

			int width = 0;
			int height = 0;
			POINTAPI pa = new POINTAPI();

			GetWindowSize(hwnd, ref width, ref height);
			GetCursorPos(ref pa);

			switch (rctPos)
			{
				case RectPosition.LeftTop:
					xPixel = (pa.x - width/2) + xPixel % width ;
					yPixel = (pa.y - height/2) + yPixel % height;
					break;
				case RectPosition.LeftBottom:
					xPixel = (pa.x - width/2) + xPixel % width ;
					yPixel = (pa.y + height/2) - yPixel % height;
					break;
				case RectPosition.RightTop :
					xPixel = (pa.x + width/2) - xPixel % width ;
					yPixel = (pa.y - height/2) + yPixel % height;
					break;
				case RectPosition.RightBottom:
					xPixel = (pa.x + width/2) - xPixel % width ;
					yPixel = (pa.y + height/2) - yPixel % height;
					break;
				case RectPosition.MiddleTop :
					xPixel = (pa.x);
					yPixel = (pa.y - height/2) + yPixel % height;
					break;
				case RectPosition.MiddleBottom:
					xPixel = (pa.x);
					yPixel = (pa.y + height/2) - yPixel % height;
					break;
				case RectPosition.AnySpot:
					xPixel = (pa.x - width/2) + xPixel % width ;
					yPixel = (pa.y - height/2) + yPixel % height;
					break;
			}
			
			//if (rC>0)
			//{
			MoveMouse(hwnd, xPixel, yPixel);
			//}
		}

		public static void GetWindowSize(int iHandle, ref int wPixel, ref int hPixel)
		{
			int lrC = 0;
			RECT rCC = new RECT();
			lrC = GetWindowRect(iHandle, ref rCC);
			wPixel = rCC.Right - rCC.Left;
			hPixel = rCC.Bottom - rCC.Top;
		}

		
		public static void GetWindowFromPoint(ref int hwnd, ref StringBuilder winText, ref StringBuilder clsName, ref StringBuilder pText)
		{
			
			int parentHandle = 0;
			//int maxLen = 10000; //need to modify text chapter 4
			
			POINTAPI pnt = new POINTAPI();
			parentHandle = GetCursorPos(ref pnt);
			hwnd = WindowFromPoint(pnt.x, pnt.y);

			winText = new StringBuilder(maxLen);
			parentHandle = GetWindowText(hwnd, winText, maxLen);
 
			clsName = new StringBuilder(maxLen);
			parentHandle = GetClassName(hwnd, clsName, maxLen);

			pText = new StringBuilder(maxLen);
			parentHandle = GetParent(hwnd);
			parentHandle = GetWindowText(parentHandle, pText, maxLen);

		}

		
		public static void IndicateSelectedGUI(int hwnd)
		{
			int xSize = 0;
			int ySize = 0;
			
			RECT rSource = new RECT();
			GetWindowRect(hwnd, ref rSource);
			GetWindowSize(hwnd, ref xSize, ref ySize);
			
			SetRect(ref rSource, rSource.Left, rSource.Top-20 , rSource.Left + xSize, rSource.Top);
			
			DrawAnimatedRects(hwnd, IDANI_CLOSE | IDANI_CAPTION | IDANI_OPEN, ref rSource, ref rSource);
			
		}

		public static void HandleListBox(ref int hwnd, ref string winText, ref string clsName, ref string pText, string textEntry)
		{
			
			int r = FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			CenterMouseOn(hwnd);
			
			MoveMouseInsideHwnd(hwnd, 0, 0, RectPosition.RightBottom);
			ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
			
			MoveMouseInsideHwnd(hwnd, 0, 0, RectPosition.MiddleBottom);
			ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
		}

		public static void HandleTextBox(ref int hwnd, ref string winText, ref string clsName, ref string pText, string textEntry)
		{
			int r = FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			CenterMouseOn(hwnd);
			MoveMouseInsideHwnd(hwnd, 20, 10, RectPosition.AnySpot);
			ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
		}

		public static void HandleCommandButton(ref int hwnd, ref string winText, ref string clsName, ref string pText, string textEntry)
		{
			
			int r = FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			CenterMouseOn(hwnd);
			ClickMouse(MonkeyButtons.btcLeft, 0,0,0,0);
		}

		public static void SynchronizeWindow(ref int hwnd, ref string winText, ref string clsName, ref string pText)
		{
			int startSyn = DateTime.Now.Second;
			while (hwnd <=0)
			{
				FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);
				if (5 < DateTime.Now.Second - startSyn)
				{
					break;
				}
			}
		}

		//Chapter 9
		public static void HandleCosmeticGUIs(ref int hwnd, ref string winText, ref string clsName, ref string pText, string textEntry)
		{
			
			int r = FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			CenterMouseOn(hwnd);
			//ClickMouse(MonkeyButtons.btcLeft, 0,0,0,0);
		}

		//Chapter 10
		public static void HandleTextBoxWithTextEntry(ref int hwnd, ref string winText, ref string clsName, ref string pText, string textEntry)
		{
			SendKeys.Flush();
			SendKeys.SendWait(textEntry);
			
			return;
		}


		#region Private definitions
		private static GUIInfoType GetGUIInfoType(string winText, string winClass, string winTextParent)
		{
			if (winText != "" && winClass != "" & winTextParent == "")
				return GUIInfoType.guiTextClass;
			else if (winText != "" && winClass == "" & winTextParent != "")
				return GUIInfoType.guiTextParent;
			else if (winText != "" && winClass != "" & winTextParent == "")
				return GUIInfoType.guiTextClassParent;
			else if (winText == "" && winClass != "" & winTextParent != "")
				return GUIInfoType.guiClassParent; 
			return GUIInfoType.guiText;
		}


		private static void ResetGUIInfo(GUIInfoType guiInfoType, int hwnd, ref int hWndTarget,
			ref string windowText, ref string className, ref string ParentText, 
			StringBuilder sWindowText, StringBuilder sClassname, StringBuilder sParentText)
		{
			string clsStartedWith = "";
			if (className.IndexOf(".") >= 0)
			{
				clsStartedWith = className.Replace(className.Split('.')[className.Split('.').Length-1], "");
			}
			else
			{
				clsStartedWith = className;
			}
			if (guiInfoType == GUIInfoType.guiText)
			{
				if (sWindowText.ToString() == windowText)
				{
					hWndTarget = hwnd;
					className = sClassname.ToString();
					ParentText = sParentText.ToString();
					
				}
			}
			else if (guiInfoType == GUIInfoType.guiTextClass )
			{
				if (sWindowText.ToString() == windowText && sClassname.ToString().StartsWith(clsStartedWith))
				{
					hWndTarget = hwnd;
					ParentText = sParentText.ToString();
					
				}
			}
			else if (guiInfoType == GUIInfoType.guiTextParent)
			{
				if (sWindowText.ToString() == windowText && sParentText.ToString() == ParentText)
				{
					hWndTarget = hwnd;
					className = sClassname.ToString();
					
				}
			}
			else if (guiInfoType == GUIInfoType.guiTextClassParent)
			{
				
				if (sWindowText.ToString() == windowText && sClassname.ToString().StartsWith(clsStartedWith) && sParentText.ToString() == ParentText)
				{
					hWndTarget = hwnd;
					
				}
			}
			else if (guiInfoType == GUIInfoType.guiClassParent)
			{
				if (sClassname.ToString().StartsWith(clsStartedWith) && sParentText.ToString() == ParentText)
				{
					hWndTarget = hwnd;
					windowText = sWindowText.ToString();
					
				}
			}
		}
		#endregion
	}
}
