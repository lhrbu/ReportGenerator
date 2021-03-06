using System;
using ReportGenerator.Shared.Services;
using ReportGenerator.Shared.Models;
using Prism.Mvvm;
using Microsoft.Win32;
using Xceed.Words.NET;
using System.Windows.Input;
using Prism.Commands;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;

namespace ReportGenerator.Client.Wpf.ViewModels
{
    public class ReportWindowVM:BindableBase
    {
        private readonly ReportGenerateService _reportGenerateService;
        private readonly JsonSerializerOptions _jsonSerializerOptions =
            new() { IgnoreNullValues = true,WriteIndented=true };
        public ReportWindowVM(ReportGenerateService reportGenerateService)
        { 
            _reportGenerateService = reportGenerateService;

            GenerateCommand = new(GenerateReport);
            ExportCommand = new(async () => await ExportAsync());
            ImportCommand = new(async () => await ImportAsync());
        }
        public ReportMetadata ReportMetadata { get=>_reportMetadata; set=>SetProperty(ref _reportMetadata,value); }
        private ReportMetadata _reportMetadata = new();
        public Application Application { get=>_application; set=>SetProperty(ref _application,value); }
        private Application _application = new();
        public Authorization Authorization {get=>_authorization;set=>SetProperty(ref _authorization,value);}
        private Authorization _authorization = new();

        public DelegateCommand GenerateCommand { get; }
        public DelegateCommand ExportCommand { get; }
        public DelegateCommand ImportCommand { get; }
        public void GenerateReport()
        {
            Mouse.SetCursor(Cursors.Wait);
            
            
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.DefaultExt = ".docx";
            saveFileDialog.ShowDialog();
            string reportPath = saveFileDialog.FileName;
            if(!string.IsNullOrEmpty(reportPath))
            {
                var handle = PendingBox.Show("In Generating", "Processing");
                try
                {
                    Report report = new()
                    {
                        ReportMetadata = ReportMetadata,
                        Application = Application,
                        Authorization = Authorization
                    };
                    using Stream stream = File.OpenRead("Template.docx");
                    using DocX doc = DocX.Load(stream);
                    _reportGenerateService.GenerateReport(doc, report, reportPath);
                }catch(Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString(),"Error");
                }
                finally
                { handle.Close();}
                MessageBoxX.Show("Generate sucessfully", "Success", configurations: new MessageBoxXConfigurations()
                { MessageBoxStyle = MessageBoxStyle.Modern });

            }
            Mouse.SetCursor(Cursors.Arrow);
        }
        public async ValueTask ExportAsync()
        {
            Mouse.SetCursor(Cursors.Wait);
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.ShowDialog();
            string exportPath = saveFileDialog.FileName;
            if (!string.IsNullOrEmpty(exportPath))
            {
                var handle = PendingBox.Show("In Exporting as Json", "Processing");
                try
                {
                    Report report = new()
                    {
                        ReportMetadata = ReportMetadata,
                        Application = Application,
                        Authorization = Authorization
                    };
                    using Stream stream = File.OpenWrite(exportPath);
                    await JsonSerializer.SerializeAsync(stream, report,_jsonSerializerOptions);
                }catch(Exception err){
                    System.Windows.MessageBox.Show(err.ToString(),"Error:");
                }finally
                {
                    handle.Close();
                }
                MessageBoxX.Show("Export sucessfully", "Success", configurations: new MessageBoxXConfigurations()
                { MessageBoxStyle = MessageBoxStyle.Modern });
            }
            Mouse.SetCursor(Cursors.Wait);
        }
        public async ValueTask ImportAsync()
        {
            Mouse.SetCursor(Cursors.Wait);
            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.ShowDialog();
            string importFile = openFileDialog.FileName;
            if(!string.IsNullOrEmpty(importFile))
            {
                var handle = PendingBox.Show("In Importing Json", "Processing");
                try
                {
                    using Stream stream = File.OpenRead(importFile);
                    Report report = (await JsonSerializer.DeserializeAsync<Report>(stream))!;
                    ReportMetadata = report.ReportMetadata;
                    Application = report.Application;
                    Authorization = report.Authorization;
                }
                finally
                { handle.Close();}
                MessageBoxX.Show("Import sucessfully", "Success", configurations: new MessageBoxXConfigurations()
                { MessageBoxStyle = MessageBoxStyle.Modern });
            }
            Mouse.SetCursor(Cursors.Arrow);
        }
    }
}