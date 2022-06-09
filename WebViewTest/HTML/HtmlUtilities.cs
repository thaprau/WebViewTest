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

        public static HtmlNode CreateElement(HtmlDocument doc, string type, string id = null, string cls = null, string innerHtml = null, string onclick = null, Dictionary<string, string> attr = null)
        {
            var node = doc.CreateElement(type);

            if (id != null) node.Attributes.Add("id", id);
            if (cls != null) node.Attributes.Add("class", cls);
            if (innerHtml != null) node.InnerHtml = innerHtml;
            if (onclick != null) node.Attributes.Add("onclick" ,onclick);

            if (attr != null)
            {
                foreach(KeyValuePair<string, string> entry in attr)
                {
                    node.Attributes.Add(entry.Key, entry.Value);
                }

            }


           return node;
        }

    }
}
