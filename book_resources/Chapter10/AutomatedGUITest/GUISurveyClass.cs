using System;
using System.Collections;
using System.Text;
//using System.Xml.Serialization;
using GUITestLibrary;

namespace AutomatedGUITest
{
	/// <summary>
	/// Summary description for GUISurveyClass.
	/// </summary>
	public class GUISurveyClass
	{
		public GUISurveyClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private int HandleUnderSurvey;
		public SortedList GUISortedList;
				
		public GUISurveyClass(int _hndlUnderSurvey)
		{
			HandleUnderSurvey = _hndlUnderSurvey;
			
		}

		public void StartGUISurvey()
		{
			GUISortedList = new SortedList();

			int width = 0;
			int height = 0;
			int surveyStep = 10;
			int maxLen = 128;
			GUITestActions.GetWindowSize(HandleUnderSurvey, ref width, ref height);
					
			for (int xPos = 0; xPos < width; xPos += surveyStep)
			{
				for (int yPos = 0; yPos < width; yPos += surveyStep)
				{
					GUITestActions.MoveMouseInsideHwnd(HandleUnderSurvey, xPos, yPos, RectPosition.AnySpot);

					GUITestUtility.GUIInfo GUISurvey = new GUITestUtility.GUIInfo();
					StringBuilder winText = new StringBuilder(GUISurvey.GUIText, maxLen);
					StringBuilder clsName =  new StringBuilder(GUISurvey.GUIClassName, maxLen);
					StringBuilder pText =  new StringBuilder(GUISurvey.GUIParentText, maxLen);
					
					GUITestActions.GetWindowFromPoint(ref GUISurvey.GUIHandle,ref winText, ref clsName, ref pText);
					
					GUISurvey.GUIText = winText.ToString();
					GUISurvey.GUIClassName = clsName.ToString();
					GUISurvey.GUIParentText = pText.ToString();
					try
					{
						GUISortedList.Add(GUISurvey.GUIHandle, GUISurvey);
					}
					catch
					{
					}
				}
			}
					
			return;
		}

	}
}

