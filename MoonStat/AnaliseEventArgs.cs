
namespace MoonStat
{
    public class AnaliseEventArgs : EventArgs
    {
        public string URL { get; set; } = string.Empty;  // JB Inicializado com string vazia
        public string Driver { get; set; } = "Chrome";  // JB Inicializado com string vazia
    }
}
