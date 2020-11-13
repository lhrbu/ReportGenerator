using System;
using ReportGenerator.Shared.Services;
using ReportGenerator.Shared.Models;
using Prism.Mvvm;

namespace ReportGenerator.Client.Wpf.ViewModels
{
    public class ReportWindowVM
    {
        private readonly ReportGenerateService _reportGenerateService;
        public ReportWindowVM(ReportGenerateService reportGenerateService)
        { _reportGenerateService = reportGenerateService;}
        public ReportMetadata ReportMetadata{get;set;} = new();
        public Application Application {get;set;} = new();
        public Authorization Authorization {get;set;} = new();
    }
}