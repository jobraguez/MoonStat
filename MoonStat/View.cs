
using System.Text.RegularExpressions;

namespace MoonStat
{

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

            if (Uri.IsWellFormedUriString(urlStr, UriKind.Absolute))
            {
                var arg = new AnaliseEventArgs() { URL = urlStr };

                if (iniciarAnaliseEvent != null)
                    iniciarAnaliseEvent(this, arg);
            }
            else
            {
                MessageBox.Show("URL invalido: Certifique-se que coloca o URL completo");
            }

        }

        private void View_Load(object sender, EventArgs e)
        {

        }

        private void progressoDaAnalise_Click(object sender, EventArgs e)
        {

        }
    }
}
