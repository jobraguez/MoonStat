using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EventHandler<Notificacao> notificacaoEvent;
        public EventHandler<Resultados> resultadosEvent;

        public Model(Controller c, View v)
        {
            controller = c;
            view = v;
        }

        public void IniciarAnalise(String url)
        {
            Task.Run(() =>
            {
                Notificar("A obter conteúdo da página web");
                AnalisarWeb();
                Notificar("A analisar conteúdo");
                TermosMaisUsados();
                ContarPalavras();
                EntregarResultados();
            });
        }

        private void EntregarResultados()
        {
            if (resultadosEvent != null)
            {
                var resultado = new Resultados();
                resultado.resultados = "Estatísticas incríveis";
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

        private void AnalisarWeb()
        {
            Thread.Sleep(3000);
        }


        private void TermosMaisUsados()
        {
            Thread.Sleep(3000);
        }


        private void ContarPalavras()
        {
            Thread.Sleep(3000);
        }

        // outras estatisticas relevantes

    }
}
