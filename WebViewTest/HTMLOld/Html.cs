using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewTest.HTML
{
    public abstract class HtmlBase
    {
      private StringBuilder _sb;

      protected HtmlBase(StringBuilder sb)
      {
        _sb = sb;
      }

      public StringBuilder GetBuilder()
      {
        return _sb;
      }

      protected void Append(string toAppend)
      {
        _sb.Append(toAppend);
      }

      protected void AddOptionalAttributes(string className = "", string id = "", string colSpan = "")
      {

        if (!string.IsNullOrEmpty(id))
        {
          _sb.Append($" id=\"{id}\"");
        }
        if (!string.IsNullOrEmpty(className))
        {
          _sb.Append($" class=\"{className}\"");
        }
        if (!string.IsNullOrEmpty(colSpan))
        {
          _sb.Append($" colspan=\"{colSpan}\"");
        }
        _sb.Append(">");
      }
    }
}

