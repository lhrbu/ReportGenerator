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
    /// FormDatePickerItem.xaml 的交互逻辑
    /// </summary>
    public partial class FormDatePickerItem : Grid
    {
        public FormDatePickerItem()
        {
            InitializeComponent();
        }

        public string Header { get => (string)GetValue(HeaderProperty); set => SetValue(HeaderProperty, value); }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(FormDatePickerItem));

        public DateTime SelectedDateTime
        { get => (DateTime)GetValue(SelectedDateTimeProperty); set => SetValue(SelectedDateTimeProperty, value); }
        public static readonly DependencyProperty SelectedDateTimeProperty =
            DependencyProperty.Register(nameof(SelectedDateTime), typeof(DateTime), typeof(FormDatePickerItem));
    }
}
