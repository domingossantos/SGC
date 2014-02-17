using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class AtualizaCartao
    {
        public AtualizaCartao(string cartao, DateTime data) {
            nrCartao = cartao;
            dtAssinatura = data;
        }

        private string nrCartao;

        public string NrCartao
        {
            get { return nrCartao; }
            set { nrCartao = value; }
        }
        private DateTime dtAssinatura;

        public DateTime DtAssinatura
        {
            get { return dtAssinatura; }
            set { dtAssinatura = value; }
        }

    }
}
