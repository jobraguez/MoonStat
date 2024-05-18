using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonStat
{
    internal class Controller
    {
        private View view;
        private Model model;
        public Controller()
        {
            view = new View();
            model = new Model(this, view);

            SubscreverEventos();
        }

        public void IniciarPrograma()
        {
            view.Ativar(); // apresentar mensagem de boas vindas
        }

        private void SubscreverEventos()
        {
            view.iniciarAnaliseEvent += iniciarAnalise;
            model.resultadosEvent += ApresentarResultados;
            model.notificacaoEvent += ApresentarNotificacao;
        }

        private void iniciarAnalise(object? sender, AnaliseEventArgs e)
        {
            model.IniciarAnalise(e.URL);
        }

        private void ApresentarResultados(object? sender, Resultados e) {
            if (view.InvokeRequired)
                view.Invoke(new Action(() => view.ApresentarResultados(e.resultados)));
            else
                view.ApresentarResultados(e.resultados);
        }

        private void ApresentarNotificacao(object? sender, Notificacao e)
        {
            if (view.InvokeRequired)
                view.Invoke(new Action(() => view.AtualizarProgresso(e.msg)));
            else
                view.AtualizarProgresso(e.msg);
        }
    }

}
