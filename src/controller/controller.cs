public class Controller
{
    private Model model;
    private View view;

    public Controller()
    {
        model = new Model();
        view = new View(this);
        // Inscreve-se no evento do Model
        model.ContentAnalyzed += HandleContentAnalyzed;
    }

    // Manipulador de evento para quando o conteúdo é analisado
    private void HandleContentAnalyzed(ContentStatistics statistics)
    {
        // Atualiza a view com as novas estatísticas
        view.DisplayStatistics(statistics);
    }

    // Solicitar análise de conteúdo
    public void AnalyzeContent(string url)
    {
        model.ObterEAnalisarConteudo(url);
    }
}
