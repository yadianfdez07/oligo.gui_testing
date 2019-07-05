using System;
using System.Collections;

namespace CSharpAPITextViewer
{
	public class APITextViewer
	{
		public SortedList DefinitionList;
		public string filename;

		public APITextViewer(string m_filename)
		{
			DefinitionList = new SortedList();
			filename = m_filename;
		}

		public int Count
		{
			get
			{
				return DefinitionList.Count;
			}
		}

		public void AddCSharpCode(string key, string csCode)
		{
			if (!DefinitionList.ContainsKey(key))
				DefinitionList.Add(key, csCode);
		}
		
		public string GetKey(int index)
		{
			if (index < DefinitionList.Count)
			{
				return (string)DefinitionList.GetKey(index);
			}
			return "";
		}

		public string GetCSharpSyntax(int index)
		{
			if (index < DefinitionList.Count)
				return (string)DefinitionList.GetByIndex(index);
			return "";
		}
			
		public virtual void ParseText()
		{
		}
	}
}
