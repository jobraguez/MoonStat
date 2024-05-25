
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
        }

        public void ApresentarResultados(String resultados)
        {
            resultadosTextBox.Text = resultados;
        }

        public void AtualizarProgresso(String patamar)
        {
            progressoDaAnalise.Text = patamar;
        }

        private String AdicionarPrefixoHTTP(String url)
        {
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return "http://" + url;
            }
            return url;
        }

        private void iniciarAnalise_Click(object sender, EventArgs e)
        {
            String urlStr = AdicionarPrefixoHTTP(inputURL.Text);
            String selectedriver = comboBox1.SelectedItem.ToString();
            if (selectedriver == null)
            {
                selectedriver = "chrome";
            }

            if (Uri.IsWellFormedUriString(urlStr, UriKind.Absolute))
            {
                var arg = new AnaliseEventArgs() { URL = urlStr, Driver = selectedriver };

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
            comboBox1.SelectedItem = "chrome";
        }
    }
}
