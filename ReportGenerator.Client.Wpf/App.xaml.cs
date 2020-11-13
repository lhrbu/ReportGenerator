using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Raccoon.DevKits.Wpf.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panuon.UI.Silver;
using ReportGenerator.Client.Wpf.ViewModels;
using ReportGenerator.Shared.Services;

namespace ReportGenerator.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application,IDIApplication
    {
        public IServiceProvider ServiceProvider { get; set; }=null!;
        public IConfiguration Configuration { get; set; }=null!;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<ReportWindowVM>();

            services.AddTransient<DocXService>();
            services.AddTransient<ReportGenerateService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try{
                base.OnStartup(e);
                this.OnStartupProxy<MainWindow>();
            }catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
