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
            controller = c;
            view = v;
            driver = new ChromeDriver();
        }

        public void IniciarAnalise(String url)
        {
            Task.Run(() =>
            {
                Notificar("A obter conteúdo da página web");
                var texto = AnalisarWeb(url); // Analisar o conteúdo da página web
                Notificar("A analisar conteúdo");
                string[] termos = DividirTexto(texto);
                int numTermos = ContarTotalTermos(termos);
                var termosMaisUsados = TermosMaisUsados(termos);
                // outras estatisticas relevantes
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
            driver.Navigate().GoToUrl(url); // Navegar para a página web
            return driver.FindElement(By.TagName("body")).Text; // Obter o texto da página
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
