using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPdf
{
    public class DocConvertFactory
    {
        public IDocConversion GetConverter(string extension)
        {
            switch (extension.ToLower())
            {
                case ".doc":
                    return new docConv();
                case ".pdf":
                    return new pdfConv();
                case ".txt":
                    return new textConv();
                default:
                    throw new ArgumentException("Invalid file format");
            }
        }
    }

}
