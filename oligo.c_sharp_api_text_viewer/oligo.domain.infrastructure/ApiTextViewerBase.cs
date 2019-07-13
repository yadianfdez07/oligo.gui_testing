using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace oligo.domain.infrastructure
{
    public class ApiTextViewerBase : IApiTextViewer
    {
        public Dictionary<string, string> DefinitionList { get; set; }
        public string FileName { get; set; }

        public ApiTextViewerBase()
        {
            DefinitionList = new Dictionary<string, string>();
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
                return (string) DefinitionList.ElementAt(index).Key;
            }

            return string.Empty;
        }

        public string GetCSharpSyntax(int index)
        {
            if (index < DefinitionList.Count)
            {
                return (string) DefinitionList.ElementAt(index).Value;
            }

            return string.Empty;
        }

        public virtual void ParseText()
        {

        }

        public string GetFilePath()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(basePath, @"Resources\win32api.txt");
            return Path.GetFullPath(fullPath);
        }
    }
}
