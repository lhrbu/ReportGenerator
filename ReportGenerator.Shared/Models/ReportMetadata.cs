using System;

namespace ReportGenerator.Shared.Models
{
    public class ReportMetadata
    {
        public string? PDMNo { get; set; }
        public string? TestNo {get;set;}
        public string? Name{get;set;}
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}