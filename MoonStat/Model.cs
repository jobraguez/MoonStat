using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MoonStat
{
    class Notificacao : EventArgs
    {
        public String msg { get; set; }
    }

    class Resultados : EventArgs
    {
        public String resultados { get; set; }
    }

    internal class Model
    {
        private Controller controller;
        private View view;
        private IWebDriver driver;

        public EventHandler<Notificacao> notificacaoEvent;
        public EventHandler<Resultados> resultadosEvent;

        public Model(Controller c, View v)
        {
            // Desativar a janela de prompt do Chrome
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            // Desativar abertura da janela do Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");


            controller = c;
            view = v;
            driver = new ChromeDriver(driverService, options);
        }

        public void IniciarAnalise(String url)
        {
            Task.Run(() =>
            {
                Notificar("A obter conteúdo da página web");
                string[] termos = new string[0];
                int numTermos = 0;
                var termosMaisUsados = new Dictionary<string, int>(); //?
                try
                {
                    var texto = AnalisarWeb(url); // Analisar o conteúdo da página web
                    Notificar("A analisar conteúdo");
                    termos = DividirTexto(texto);
                    numTermos = ContarTotalTermos(termos);
                    termosMaisUsados = TermosMaisUsados(termos);
                    // outras estatisticas relevantes
                    EntregarResultados(numTermos, termosMaisUsados);
                    Notificar("Análise concluída");
                } catch (Exception e)
                {
                    Notificar(e.Message);
                }
                EntregarResultados(numTermos, termosMaisUsados);
            });
        }

        private void EntregarResultados(int numTermos, Dictionary<string, int> termosMaisUsados)
        {
            if (resultadosEvent != null)
            {
                var resultado = new Resultados();
                resultado.resultados = $"Número total de termos: {numTermos}\n";
                resultado.resultados += "Termos mais usados:\n";
                foreach (var kvp in termosMaisUsados.OrderByDescending(x => x.Value).Take(10)) // Mostra as 10 palavras mais usadas
                {
                    resultado.resultados += $"- {kvp.Key}: {kvp.Value}\n";
                }
                resultadosEvent(this, resultado);
            }
        }

        private void Notificar(String msg)
        {
            if (notificacaoEvent != null)
            {
                var notificacaoArg = new Notificacao();
                notificacaoArg.msg = msg;
                notificacaoEvent(this, notificacaoArg);
            }
        }

        private string AnalisarWeb(String url)
        {
            try
            {
                driver.Navigate().GoToUrl(url); // Navegar para a página web
                return driver.FindElement(By.TagName("body")).Text; // Obter o texto da página

            } catch (Exception e) { // Capturar exceções (ex: página web não responde, URL inválido, etc.
                if (e is WebDriverException || e is NoSuchElementException)
                {
                    throw new Exception("Erro ao obter conteúdo da página web: " + e.Message);
                } else if (e is UriFormatException)
                {
                    throw new Exception("URL inválida: \n" + e.Message);
                } else
                {
                    throw new Exception("Erro desconhecido: " + e.Message);
                }
            }
        }

        private string[] DividirTexto(string texto)
        {
            string[] termos = texto.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return termos;
        }

        private Dictionary<string, int> TermosMaisUsados(string[] termos)
        {
            Dictionary<string, int> termosContados = new Dictionary<string, int>();
            foreach (string termo in termos)
            {
                if (termosContados.ContainsKey(termo))
                {
                    termosContados[termo]++;
                }
                else
                {
                    termosContados[termo] = 1;
                }
            }
            return termosContados;
        }

        private int ContarTotalTermos(string[] termos)
        {
            return termos.Length;
        }

        // outras estatisticas relevantes

    }
}
