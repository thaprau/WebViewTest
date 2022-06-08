using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewTest.HTML
{
    public static class HtmlUtilities
    {
        public static HtmlNode AddMultipleAttributes(HtmlNode node)
        {
            return null;
        }

        public static HtmlNode CreateElement(HtmlDocument doc, string type, string cls, Dictionary<string, string> attr = null, string innerHtml = null)
        {
            var node = doc.CreateElement(type);

            node.AddClass(cls);

            if (attr != null)
            {
                foreach(KeyValuePair<string, string> entry in attr)
                {
                    node.Attributes.Add(entry.Key, entry.Value);
                }

            }

            if (innerHtml != null) node.InnerHtml = innerHtml;

           return node;
        }

    }
}
