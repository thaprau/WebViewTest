using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewTest.HTML
{
    public class HtmlReportGenerator
    {
        HtmlDocument doc = new HtmlDocument();

        public HtmlReportGenerator()
        {
            addBaseTags();
        }

        public void Save(string path)
        {
            using (StreamWriter writetext = new StreamWriter(path))
            {
                doc.Save(writetext);
            }
        }

        private void addBaseTags()
        {
            doc.DocumentNode.AppendChild(doc.CreateElement("html"));
            var navigator = doc.DocumentNode.CreateNavigator();

            var htmlNode = doc.DocumentNode.SelectSingleNode("html");
            var headNode = doc.CreateElement("head");
            htmlNode.AppendChild(headNode);

            var link = doc.CreateElement("link");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "test/css");
            link.Attributes.Add("href", "style.css");
            link.Attributes.Add("media", "all");

            headNode.AppendChild(link);


            htmlNode.AppendChild(doc.CreateElement("body"));
        }

        public void AddTodTable(DataTable dataTable, string header = "")
        {
            // Get body element
            var bodyNode = doc.DocumentNode.SelectSingleNode("//body");
            var test = doc.DocumentNode.SelectSingleNode("html");

            // div for the table
            var tableDiv = doc.CreateElement("div");
            tableDiv.Attributes.Add("class", "table-div");

            var title = doc.CreateElement("p");
            title.Attributes.Add("class", "top-row");
            title.InnerHtml = header;
            tableDiv.AppendChild(title);

            var tableNode = doc.CreateElement("table");
            tableNode.AddClass("standard-table");
            tableNode.Attributes.Add("id", "vehicle-information");

            foreach (DataRow item in dataTable.Rows)
            {
                var tr = doc.CreateElement("tr");

                foreach (var item2 in item.ItemArray)
                {
                    var td = doc.CreateElement("td");
                    td.InnerHtml = item2.ToString();
                    tr.AppendChild(td);
                }
                tableNode.AppendChild(tr);
            }

            tableDiv.AppendChild(tableNode);


            bodyNode.AppendChild(tableDiv);


        }





    }
}
