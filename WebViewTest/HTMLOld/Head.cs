using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewTest.HTML
{
    public class Head : HtmlBase, IDisposable
    {
        public Head(StringBuilder sb, string classAttributes = "", string id = "") : base(sb)
        {
            Append("<table");
            AddOptionalAttributes(classAttributes, id);
        }
         
        public void AddLink(string rel = "", string type="", string href="", string media="", Dictionary<string, string> extra_args=null)
        {
            Append("<link");

            if (!string.IsNullOrEmpty(rel)) Append($" rel={rel}");
            if (!string.IsNullOrEmpty(type)) Append($" type={type}");
            if (!string.IsNullOrEmpty(href)) Append($" href={href}");
            if (!string.IsNullOrEmpty(media)) Append($" media={media}");

            if (extra_args != null)
            {
                foreach (var entry in extra_args)
                {
                    if (!string.IsNullOrEmpty(entry.Value)) Append($" {entry.Key}={entry.Value}");
                }
            }


            Append("/>");


            


        }
        public void AddScript(string rel = "", string type = "", string href = "", string media = "", Dictionary<string, string> extra_args = null)
        {
            Append("<script");



            Append("/>");
        }

        public void Dispose()
        {
            Append("</Head>");
        }
    }
}
