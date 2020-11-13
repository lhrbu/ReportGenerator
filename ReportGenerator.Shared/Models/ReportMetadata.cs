using System;

namespace ReportGenerator.Shared.Models
{
    public class ReportMetadata
    {
        public string? PDMNo {get;set;}
        public string? ReportNo {get;set;}
        public string? Name{get;set;}
        public DateTimeOffset PublishedDate { get; set; } = DateTimeOffset.Now;
    }
}