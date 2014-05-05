using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAO
{
    public class Conexao
    {
        public Conexao(String str)
        {
            ObjCon = new SqlConnection(str);
        }
        
        private SqlConnection objCon;

        public SqlConnection ObjCon
        {
            get { return objCon; }
            set { objCon = value; }
        }
        


       
    }
}
