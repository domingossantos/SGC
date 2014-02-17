using System;
using System.Collections;
using System.Text;
using Modelos;

namespace sgc
{
    class controleAcesso
    {
        private static Usuario usuario;

        public static Usuario Usuario
        {
            get { return controleAcesso.usuario; }
            set { controleAcesso.usuario = value; }
        }

        private static ArrayList menu;

        public static ArrayList Menu
        {
            get { return controleAcesso.menu; }
            set { controleAcesso.menu = value; }
        }



    }
}
