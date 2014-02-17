using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Modelos;
using DAO;

namespace BLL
{
    public class UsuarioBLL
    {
        private Conexao con;
        public UsuarioBLL(Conexao con) 
        {
            this.con = con;
        }
        public Usuario login(String login) 
        {

            con.ObjCon.Open();
            UsuarioDAO obj = new UsuarioDAO(con.ObjCon);

            try
            {
                Usuario usuario = obj.getUsuario(login);
                
                return usuario;
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable listarUsuarios() 
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);
             
                return obj.getUsuarios();
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Usuario getUsuario(String login)
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);

                Usuario usuario = obj.getUsuario(login);

                return usuario;
            }
            catch (Exception ex) {
                throw new Exception("Erro: "+ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getUsuarios()
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);

                DataTable dados = obj.getUsuarios();

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void inserir(Usuario usuario) 
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);
                if (usuario.NmUsuario.Length <= 0)
                {
                    throw new Exception("Campo obrigatório: Nome");
                }
                if (usuario.DsLogin.Length <= 0)
                {
                    throw new Exception("Campo obrigatório: Login");
                }

                obj.addUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void alterar(Usuario usuario)
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);
                if (usuario.NmUsuario.Length <= 0)
                {
                    throw new Exception("Campo obrigatório: Nome");
                }
                if (usuario.DsLogin.Length <= 0)
                {
                    throw new Exception("Campo obrigatório: Login");
                }

                obj.saveUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void alterarSenha(Usuario usuario)
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);

                obj.alteraSenhaUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void deletar(String login) 
        {
            try
            {
                con.ObjCon.Open();
                UsuarioDAO obj = new UsuarioDAO(con.ObjCon);
                obj.delUsuario(login);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        
    }
}
