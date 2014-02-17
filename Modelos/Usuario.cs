using System;
using System.Text;

namespace Modelos
{
    public class Usuario
    {
        private String dsLogin;

        public String DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
        private String nmUsuario;

        public String NmUsuario
        {
            get { return nmUsuario; }
            set { nmUsuario = value; }
        }
        private String vlSenha;

        public String VlSenha
        {
            get { return vlSenha; }
            set { vlSenha = value; }
        }
        private String nrCPF;

        public String NrCPF
        {
            get { return nrCPF; }
            set { nrCPF = value; }
        }
        private int cdPerfil;

        public int CdPerfil
        {
            get { return cdPerfil; }
            set { cdPerfil = value; }
        }
        private DateTime dtCadastro;

        public DateTime DtCadastro
        {
            get { return dtCadastro; }
            set { dtCadastro = value; }
        }
        private int cdSetor;

        public int CdSetor
        {
            get { return cdSetor; }
            set { cdSetor = value; }
        }
    }
}
