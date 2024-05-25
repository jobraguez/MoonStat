using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonStat
{
    public class AnaliseEventArgs : EventArgs
    {
        public string URL { get; set; } = string.Empty;  // JB Inicializado com string vazia
        public string Driver { get; set; } = "chrome";  // JB Inicializado com string vazia
    }
}
