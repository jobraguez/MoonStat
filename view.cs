using System;

public class View
{
    private Controller controller;

    public View(Controller c)
    {
        controller = c;
    }

    // Método para exibir estatísticas na interface do usuário
    public void DisplayStatistics(ContentStatistics statistics)
    {
        // Assumindo que ContentStatistics tem um método ToString apropriado
        Console.WriteLine("Análise de Conteúdo Concluída:");
        Console.WriteLine(statistics.ToString());
    }

    // Método para exibir mensagens gerais
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    // Inicialização da View pode incluir outros setups de interface
    public void Initialize()
    {
        DisplayMessage("Bem-vindo ao Analisador de Conteúdo Web!");
    }
}
