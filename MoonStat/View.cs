
using System.Text.RegularExpressions;

namespace MoonStat
{
    //public class AnaliseEventArgs : EventArgs
    //{
    //    public String URL { get; set; }
    //}

    public partial class View : Form
    {
        public EventHandler<AnaliseEventArgs>? iniciarAnaliseEvent;
        public View()
        {
            InitializeComponent();
        }

        public void Ativar()
        {
            Application.Run(this);
            EcraDeBoasVindas();
        }

        public void ApresentarResultados(String resultados)
        {
            resultadosTextBox.Text = resultados;
        }

        public void AtualizarProgresso(String patamar)
        {
            progressoDaAnalise.Text = patamar;
        }

        public void EcraDeBoasVindas()
        {

        }

        private bool InputValido(String input)
        {
            if (input == null || input.Length == 0)
                return false;
            Regex urlRegex = new Regex(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
            if (!urlRegex.IsMatch(input))
                return false;
            return true;
        }

        private void iniciarAnalise_Click(object sender, EventArgs e)
        {
            String urlStr = inputURL.Text;

            if (InputValido(urlStr))
            {
                var arg = new AnaliseEventArgs() { URL = urlStr };

                if (iniciarAnaliseEvent != null)
                    iniciarAnaliseEvent(this, arg);
            } 
            else
            {
                MessageBox.Show("URL invalido");
            }

        }


    }
}
