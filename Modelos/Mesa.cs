using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class Mesa
    {
        private string nrCartao;

        public string NrCartao
        {
            get { return nrCartao; }
            set { nrCartao = value; }
        }
        private DateTime dtInclusao;

        public DateTime DtInclusao
        {
            get { return dtInclusao; }
            set { dtInclusao = value; }
        }
        private string dsLogin;

        public string DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
    }
}
