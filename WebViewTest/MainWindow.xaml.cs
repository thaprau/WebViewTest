using GalaSoft.MvvmLight.Command;
using Microsoft.Web.WebView2.Core;
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

namespace WebViewTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm;


        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainViewModel();
            mvm.PropertyChanged += Mvm_PropertyChanged;
            this.DataContext = mvm;

        }

        async private void Mvm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "URI")
            {
                CoreWebView2PrintSettings printSettings = null;

                var WebViewEnvironment = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync().ConfigureAwait(true);
                printSettings = WebViewEnvironment.CreatePrintSettings();
                printSettings.ShouldPrintBackgrounds = true;

                string ptdPath = mvm.URI.ToString().Replace("html", "pdf");

                await WebGui.CoreWebView2.PrintToPdfAsync(ptdPath, printSettings: printSettings);


                var test = "";
            }
        }
    }
}
