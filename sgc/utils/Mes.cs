using System;
using System.Collections.Generic;


namespace sgc.utils
{
    public class Mes
    {
        private int id_mes;
        private String dia_ini;

        public String Dia_ini
        {
            get { return dia_ini; }
            set { dia_ini = value; }
        }
        private String dia_fim;

        public String Dia_fim
        {
            get { return dia_fim; }
            set { dia_fim = value; }
        }

        public Mes(int id, String ini, String fim) {
            Id_mes = id;
            dia_ini = ini;
            Dia_fim = fim;
        }

        public int Id_mes
        {
            get { return id_mes; }
            set { id_mes = value; }
        }
        

        

    }
}
