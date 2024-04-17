using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Controller
{
    private Model model;
    private View view;

    public Controller()
    {
        model = new Model();
        view = new View(this);
        model.ContentAnalyzed += Model_ContentAnalyzed; // Subscreve ao evento
    }

    private void Model_ContentAnalyzed(ContentStatistics statistics)
    {
        // Lógica para responder ao evento
        view.ExibirEstatisticas(statistics);
    }

    public void SolicitarAnaliseDeConteudo(string url)
    {
        model.ObterEAnalisarConteudo(url);
    }
}
