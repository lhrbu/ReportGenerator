using System;

namespace ReportGenerator.Shared.Models
{
    public record Report
    {
        public ReportMetadata ReportMetadata {get;init;}=null!;
        public Application Application {get;init;} = null!;
        public Authorization Authorization {get;init;}=null!;
    }
}