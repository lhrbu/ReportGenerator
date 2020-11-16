using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ReportGenerator.Shared.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.IO;

namespace ReportGenerator.Shared.Services
{
    public class ReportGenerateService
    {
        private readonly DocXService _docXService;
        private string[] GetPropertiesName<TEntity>()=>
            typeof(TEntity).GetProperties().Select(property=>property.Name).ToArray();
        public ReportGenerateService(DocXService docXService)
        {
            _docXService = docXService;
        }

        public void InjectReport(DocX doc,Report report)
        {
            InjectData<ReportMetadata>(doc,report.ReportMetadata);
            InjectData<Application>(doc,report.Application);
            InjectData<Authorization>(doc,report.Authorization);
        }
        
        public void InjectData<TData>(DocX doc,TData data)
        {
            PropertyInfo[] properties = typeof(TData).GetProperties();
            foreach(PropertyInfo propertyInfo in properties)
            {
                dynamic? content = propertyInfo.GetValue(data);
                if(content is string dataString){
                    _docXService.TryReplaceTokenWithText(doc,propertyInfo.Name,dataString);
                }else if(content is DateTime dateTime)
                {
                    _docXService.TryReplaceTokenWithText(doc,propertyInfo.Name,dateTime.ToString("yyyy-MM-dd"));
                }
                else if(content is not null)
                {
                    _docXService.TryReplaceTokenWithText(doc,propertyInfo.Name,content.ToString());
                }
            }
        }

        public void GenerateReport(DocX templateDoc,Report report, string outputPath)
        {
            InjectReport(templateDoc,report);
            if(Path.GetExtension(outputPath)==".docx")
            { templateDoc.SaveAs(outputPath);}
            else
            { templateDoc.SaveAs($"{outputPath}.docx");}
        }

    }
}