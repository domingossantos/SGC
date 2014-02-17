using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class Setor
    {
        private int cdSetor;

        public int CdSetor
        {
            get { return cdSetor; }
            set { cdSetor = value; }
        }

        private string nmSetor;

        public string NmSetor
        {
            get { return nmSetor; }
            set { nmSetor = value; }
        }

        private string dsCor;

        public string DsCor
        {
            get { return dsCor; }
            set { dsCor = value; }
        }
    }
}
