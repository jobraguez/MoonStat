using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

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
        private IWebDriver? driver;

        private Logger logger;

        public EventHandler<Notificacao>? notificacaoEvent; // JB iNSERI ?
        public EventHandler<Resultados>? resultadosEvent; // JB iNSERI ?

        public Model(Controller c, View v)
        {
            logger = new Logger();

            controller = c;
            view = v;

        }

        public void IniciarAnalise(string url, string driver)
        {
            Task.Run(() =>
            {
                Notificar("A obter conteúdo da página web");
                string[] termos = [];
                int numTermos = 0;
                var termosMaisUsados = new Dictionary<string, int>();
                try
                {
                    var texto = AnalisarWeb(url, driver); // Analisar o conteúdo da página web
                    Notificar("A analisar conteúdo");
                    logger.LogInfo("MODEL", "Conteúdo obtido, iniciando análise do texto.");

                    termos = DividirTexto(texto);
                    numTermos = ContarTotalTermos(termos);
                    logger.LogInfo("MODEL", $"Obteve {numTermos} termos."); // JB

                    termosMaisUsados = TermosMaisUsados(termos);
                    logger.LogInfo("MODEL", $"Os termos mais usados foram calculados."); // JB

                    EntregarResultados(numTermos, termosMaisUsados);
                    Notificar("Análise concluída");
                    logger.LogInfo("MODEL", "Análise concluída para a URL: " + url); // JB
                }
                catch (Exception e)
                {
                    Notificar(e.Message);
                    logger.LogError("MODEL", e.Message);
                }
                EntregarResultados(numTermos, termosMaisUsados);
            });
        }

        private void Notificar(string msg) // JB ALTEREI
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

        private string AnalisarWeb(string url, string d)
        {
            
            try
            {
                logger.LogInfo("MODEL", "Iniciando o Driver: " + d);

                if (d == "Chrome")
                {
                    // Desativar a janela de prompt do Chrome
                    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;

                    // Desativar abertura da janela do Chrome
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");

                    chromeDriverService.HideCommandPromptWindow = true;

                    driver = new ChromeDriver(chromeDriverService, options);
                }
                else if (d == "Firefox")
                {
                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                    firefoxDriverService.HideCommandPromptWindow = true;

                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArgument("--headless");

                    driver = new FirefoxDriver(firefoxDriverService, options);
                }
                else if (d == "Edge")
                {
                    var edgeDriverService = EdgeDriverService.CreateDefaultService();
                    edgeDriverService.HideCommandPromptWindow = true;

                    EdgeOptions options = new EdgeOptions();
                    options.AddArgument("--headless");

                    driver = new EdgeDriver(edgeDriverService, options);
                }
                else
                {
                    logger.LogError("MODEL", "Driver não suportado: " + d);
                    throw new Exception("Driver "+ d +" não suportado");
                }
                
            }
            catch (Exception e)
            {
                logger.LogError("MODEL", "Erro ao iniciar o Driver: " + e.Message); // JB
                throw new Exception("Erro ao iniciar o Driver: " + e.Message);
            }

            try
            {
                driver.Navigate().GoToUrl(url); // Navegar para a página web
                logger.LogInfo("MODEL", "Navegação para URL bem-sucedida: " + url); // JB
                return driver.FindElement(By.TagName("body")).Text; // Obter o texto da página
            }
            catch (Exception e)
            {
                // Loga erro específico com base no tipo de exceção
                if (e is WebDriverException || e is NoSuchElementException)
                {
                    logger.LogError("MODEL", "Erro ao obter conteúdo da página web para a URL " + url + ": " + e.Message); // JB
                    throw new Exception("Erro ao obter conteúdo da página web: " + e.Message);
                }
                else if (e is UriFormatException)
                {
                    logger.LogError("MODEL", "Formato de URL inválido para a URL " + url + ": " + e.Message); // JB
                    throw new Exception("URL inválida: \n" + e.Message);
                }
                else
                {
                    logger.LogError("MODEL", "Erro desconhecido ao acessar a URL " + url + ": " + e.Message); // JB
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
    }
}
