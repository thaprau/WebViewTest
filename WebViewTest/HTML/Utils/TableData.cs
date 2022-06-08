using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewTest.HTML.Utils
{
    public class TableData
    {
         List<List<string>> _data { get; } = new List<List<string>>();

        public string Title { get; set;}

        public List<List<string>> Rows { get  {return _data;}}


        public void AddTableRow(List<string> rowData)
        {
            _data.Add(rowData);
        }

    }
}
