using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPdf
{
    public interface IDocConversion
    {
        string Convert(string data);
        string Extension { get; set; }
    }

}
