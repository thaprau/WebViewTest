using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebViewTest.HTML.Utils;

namespace WebViewTest.HTML
{
    public class HtmlReportGenerator
    {
        HtmlDocument doc = new HtmlDocument();
        HtmlNode _htmlNode;
        HtmlNode _bodyNode;


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
            _htmlNode = doc.CreateElement("html");
            doc.DocumentNode.AppendChild(_htmlNode);

            var headNode = doc.CreateElement("head");
            _htmlNode.AppendChild(headNode);

            // Add style link
            var link = doc.CreateElement("link");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("href", "style.css");
            link.Attributes.Add("media", "all");

            headNode.AppendChild(link);

            _bodyNode = doc.CreateElement("body");
            _htmlNode.AppendChild(_bodyNode);
        }

        public void AddTodTable(TableData dataTable, string header = "")
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

            foreach (var row in dataTable.Rows)
            {
                var tr = doc.CreateElement("tr");

                foreach (var value in row)
                {
                    var td = doc.CreateElement("td");
                    td.InnerHtml = value.ToString();
                    tr.AppendChild(td);
                }
                tableNode.AppendChild(tr);
            }

            tableDiv.AppendChild(tableNode);


            bodyNode.AppendChild(tableDiv);
        }

        public void AddHeader()
        {
            var divTopHeader = doc.CreateElement("div");
            divTopHeader.Attributes.Add("class", "top-header");

            divTopHeader.AppendChild(HtmlUtilities.CreateElement(doc, "div", "header-item", innerHtml:"ER-1"));

            var h1 = HtmlUtilities.CreateElement(doc, "div", "header-item");
            h1.AppendChild(HtmlUtilities.CreateElement(doc, "h1", "title-item", innerHtml: "Test Object Specification"));
            h1.AppendChild(HtmlUtilities.CreateElement(doc, "h2", "sub-title-item", innerHtml: "2022-05-30 11:11"));
            h1.AppendChild(HtmlUtilities.CreateElement(doc, "p", "sub-subtitle-item", innerHtml: "RCMS 1.9.8"));
            divTopHeader.AppendChild(h1);

            divTopHeader.AppendChild(HtmlUtilities.CreateElement(doc, "div", "header-item"));
            divTopHeader.AppendChild(HtmlUtilities.CreateElement(doc, "div", "header-item"));

            _bodyNode.AppendChild(divTopHeader);
        }
    }
}
