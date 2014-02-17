using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Modelos;
using DAO;

namespace BLL
{
    public class AtoOperacaoBLL
    {
        Conexao con;

        public AtoOperacaoBLL(Conexao objCon)
        {
            this.con = objCon;
        }

        public DataTable listagem(int uso)
        {
            try
            {
                con.ObjCon.Open();
                AtoOperacaoDAO ato = new AtoOperacaoDAO(this.con.ObjCon);
                string where = "";
                if (uso != 0) {
                    where = "and cdUso = " + uso.ToString();
                }


                DataTable dados = ato.getAtosOperacoes(where);

                return dados;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable listaTipoDocumento()
        {
            try
            {
                con.ObjCon.Open();
                TipoDocumentoDAO tipoDoc = new TipoDocumentoDAO(con.ObjCon);
                DataTable dados = tipoDoc.getTiposDocumentos();
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable listaAtosPorTipo(int tipo,int idAto,  String status)
        {
            try
            {
                con.ObjCon.Open();
                AtoOperacaoDAO ato = new AtoOperacaoDAO(this.con.ObjCon);
                String where = " and a.cdTipoDocumento = " + tipo.ToString();

                if (status != null) { 
                    where += " and stRegistro = '"+status+"'";
                }

                if (idAto > 0) {
                    where += " or (a.cdAto = " + idAto + ")";
                }

                DataTable dados = ato.getAtosOperacoes(where);

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public AtoOperacao getAto(int cdAto)
        {
            try
            {
                AtoOperacaoDAO atoDAO = new AtoOperacaoDAO(this.con.ObjCon);
                this.con.ObjCon.Open();
                AtoOperacao ato = atoDAO.getAtoOperacao(cdAto);

                return ato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                this.con.ObjCon.Close();
            }
        }

        public AtoOperacao getAto(String cdPlano)
        {
            try
            {
                AtoOperacaoDAO atoDAO = new AtoOperacaoDAO(this.con.ObjCon);
                this.con.ObjCon.Open();
                AtoOperacao ato = atoDAO.getAtoOperacaoPlano(cdPlano);

                return ato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.ObjCon.Close();
            }
        }

        public void incluir(AtoOperacao ato)
        {
            try
            {
                AtoOperacaoDAO atoADO = new AtoOperacaoDAO(this.con.ObjCon);
                this.con.ObjCon.Open();
                if (ato.DsAto.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição é obrigatório");
                }

                if (ato.CdTipoDocumento == null)
                {
                    throw new Exception("Campo Tipo Documento é obrigatório");
                }

                if (ato.CdUso == null)
                {
                    throw new Exception("Campo Uso é obrigatório");
                }

                atoADO.addAtoOperacao(ato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.ObjCon.Close();
            }
        }

        public void excluir(int codigo)
        {
            try
            {
                con.ObjCon.Open();
                AtoOperacaoDAO ato = new AtoOperacaoDAO(this.con.ObjCon);
                ato.delAtoOperacao(codigo);
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

        public void salva(AtoOperacao ato)
        {
            try
            {
                AtoOperacaoDAO atoADO = new AtoOperacaoDAO(this.con.ObjCon);
                this.con.ObjCon.Open();
                if (ato.DsAto.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição é obrigatório");
                }

                if (ato.CdTipoDocumento == null)
                {
                    throw new Exception("Campo Tipo Documento é obrigatório");
                }

                if (ato.CdUso == null)
                {
                    throw new Exception("Campo Uso é obrigatório");
                }
                atoADO.saveAtoOperacao(ato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.ObjCon.Close();
            }
        }

         
    }
}
