using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class PessoaEscritura
    {
        private string nrCpfCnpj;

        public string NrCpfCnpj
        {
            get { return nrCpfCnpj; }
            set { nrCpfCnpj = value; }
        }


        private int idEscritura;

        public int IdEscritura
        {
            get { return idEscritura; }
            set { idEscritura = value; }
        }
        private int cdTipoPessoa;

        public int CdTipoPessoa
        {
            get { return cdTipoPessoa; }
            set { cdTipoPessoa = value; }
        }
    }
}
