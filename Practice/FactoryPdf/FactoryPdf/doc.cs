using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPdf
{
    class docConv : IDocConversion
    {
        public string Extension { get; set; } = ".doc";
        public string Convert(string data)
        {
            return $"\nEntered data :{data} Converted to {Extension} format";
        }
    }
}
