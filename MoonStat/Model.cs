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
        public string msg { get; set; } = string.Empty;  // JB Inicializado com string vazia
    }

    class Resultados : EventArgs
    {
        public string resultados { get; set; } = string.Empty;  // JB Inicializado com string vazia
    }

    internal class Model
    {
        private Controller controller;
        private View view;
        private IWebDriver driver;

        public EventHandler<Notificacao>? notificacaoEvent; // JB iNSERI ?
        public EventHandler<Resultados>? resultadosEvent; // JB iNSERI ?

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
                    Logger.LogInfo("Conteúdo obtido, iniciando análise do texto."); // JB

                    termos = DividirTexto(texto);
                    numTermos = ContarTotalTermos(termos);
                    Logger.LogInfo($"Obteve {numTermos} termos."); // JB

                    termosMaisUsados = TermosMaisUsados(termos);
                    Logger.LogInfo($"Os termos mais usados foram calculados."); // JB

                    // outras estatisticas relevantes
                    EntregarResultados(numTermos, termosMaisUsados);
                    Notificar("Análise concluída");
                    Logger.LogInfo("Análise concluída para a URL: " + url); // JB
                } catch (Exception e)
                {
                    Notificar(e.Message);
                    
                }
                EntregarResultados(numTermos, termosMaisUsados);
            });
        }

        private void Notificar(String msg) // JB ALTEREI
        {
            notificacaoEvent?.Invoke(this, new Notificacao { msg = msg });
        }

        private void EntregarResultados(int numTermos, Dictionary<string, int> termosMaisUsados)
        {
            if (resultadosEvent != null)
            {
                var resultado = new Resultados();
                resultado.resultados = $"Número total de termos: {numTermos}\n"; // JB ALTEREI
                foreach (var kvp in termosMaisUsados.OrderByDescending(x => x.Value).Take(10))
                {
                    resultado.resultados += $"- {kvp.Key}: {kvp.Value}\n";
                }
                resultadosEvent?.Invoke(this, resultado);
            }
        }



        private string AnalisarWeb(String url)
{
    try
    {
        driver.Navigate().GoToUrl(url); // Navegar para a página web
        Logger.LogInfo("Navegação para URL bem-sucedida: " + url); // JB
        return driver.FindElement(By.TagName("body")).Text; // Obter o texto da página
    }
    catch (Exception e)
    {
        // Loga erro específico com base no tipo de exceção
        if (e is WebDriverException || e is NoSuchElementException)
        {
            Logger.LogError("Erro ao obter conteúdo da página web para a URL " + url + ": " + e.Message); // JB
            throw new Exception("Erro ao obter conteúdo da página web: " + e.Message);
        }
        else if (e is UriFormatException)
        {
            Logger.LogError("Formato de URL inválido para a URL " + url + ": " + e.Message); // JB
            throw new Exception("URL inválida: \n" + e.Message);
        }
        else
        {
            Logger.LogError("Erro desconhecido ao acessar a URL " + url + ": " + e.Message); // JB
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
