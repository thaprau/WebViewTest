using GalaSoft.MvvmLight.CommandWpf;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebViewTest.HTML;
using WebViewTest.HTML.Utils;

namespace WebViewTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Buttons
        public ICommand BtnTestCommand { get; set; }
        public ICommand BtnSaveCommand { get; set; }

        HtmlDocument doc = new();
        HtmlReportGenerator rg = new();

        public bool DoSaveReport { get; set;}



        public string URI { get; set; } = @"C:\RCMS\test2.html";
        private StringBuilder _sb = new StringBuilder();

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            BtnTestCommand = new RelayCommand<object>(BtnTestFunction);
            BtnSaveCommand = new RelayCommand<object>(BtnSaveFunction);
        }


        private bool WriteReportHtml2()
        {
            string[] thingsToAdd = { "item1", "item2", "item3" };
            string[] thingsToAdd2 = { "item1", "item2", "item3" };


            // Write head
            using (Head head = new Head(_sb))
            {

            }




            using (Table table = new Table(_sb, id: "some-id")) {
                table.StartHead();

                // Add table header row
                using (var thead = table.AddRow())
                {
                    thead.AddCell("Category Description");
                    thead.AddCell("Item Description");
                    thead.AddCell("Due Date");
                    thead.AddCell("Amount Budgeted");
                    thead.AddCell("Amount Remaining");
                }
                table.EndHead();

                foreach (var thing in thingsToAdd)
                {
                    using (var tr = table.AddRow(classAttributes: "testing"))
                    {
                        tr.AddCell(thing);
                        tr.AddCell(thing);
                        tr.AddCell(thing);
                    }
                }

                table.EndBody();
            }
            return true;
        }


        private void WriteReportHtml()
        {


            // Example of adding a table
            TableData td  = new();

            List<string> row1 = new List<string> { "item1.1", "item1.2" };
            List<string> row2 = new List<string> { "item2.1", "item2.2" };
            List<string> row3 = new List<string> { "item3.1", "item3.2" };


            td.AddTableRow(row1); 
            td.AddTableRow(row2); 
            td.AddTableRow(row3);


            rg.AddHeader();
            rg.AddTodTable(td, "Vehicle information");
            rg.AddTodTable(td, "Other information");
            rg.AddTodTable(td, "Final information");

            rg.AddLineGraph(null, null);
            rg.Save(URI);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(URI)));

        }


        private void BtnTestFunction(object obj)
        {
            WriteReportHtml();

        }


        private void BtnSaveFunction(object obj)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(DoSaveReport)));
        }


    }
}
