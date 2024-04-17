class Program
{
    static void Main(string[] args)
    {
        Controller controller = new Controller();
        controller.view.Initialize();  // Inicia a View
        controller.AnalyzeContent("http://example.com");  // Exemplo de URL para análise
    }
}
