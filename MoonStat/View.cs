using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoonStat
{

    public partial class View : Form
    {
        public EventHandler<AnaliseEventArgs>? iniciarAnaliseEvent;
        public View()
        {
            InitializeComponent();
            comboBoxThemes.SelectedIndex = 0; // Set default theme
        }

        private void ComboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTheme = comboBoxThemes.SelectedItem.ToString();
            ApplyTheme(selectedTheme);
        }

        private void ApplyTheme(string theme)
        {
            if (theme == "Light")
            {
                this.BackColor = Color.White;
                inputURL.BackColor = Color.White;
                inputURL.ForeColor = Color.Black;
                botaoIniciarAnalise.BackColor = Color.LightGray;
                botaoIniciarAnalise.ForeColor = Color.Black;
                resultadosTextBox.BackColor = Color.White;
                resultadosTextBox.ForeColor = Color.Black;
                progressoDaAnalise.ForeColor = Color.Black;
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                labelTheme.ForeColor = Color.Black;
            }
            else if (theme == "Dark")
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                inputURL.BackColor = Color.FromArgb(28, 28, 28);
                inputURL.ForeColor = Color.White;
                botaoIniciarAnalise.BackColor = Color.FromArgb(28, 28, 28);
                botaoIniciarAnalise.ForeColor = Color.White;
                resultadosTextBox.BackColor = Color.FromArgb(28, 28, 28);
                resultadosTextBox.ForeColor = Color.White;
                progressoDaAnalise.ForeColor = Color.White;
                comboBox1.BackColor = Color.FromArgb(28, 28, 28);
                comboBox1.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                labelTheme.ForeColor = Color.White;
            }
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

        private bool IsValidURL(string url)
        {
            string pattern = @"^((http|https):\/\/)?(www\.)?([a-zA-Z0-9]+(\.[a-zA-Z]+)+.*)$";
            return Regex.IsMatch(url, pattern);
        }
        private void iniciarAnalise_Click(object sender, EventArgs e)
        {
            String urlStr = AdicionarPrefixoHTTP(inputURL.Text);
            String selectedriver = comboBox1.SelectedItem.ToString() ?? "chrome"; ;
            
            if (IsValidURL(urlStr) && Uri.IsWellFormedUriString(urlStr, UriKind.Absolute))
            {
                var arg = new AnaliseEventArgs() { URL = urlStr, Driver = selectedriver };

                if (iniciarAnaliseEvent != null)
                    iniciarAnaliseEvent(this, arg);
            }
            else
            {
                MessageBox.Show("URL invalido: Certifique-se que coloca o URL completo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "chrome";
        }
    }
}
