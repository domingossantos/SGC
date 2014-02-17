using System;
using System.Text;


namespace Modelos
{
    public class ItemEscritura
    {
        private int idItemEscritura;

        public int IdItemEscritura
        {
            get { return idItemEscritura; }
            set { idItemEscritura = value; }
        }
        private string dsItemEscritura;

        public string DsItemEscritura
        {
            get { return dsItemEscritura; }
            set { dsItemEscritura = value; }
        }
        private double vlItemEscritura;

        public double VlItemEscritura
        {
            get { return vlItemEscritura; }
            set { vlItemEscritura = value; }
        }
        private char stItemEscritura;

        public char StItemEscritura
        {
            get { return stItemEscritura; }
            set { stItemEscritura = value; }
        }
        private char stRegistro;

        public char StRegistro
        {
            get { return stRegistro; }
            set { stRegistro = value; }
        }
    }
}
