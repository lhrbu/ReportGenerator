using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ReportGenerator.Shared.Services
{
    public class DocXService
    {
        public string WrapTokenInDoc(string token)=>$"${{{token}}}";
        public bool TryReplaceTokenWithText(DocX doc,string token,string? content)
        {
            if(content is null){return false;}
            string tokenRepesenctInDoc = WrapTokenInDoc(token);
            IEnumerable<Paragraph> paragraphs = doc.Paragraphs.Where(item => 
                item.Text.Contains(tokenRepesenctInDoc));
            if(paragraphs.Count()==0){return false;}

            foreach(Paragraph paragraph in paragraphs)
            { paragraph.ReplaceText(tokenRepesenctInDoc, content); }
            return true;
        }
    }
}