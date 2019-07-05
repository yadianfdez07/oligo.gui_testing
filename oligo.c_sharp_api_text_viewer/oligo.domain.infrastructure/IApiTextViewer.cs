using System.Collections;

namespace oligo.domain.infrastructure
{
    public interface IApiTextViewer
    {
        SortedList DefinitionList { get; set; }
        string FileName { get; set; }
        int Count { get; }
        void AddCSharpCode(string key, string data);
        string GetKey(int index);
        string GetCSharpSyntax(int index);
        void ParseText();
    }
}