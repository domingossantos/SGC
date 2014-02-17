using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using DAO;


namespace BLL
{
    public class SelosBLL
    {
        private Conexao con;
        private SelosDAO seloDAO;
        private TipoSeloDAO tipoSeloDAO;
        private TipoDocumentoDAO tipoDocumentoDAO;
        public String sql;

        public SelosBLL(Conexao c)
        {
            con = c;
            seloDAO = new SelosDAO(con.ObjCon);
            tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
            tipoDocumentoDAO = new TipoDocumentoDAO(con.ObjCon);
        }

        public void incluir(int inicio, int final, int tipo)
        {
            if (inicio > final)
            {
                throw new Exception("Selo final deve ser maior que o inicial!");
            }
            try
            {
                con.ObjCon.Open();
                seloDAO.addSelos(inicio, final, tipo);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getSelos(int inicio, int fim, int tipo)
        {
            try
            {
                con.ObjCon.Open();

                String filtro = " where s.nrSelo between " + inicio + " and " + fim + " and s.cdTipoSelo = " + tipo;
                DataTable dt = seloDAO.getSelos(filtro);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getTipoSelos()
        {
            try
            {
                con.ObjCon.Open();
                DataTable dt = tipoSeloDAO.getTipoSelos();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getSelos()
        {
            try
            {
                con.ObjCon.Open();
                DataTable dt = seloDAO.getSelos();
             
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getTipoDocumentos()
        {
            try
            {
                con.ObjCon.Open();
                DataTable dt = tipoDocumentoDAO.getTiposDocumentos();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getSelosUsuario(string dsLogin = "", string dtInicio = "", string dtFim = "",string st = "", int nrSelo = 0 )
        {
            try
            {
                con.ObjCon.Open();

                string where = " where 1 = 1 ";

                if (!dsLogin.Equals(""))
                {
                    where += " and s.dsLogin = '" + dsLogin + "'";
                }

                if (!dtInicio.Equals(""))
                {
                    where += "and s.dtLancamento >= '" + dtInicio + " 00:00:00'";
                }
                if (!dtFim.Equals(""))
                {
                    where += "and s.dtLancamento <= '" + dtFim + " 23:59:59'";
                }

                if (!st.Equals("T"))
                {
                    where += "and s.stSelo = '" + st + "'";
                }

                if (nrSelo > 0) {
                    where += "and i.nrSelo = "+ nrSelo;
                }

                DataTable dt = seloDAO.getHistoricoSelos(where);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Selo getSelo(int num,int tipo)
        {
            try
            {
                con.ObjCon.Open();

                Selo s = seloDAO.getSelo(num, tipo);
             
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }



        public void salvaSelo(Selo selo, SqlTransaction trans = null) {
            try
            {
                con.ObjCon.Open();

                seloDAO.salvaSelo(selo,trans);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void mudaStatusSelo(int nrSelo, int tipo, char status, SqlTransaction trans = null)
        {
            try
            {
                con.ObjCon.Open();

                seloDAO.mudarStatusSelo(nrSelo,tipo,status, trans);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable historicoMovimentoSelos(String dtInicio, String dtFim, String login, String nrSeloInicio, String nrSeloFim,String tipo) {
            try
            {
                con.ObjCon.Open();

                DataTable dt = seloDAO.historicoMovimentoSelos(dtInicio, dtFim, login, nrSeloInicio, nrSeloFim, tipo);
                this.sql = seloDAO.sql;

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Selo getSeloUsuario(string dsLogin, int cdTipo) {
            try
            {
                con.ObjCon.Open();
                Selo s = seloDAO.getSeloUsuario(dsLogin, cdTipo);
             
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Selo getSeloTipo(int cdTipo)
        {
            try
            {
                con.ObjCon.Open();
                Selo s = seloDAO.getSeloTipo(cdTipo);

                return s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public TipoSelo getTipoSelo(int tipo)
        {
            try
            {
                con.ObjCon.Open();
                TipoSeloDAO tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
                TipoSelo s = tipoSeloDAO.getTipoSelo(tipo);
             
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public TipoSelo getTipoSeloPorDocumento(int tipo)
        {
            try
            {
                con.ObjCon.Open();
                TipoSeloDAO tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
                TipoSelo s = tipoSeloDAO.getTipoSeloPorDocumento(tipo);
             
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void setSelosUsuario(int inicio,int fim, String login,int tipo)
        {
            con.ObjCon.Open();
            try
            {
                seloDAO.atribuirSeloUsuario(inicio, fim, tipo, login);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar selos " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Boolean checaStatusSelos(DataTable dados)
        {
            Boolean resultado = false;

            DataView dvDados = new DataView(dados);
            DataRow drDados;
            for (int i = 0; i < dvDados.Count; i++)
            {
                drDados = dvDados[i].Row;
                 
                if (drDados["stSelo"].ToString().Equals("T"))
                {
                    resultado = true;
                }
                if (drDados["stSelo"].ToString().Equals("U"))
                {
                    resultado = true;
                }
                if (drDados["stSelo"].ToString().Equals("R"))
                {
                    resultado = true;
                }

                /*if (!drDados["dsLogin"].ToString().Equals("")) {
                    resultado = true;
                }*/
            }
            return resultado;
        }

        public void transfereSelos(int inicio, int fim, int tipo, int origem)
        {
            con.ObjCon.Open();
            try
            {
                seloDAO.transferirSelos(inicio, fim, tipo, origem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao transferir selos " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void apagaSelos(int inicio, int fim, int tipo)
        {
            con.ObjCon.Open();
            try
            {
                seloDAO.apagaSelos(inicio, fim, tipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao apagar selos " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }



        
    }
}
