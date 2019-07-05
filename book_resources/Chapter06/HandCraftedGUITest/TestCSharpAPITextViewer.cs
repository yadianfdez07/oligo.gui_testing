using System;
using GUITestLibrary;

namespace HandCraftedGUITest
{
	
	public class TestCSharpAPITextViewer
	{
		private string AppUT;
		private string TypeUT;
		private object CSharpAPITextViewerObj;

		public TestCSharpAPITextViewer()
		{
		}

		public TestCSharpAPITextViewer(string _appUT, string _typeUT)
		{
			AppUT = _appUT;
			TypeUT = _typeUT;
			CSharpAPITextViewerObj = StartAppUnderTest();

		}

		private object StartAppUnderTest()
		{
			return GUITestu.StartAUT(AppUT, TypeUT);
		}

		public void HandleListBox(ref int hwnd, ref string winText, ref string clsName, ref string pText)
		{
			
			int r =  GUITestActions.FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			GUITestActions.CenterMouseOn(hwnd);
			
			GUITestActions.MoveMouseInsideHwnd(hwnd, RectPosition.RightBottom);
			GUITestActions.ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
			
			GUITestActions.MoveMouseInsideHwnd(hwnd, RectPosition.MiddleBottom);
			GUITestActions.ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
		}

		public object VerifyField(string fldName)
		{
			return GUITestActions.VerifyField(CSharpAPITextViewerObj, fldName);
		}

		public void HandleTextBox(ref int hwnd, ref string winText, ref string clsName, ref string pText)
		{
			
			int r =  GUITestActions.FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			GUITestActions.CenterMouseOn(hwnd);
			GUITestActions.MoveMouseInsideHwnd(hwnd, RectPosition.MiddleTop);
			GUITestActions.ClickMouse(MonkeyButtons.btcLeft,0,0,0,0);
		}
		
		public void HandleCommandButton(ref int hwnd, ref string winText, ref string clsName, ref string pText)
		{
			
			int r = GUITestActions.FindGUILike(ref hwnd, 0, ref winText, ref clsName, ref pText);

			GUITestActions.CenterMouseOn(hwnd);
			GUITestActions.ClickMouse(MonkeyButtons.btcLeft, 0,0,0,0);
		}

	}
}
