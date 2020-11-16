using System;

namespace ReportGenerator.Shared.Models
{
    public class Application
    {
        public string? ApplicantName { get; set; }
        public string? SamplePhase {get;set;}
        public string? TestReason {get;set;}
        public string? OEMName {get;set;}
        public string? ProjectName { get; set; }
        public string? VehicleModel { get; set; }
        public string? OEMPartNoSummary { get; set; }
        public string? InternalPartNoSummary { get; set; }
    }
}