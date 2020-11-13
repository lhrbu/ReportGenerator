using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportGenerator.Client.Wpf.Controls
{
    /// <summary>
    /// FormTextItem.xaml 的交互逻辑
    /// </summary>
    public partial class FormTextItem : Grid
    {
        public FormTextItem()
        {
            InitializeComponent();
        }
        public string Header { get=>(string)GetValue(HeaderProperty); set=>SetValue(HeaderProperty,value); }
        public static readonly DependencyProperty HeaderProperty = 
            DependencyProperty.Register(nameof(Header),typeof(string), typeof(FormTextItem));

        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(FormTextItem));
    }
}
