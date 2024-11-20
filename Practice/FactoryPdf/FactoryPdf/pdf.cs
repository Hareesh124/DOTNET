using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPdf
{
    internal class pdfConv : IDocConversion
    {
        public string Extension { get; set; } = ".pdf";

        public string Convert(string data)
        {
            return $"\nEntered data :{data} Converted to {Extension}";
        }
    }
}
