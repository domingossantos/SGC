using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using Modelos;
using DAO;

namespace BLL
{
    public class PessoaBLL
    {
        private Conexao con;

        public PessoaBLL(Conexao c)
        {
            con = c;
        }

        public String pesquisaPessoa(String cpfcnpj)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                con.ObjCon.Open();
                String nome = pessoaADO.getPessoa(cpfcnpj).NmPessoa;

                return nome;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public Pessoa getPessoa(string cpfcnpj) {
            try
            {
                
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                con.ObjCon.Open();
                Pessoa p = pessoaADO.getPessoa(cpfcnpj);

                return p;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        //txCpfCnpj.Text,txNome.Text,getTipo(),txFones.Text,txEndereco.Text,txEmail.Text
        public void salvaPessoa(String CpfCnpj, String Nome,char tipo,string fone,string endereco, string email)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                Pessoa p = new Pessoa();
                p.NrCpfCnpj = CpfCnpj;
                p.NmPessoa = Nome;
                p.NrFones = fone;
                p.DsEndereco = endereco;
                p.DsEmail = email;

                p.TpPessoa = tipo;

                con.ObjCon.Open();
                pessoaADO.savePessoa(p);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void salvaPessoa(Pessoa p)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);

                con.ObjCon.Open();
                pessoaADO.savePessoa(p);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void salvaNomePessoa(String CpfCnpj, String Nome)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                Pessoa p = new Pessoa();
                p.NrCpfCnpj = CpfCnpj;
                p.NmPessoa = Nome;
                p.NrFones = "";
                p.DsEndereco = "";
                p.DsEmail = "";

                p.TpPessoa = (p.NrCpfCnpj.Length == 11) ? Convert.ToChar("F") : Convert.ToChar("J");

                con.ObjCon.Open();
                pessoaADO.savePessoaMinimo(p);
            }
            finally
            {
                con.ObjCon.Close();
            }
            
        }

        public void atualizaPessoa(Pessoa p)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                con.ObjCon.Open();
                pessoaADO.updatePessoa(p);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }


        public DataTable buscaPessoaNome(string nome) {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = pessoaADO.getPessoas(" and nmPessoa like '%" + nome + "%'");

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable buscaPessoaCpfCnpj(string cpf_cnpj)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = pessoaADO.getPessoas(" and nrCpfCnpj ='" + cpf_cnpj+ "'");

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }




        public DataTable getPessoasProcesso(String nrProcesso)
        {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = pessoaADO.getPessoasProcesso(nrProcesso);
             
                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }



        public DataTable getTipoPessoa()
        {
            try
            {
                TipoPessoaDAO tipoPessoaADO = new TipoPessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = tipoPessoaADO.getTipoPessoa();
             
                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getTipoPessoa(string idProvimento)
        {
            try
            {
                TipoPessoaDAO tipoPessoaADO = new TipoPessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                string where = " and idProvimento = '" + idProvimento + "' ";
                dados = tipoPessoaADO.getTipoPessoa(where);

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void salvaPessoaOrcamento(string nrCpfCnpj, int idOrcamento, int idTipo) {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                con.ObjCon.Open();
                pessoaADO.savePessoaOrcamento(nrCpfCnpj, idOrcamento, idTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getCidadesPorEstado(string uf)
        {
            try
            {
                CidadeDAO oCidade = new CidadeDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                
                dados = oCidade.getCidadesPorEstado(uf);

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


    }
}
