using System.Collections.Generic;
using System.Text;
namespace DocDefender
{
    public class Document
    {
        public string DocInfo { get; set; }
        public List<string> DocsFiles { get; set; }

        public Document(string docInfo, List<string> docsFiles){
            this.DocInfo = docInfo;
            this.DocsFiles = docsFiles;
        }
        
        public override string ToString(){
            short i = 0;
            StringBuilder allDocs = new StringBuilder();
            while (i < DocsFiles.Count){
                allDocs.Append(DocsFiles[i] + "\n");
                i++;
            }
            return $"{DocInfo}\n{allDocs.ToString()}";
        }
    }
}