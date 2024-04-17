public class Model
{
    // Definição do delegado para o evento
    public delegate void ContentAnalyzedEventHandler(ContentStatistics statistics);

    // Evento baseado no delegado
    public event ContentAnalyzedEventHandler ContentAnalyzed;

    // Método que aciona o evento
    protected virtual void OnContentAnalyzed(ContentStatistics statistics)
    {
        ContentAnalyzed?.Invoke(statistics);
    }

    public void ObterEAnalisarConteudo(string url)
    {
        // Lógica para obter e analisar o conteúdo
        var statistics = new ContentStatistics(); // Suponha que a análise é feita aqui
        OnContentAnalyzed(statistics); // Aciona o evento
    }
}
