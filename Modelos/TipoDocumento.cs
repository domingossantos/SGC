using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class TipoDocumento
    {
        private int cdTipoDocumento;

        public int CdTipoDocumento
        {
            get { return cdTipoDocumento; }
            set { cdTipoDocumento = value; }
        }

        private String nmTipoDocumento;

        public String NmTipoDocumento
        {
            get { return nmTipoDocumento; }
            set { nmTipoDocumento = value; }
        }

    }
}
