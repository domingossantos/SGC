using System;

namespace DAO
{
    public class Dados
    {
        private static String StrConexao;

        public static String strConexao
        {
           get { return Dados.StrConexao; }
           set { Dados.StrConexao = value; }
        }


        private static String strConRemoto;

        public static String StrConRemoto
        {
            get { return Dados.strConRemoto; }
            set { Dados.strConRemoto = value; }
        }

    }
}
