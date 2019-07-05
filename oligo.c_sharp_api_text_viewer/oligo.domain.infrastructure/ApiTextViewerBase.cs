using System;
using System.Collections;
using System.IO;

namespace oligo.domain.infrastructure
{
    public class ApiTextViewerBase : IApiTextViewer
    {
        public SortedList DefinitionList { get; set; }
        public string FileName { get; set; }

        public ApiTextViewerBase()
        {
            DefinitionList = new SortedList();
            FileName = GetFilePath();
        }

        public int Count
        {
            get { return DefinitionList.Count; }

        }

        public void AddCSharpCode(string key, string data)
        {
            if (!DefinitionList.ContainsKey(key))
            {
                DefinitionList.Add(key, data);
            }
        }

        public string GetKey(int index)
        {
            if (index < DefinitionList.Count)
            {
                return (string) DefinitionList.GetKey(index);
            }

            return string.Empty;
        }

        public string GetCSharpSyntax(int index)
        {
            if (index < DefinitionList.Count)
            {
                return (string) DefinitionList.GetByIndex(index);
            }

            return string.Empty;
        }

        public virtual void ParseText()
        {

        }

        protected string GetFilePath()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(basePath, @"Resources\win32api.txt");
            return Path.GetFullPath(fullPath);
        }
    }
}
