using System;
using System.Text;

namespace Modelos
{
    public class Menu
    {
        private int cdMenu;

        public int CdMenu
        {
            get { return cdMenu; }
            set { cdMenu = value; }
        }

        private String nmMenu;

        public String NmMenu
        {
            get { return nmMenu; }
            set { nmMenu = value; }
        }

        private String dsMenu;

        public String DsMenu
        {
            get { return dsMenu; }
            set { dsMenu = value; }
        }

        private String dsAcessoRapido;

        public String DsAcessoRapido
        {
            get { return dsAcessoRapido; }
            set { dsAcessoRapido = value; }
        }


    }
}
