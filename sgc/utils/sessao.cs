using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelos;


namespace sgc.utils
{
    public static class sessao
    {
        private static int nrPedido;
        
        public static int NrPedido
        {
            get { return sessao.nrPedido; }
            set { sessao.nrPedido = value; }
        }

        private static Processo processo;

        public static Processo Processo
        {
            get { return sessao.processo; }
            set { sessao.processo = value; }
        }

        private static Pedido pedido;

        public static Pedido Pedido
        {
            get { return sessao.pedido; }
            set { sessao.pedido = value; }
        }

        private static ItemPedido itemPedido;

        public static ItemPedido ItemPedido
        {
            get { return sessao.itemPedido; }
            set { sessao.itemPedido = value; }
        }

        private static Usuario usuarioSessao;

        public static Usuario UsuarioSessao
        {
            get { return sessao.usuarioSessao; }
            set { sessao.usuarioSessao = value; }
        }

        private static int nrCaixa;

        public static int NrCaixa
        {
            get { return nrCaixa; }
            set { nrCaixa = value; }
        }

        private static string pathIniFile;

        public static string PathIniFile
        {
            get { return pathIniFile; }
            set { pathIniFile = value; }
        }

        private static HistoricoCaixa historico;

        public static HistoricoCaixa Historico
        {
            get { return sessao.historico; }
            set { sessao.historico = value; }
        }

        private static string pathRelatorios;

        public static string PathRelatorios
        {
            get { return pathRelatorios; }
            set { pathRelatorios = value; }
        }

        private static int cdAtoPedido;

        public static int CdAtoPedido
        {
            get { return sessao.cdAtoPedido; }
            set { sessao.cdAtoPedido = value; }
        }

        private static int cdAtodeposito;

        public static int CdAtodeposito
        {
            get { return sessao.cdAtodeposito; }
            set { sessao.cdAtodeposito = value; }
        }

        private static string pathApp;

        public static string PathApp
        {
            get { return pathApp; }
            set { pathApp = value; }
        }
        private static string hostdb;

        public static string Hostdb
        {
            get { return sessao.hostdb; }
            set { sessao.hostdb = value; }
        }
        private static string userdb;

        public static string Userdb
        {
            get { return sessao.userdb; }
            set { sessao.userdb = value; }
        }
        private static string passdb;

        public static string Passdb
        {
            get { return sessao.passdb; }
            set { sessao.passdb = value; }
        }

        private static int idPedidoPagtoCorrentista;

        public static int IdPedidoPagtoCorrentista
        {
            get { return sessao.idPedidoPagtoCorrentista; }
            set { sessao.idPedidoPagtoCorrentista = value; }
        }

        public static bool PesquisaRemoto
        {
            get;
            set;
        }
        public static int IdImpressaoFicha { get; set; }
    }
}
