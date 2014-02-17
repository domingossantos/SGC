using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Modelos;
using DAO;
namespace BLL
{
    public class CorrentistaBLL
    {
        private Conexao oCon;
        private CorrentistaDAO oCorrentistaDao;
        public CorrentistaBLL(Conexao con)
        {
            this.oCon = con;
            oCorrentistaDao = new CorrentistaDAO(oCon.ObjCon);
        }

        public DataTable getCorrentistas(String argumento="") {
            oCon.ObjCon.Open();
            DataTable vDados = oCorrentistaDao.getCorrentistas(argumento);
            oCon.ObjCon.Close();
            return vDados;

        }

        public Correntista getCorrentista(String nrCpfCnpj) {
            oCon.ObjCon.Open();
            Correntista oCorrentista = oCorrentistaDao.getCorrentista(nrCpfCnpj);
            oCon.ObjCon.Close();
            return oCorrentista;
        }

        public void salvaCorrentista(Correntista oCorrentista, char op) {
            try
            {
                oCon.ObjCon.Open();
                if (op.Equals('I'))
                {
                    oCorrentistaDao.novoCorrentista(oCorrentista);
                }

                if (op.Equals('A'))
                {
                    oCorrentistaDao.salvaCorrentista(oCorrentista);
                }
                oCon.ObjCon.Close();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
