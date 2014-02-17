using System;
using System.Text;

namespace Modelos
{
    public class TipoSelo
    {
        private int cdTipoSelo;

        public int CdTipoSelo
        {
            get { return cdTipoSelo; }
            set { cdTipoSelo = value; }
        }

        private String nrSerie;

        public String NrSerie
        {
            get { return nrSerie; }
            set { nrSerie = value; }
        }

        private String dsTipoSelo;

        public String DsTipoSelo
        {
            get { return dsTipoSelo; }
            set { dsTipoSelo = value; }
        }

        private double vlSelo;

        public double VlSelo
        {
            get { return vlSelo; }
            set { vlSelo = value; }
        }

        private int cdTipoDocumento;

        public int CdTipoDocumento
        {
            get { return cdTipoDocumento; }
            set { cdTipoDocumento = value; }
        }
    }
}
