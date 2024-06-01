﻿
namespace MoonStat
{
    internal class Controller
    {
        private View view;
        private Model model;

        private Logger logger;

        public Controller()
        {
            view = new View();
            model = new Model(this, view);

            logger = new Logger();

            SubscreverEventos();
        }

        public void IniciarPrograma()
        {
            view.Ativar(); // apresentar mensagem de boas vindas
            logger.LogInfo("CONTROLLER", "Programa iniciado");
        }

        private void SubscreverEventos()
        {
            view.iniciarAnaliseEvent += iniciarAnalise;
            model.resultadosEvent += ApresentarResultados;
            model.notificacaoEvent += ApresentarNotificacao;
        }

        private void iniciarAnalise(object? sender, AnaliseEventArgs e)
        {
            logger.LogInfo("CONTROLLER", "Iniciar análise");
            model.IniciarAnalise(e.URL, e.Driver);
        }

        private void ApresentarResultados(object? sender, Resultados e)
        {
            if (view.InvokeRequired)
                view.Invoke(new Action(() => view.ApresentarResultados(e.resultados)));
            else
                view.ApresentarResultados(e.resultados);
        }

        private void ApresentarNotificacao(object? sender, Notificacao e)
        {
            logger.LogInfo("CONTROLLER", "Apresentar notificação");
            if (view.InvokeRequired)
                view.Invoke(new Action(() => view.AtualizarProgresso(e.msg)));
            else
                view.AtualizarProgresso(e.msg);
        }
    }

}
