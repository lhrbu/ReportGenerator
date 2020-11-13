using System;

namespace ReportGenerator.Shared.Models
{
    public class Authorization
    {
        public string? Author {get;set;}
        public string? AuthorDepartment { get; set; }
        public string? Reviewer {get;set;}
        public string? ReviewerDepartment { get; set; }
        public string? AuthorizedSignatory {get;set;}
        public string? AuthorizedDepartment { get; set; }
    }
}