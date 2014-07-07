using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using sgc.auxiliares;
using Modelos;
using BLL;
using DAO;
using sgc.acesso;
using sgc.controleSelos;
using sgc.processos;
using sgc.utils;
using sgc.assinaturas;
using sgc.caixa;


namespace sgc
{
    public partial class mainForm : Form
    {
        private String usuario;
        private static int pedido;
        private assinaturas.assinaturasForm assinaturaForm;
        private Conexao con;
        private MenuPerfilBLL menuPerfilBLL;
        private CaixaBLL caixaBLL;
        private String pathSISDOC;
        public void setLblPedido(int numPedido)
        {
            tsslPedido.Text = numPedido.ToString();
        }

        private bool acessoMenu(int perfil, int menu) {
            bool st = menuPerfilBLL.getMenuExistePerfil(perfil,menu);
            return st;
        }


        public mainForm()
        {
            InitializeComponent();
        }

        public void abrirFormFilho(Form oForm,int idForm = 0)
        {
            bool open = false;
            
            if(idForm > 0)
            {
                if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, idForm))
                {
                    utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                    return;
                }
            }

            foreach (Form frm in this.MdiChildren) 
                {
                    if (frm.GetType() == oForm.GetType())
                    {
                        frm.BringToFront();
                        oForm.Dispose();
                        open = true;
                    }       
                }

            if (!open)
            {
                oForm.MdiParent = this;
                oForm.Show();
            }
        }

        private void sobreOSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sobreForm sobre = new sobreForm();

            abrirFormFilho(sobre);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin.Equals("admin"))
            {
                utils.sqlForm SqlForm = new sqlForm();
                SqlForm.MdiParent = this;
                SqlForm.Show();
            }
            else {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
            }

        }

        private void perfilDeAcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perfilForm perfil = new perfilForm();
            abrirFormFilho(perfil, 1310);

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy");
                
                setMenu(false);
                loginForm login = new loginForm(this);
                login.MdiParent = this;

                login.Show();
                login.Focus();

                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
                sessao.PathApp = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                sessao.PathIniFile = sessao.PathApp + "\\config.ini";
                utils.IniFile iniFile = new utils.IniFile(sessao.PathIniFile);
                sessao.Hostdb = iniFile.IniReadValue("RELATORIO", "host");
                sessao.Userdb = iniFile.IniReadValue("RELATORIO", "userdb");
                sessao.Passdb = iniFile.IniReadValue("RELATORIO", "passdb");
                DAO.Dados.strConexao = iniFile.IniReadValue("DBLOCAL", "Host");
                DAO.Dados.StrConRemoto = iniFile.IniReadValue("DBREMOTO", "Host");
                sessao.CdAtoPedido = Convert.ToInt32(iniFile.IniReadValue("CONFIGCAIXA", "ATOPEDIDO"));
                sessao.CdAtodeposito = Convert.ToInt32(iniFile.IniReadValue("CONFIGCAIXA", "ATODEPOSITO"));
                sessao.IdPedidoPagtoCorrentista = Convert.ToInt32(iniFile.IniReadValue("CONFIGCAIXA", "ATOPGTOCORRENTISTA"));
                pathSISDOC = iniFile.IniReadValue("SISDOC", "PATH");

                if (iniFile.IniReadValue("PESQUISA", "Host").ToUpper().Equals("REMOTO"))
                {
                    sessao.PesquisaRemoto = true;
                }
                else {
                    sessao.PesquisaRemoto = false;
                }

                tlbHora.Text = DateTime.Now.Date.ToShortDateString();

                assinaturaForm = null;
                con = new Conexao(Dados.strConexao);
                menuPerfilBLL = new MenuPerfilBLL(con);
                caixaBLL = new CaixaBLL(con);
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao carregar confgurações iniciais.\n" + ex.Message,3);
            }

        }

        public void setMenu(Boolean st){
            menu01.Enabled = st;
        }

        public void setNomeUsuario(String nomeUser,String login) {
            stbUsuario.Text = nomeUser;
            usuario = login;
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 1100))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                usuarioForm usuarioForm = new usuarioForm();
                usuarioForm.MdiParent = this;
                usuarioForm.Show();
            }
        }

        private void atosEOperaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 1410))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                atosOperacoesForm atosOperacoesForm = new atosOperacoesForm();
                atosOperacoesForm.MdiParent = this;
                atosOperacoesForm.Show();
            }
        }


        private void cadastroDeSelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 2100))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                selosForm selosForm = new selosForm();
                selosForm.MdiParent = this;
                selosForm.Show();
            }
        }

        private void novoProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 4100))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                processoForm processoForm = new processoForm(usuario);

                processoForm.MdiParent = this;
                processoForm.Show();
            }
        }

        private void tipoSeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 2200))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                tipoSeloForm tipoSeloForm = new tipoSeloForm();
                tipoSeloForm.MdiParent = this;
                tipoSeloForm.Show();
            }
        }

        private void pesquisaProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 4200))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                pesquisaProcessoForm pesquisaProcessoForm = new pesquisaProcessoForm(usuario);
                pesquisaProcessoForm.MdiParent = this;
                pesquisaProcessoForm.Show();
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 4100))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                processoForm processoForm = new processoForm(usuario);

                processoForm.MdiParent = this;
                processoForm.Show();
            }
        }

        private void mainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.KeyDown += new KeyEventHandler(this.mainForm_KeyDown);
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                DialogResult dlgR = MessageBox.Show("Deseja encerrar a aplicação?","Cartorio Conduru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dlgR.ToString().Equals("Yes"))
                {
                    this.Close();
                }
            }
        }

        private void menu01_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 5200))
            {
                MessageBox.Show("Você não tem permissão de acesso a esta opção de menu");
                return;
            }
            else
            {*/
                pedidosAbertosForm pedidosAbertos = new pedidosAbertosForm();

                pedidosAbertos.MdiParent = this;
                pedidosAbertos.Show();
           // }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cartãoDeAssinaturaToolStripMenuItem_Click(null,null);

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            cartaoAssinaturaForm cartaoForm = new cartaoAssinaturaForm();
            abrirFormFilho(cartaoForm, 3200);
        }

        private void cartãoDeAssinaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assinaturaForm = new assinaturas.assinaturasForm();
            abrirFormFilho(assinaturaForm, 3100);
        }

        private void caixaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            

            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 5100))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {

                string strCaixa = "0";
                HistoricoCaixa historico = null;

                strCaixa = (Microsoft.VisualBasic.Interaction.InputBox("No. do Caixa", "Cartorio Conduru", "0", 150, 150));

                if (strCaixa.Equals(""))
                {
                    return;
                }

                if (sessao.NrCaixa == 0)
                {
                    if (strCaixa.Equals("0"))
                    {
                        utils.MessagensExcept.funMsgSistema("Informe No. do Caixa",2);
                        caixaToolStripMenuItem2_Click(null, null);
                        return;
                    }
                    

                }

               
                    Caixa c = caixaBLL.getCaixa(Convert.ToInt32(strCaixa));
                
                if (c == null) 
                {
                    utils.MessagensExcept.funMsgSistema("Caixa Não Existe",3);
                    return;
                }


                if (!c.StCaixa.Equals('F'))
                {
                    historico = new HistoricoCaixa();

                    historico = caixaBLL.getUltimoHistorioPorCaixa(Convert.ToInt32(strCaixa));

                    if (historico == null) {
                        utils.MessagensExcept.funMsgSistema("Caixa Aberto.\nPor favor Feche este caixa antes de utilizá-lo!",2);
                        return;
                    }

                    if (!historico.DsLogin.Equals(sessao.UsuarioSessao.DsLogin))
                    {
                        utils.MessagensExcept.funMsgSistema("Caixa No. " + strCaixa + " aberto pelo usuário " + historico.DsLogin + "\nFavor utilizar outro no. de caixa.",2);
                        return;
                    }
                    else
                    {
                        if (historico.DtAbertura.ToShortDateString() != DateTime.Now.ToShortDateString())
                        {
                            utils.MessagensExcept.funMsgSistema("Este caixa esta aberto desde o dia " + historico.DtAbertura.ToShortDateString() + "\nFavor feche-o para então utilizá-lo novamente.",2);
                            return;
                        }
                        else
                        {
                            utils.MessagensExcept.funMsgSistema("Caixa já aberto.",2);
                            sessao.Historico = historico;
                            sessao.NrCaixa = Convert.ToInt32(strCaixa);

                            caixaForm FormCaixa = new caixaForm();
                            FormCaixa.MdiParent = this;
                            FormCaixa.Show();
                        }
                    }
                }
                else
                {
                    try
                    {
                        historico = new HistoricoCaixa();

                        historico.DsLogin = sessao.UsuarioSessao.DsLogin;
                        historico.DtAbertura = DateTime.Now;
                        historico.NrCaixa = Convert.ToInt32(strCaixa);

                        caixaBLL.abreCaixa(historico);

                        string vlCaixa = (Microsoft.VisualBasic.Interaction.InputBox("Valor de Abertura de Caixa", "Cartorio Conduru", "0", 150, 150));

                        if (vlCaixa != "")
                        {
                            MovimentoCaixa movimento = new MovimentoCaixa();

                            movimento.IdHitoricoCaixa = historico.IdHistoricocaixa;
                            movimento.IdTipoMovimento = 77;
                            movimento.NrCaixa = historico.NrCaixa;
                            movimento.TpOperacao = 'C';
                            movimento.VlMovimento = Convert.ToDouble(vlCaixa);
                            movimento.DsLogin = historico.DsLogin;
                            movimento.DsLoginAutDesconto = "";
                            movimento.NrCaixa = historico.NrCaixa;
                            movimento.NrPedido = 0;
                            movimento.VlDesconto = 0;
                            movimento.VlDinheiro = 0;
                            movimento.NmRecibo = "";

                            caixaBLL.salvaMovimento(movimento);
                        }
                        sessao.NrCaixa = historico.NrCaixa;
                        sessao.Historico = historico;

                        caixaForm FormCaixa = new caixaForm();
                        FormCaixa.MdiParent = this;
                        FormCaixa.Show();
                    }
                    catch (Exception ex) {
                        utils.MessagensExcept.funMsgSistema("Erro ao abrir caixa.\n" + ex.Message, 1);
                    }
                }
            }
            
        }
        
        

        private void cadastroDeCaixasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 5400))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                caixa.caixaCadastroForm caixaCadastroForm = new caixaCadastroForm();
                caixaCadastroForm.MdiParent = this;
                caixaCadastroForm.Show();
            }
        }

        private void pesquisaSituaçãoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 5300))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                caixa.caixaPesquisaForm caixaPesquisa = new caixaPesquisaForm();
                caixaPesquisa.MdiParent = this;
                caixaPesquisa.Show();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            toolStripComboBox1_Click(null, null);
        }

        private void toolStripCaixa_Click(object sender, EventArgs e)
        {
            caixaToolStripMenuItem2_Click(null, null);
        }

        private void MesaDeAssinaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 3400))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                assinaturas.mesaForm mesaForm = new mesaForm();
                mesaForm.MdiParent = this;
                mesaForm.Show();
            }
        }

        private void menuDeAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void trocarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 1330))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                trocarSenhaForm TrocaSenhaForm = new trocarSenhaForm();
                TrocaSenhaForm.ShowDialog();
            }
        }

        private void scannerEmLoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 3300))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                scannerLoteForm scannerLote = new scannerLoteForm();
                scannerLote.MdiParent = this;
                scannerLote.Show();
            }
        }

        private void chamarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 1210))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {

                DAO.Conexao con = new DAO.Conexao(DAO.Dados.strConexao);
                con.ObjCon.Open();
                DAO.FilaAtendimentoDAO filaDAO = new DAO.FilaAtendimentoDAO(con.ObjCon);
                string nrAtend = filaDAO.chamarCliente(utils.sessao.UsuarioSessao.CdSetor, utils.sessao.UsuarioSessao.DsLogin);

                if (nrAtend != "0")
                {
                    utils.MessagensExcept.funMsgSistema("Ficha Chamada No." + nrAtend.PadLeft(3, '0'),2);
                    DialogResult dlgR = MessageBox.Show("Iniciar atendimento?", "Cartorio Conduru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgR == DialogResult.Yes)
                    {
                        filaDAO.iniciaAtendimento(nrAtend);
                        utils.MessagensExcept.funMsgSistema("Atendimento Iniciado!",2);
                    }

                }
                else
                {
                    utils.MessagensExcept.funMsgSistema("Não há clientes para atendimento!",2);
                }
                con.ObjCon.Close();

            }
        }

        private void selosUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 2300))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                selosUsuarioForm selosUsuarios = new selosUsuarioForm();
                selosUsuarios.MdiParent = this;
                selosUsuarios.Show();
            }
        }

        private void atualizarAssinaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!acessoMenu(sessao.UsuarioSessao.CdPerfil, 3500))
            {
                utils.MessagensExcept.funMsgSistema("Você não tem permissão de acesso a esta opção de menu",3);
                return;
            }
            else
            {
                atualizarAssinaturasForm atualizaForm = new atualizarAssinaturasForm();
                atualizaForm.MdiParent = this;
                atualizaForm.Show();
            }
        }

        private void recuperarAssinaturasRemotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recuperaDadosRemotoForm dadosRemotosForm = new recuperaDadosRemotoForm();
            dadosRemotosForm.MdiParent = this;
            dadosRemotosForm.Show();
        }

        private void selosUsadosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            situacaoSelosForm relSituacaoSelosForm = new situacaoSelosForm();
            relSituacaoSelosForm.MdiParent = this;
            relSituacaoSelosForm.Show();
                 
        }

        private void itensEscrituraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void escrituraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            escrituraForm escForm = new escrituraForm();
            escForm.MdiParent = this;
            escForm.Show();
        }

        private void solicitaçãoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solicitacaoPgtoForm solicitacaoForm = new solicitacaoPgtoForm();
            solicitacaoForm.MdiParent = this;
            solicitacaoForm.Show();
        }

        private void movimentoFinanceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*financeiro.movimentoFinanceiroForm movimentoFinanceiroForm = new financeiro.movimentoFinanceiroForm();
            movimentoFinanceiroForm.MdiParent = this;
            movimentoFinanceiroForm.Show();
            */
        }

        

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            movimentoCaixaUsuarioForm movimentoCaixaDia = new movimentoCaixaUsuarioForm();
            movimentoCaixaDia.MdiParent = this;
            movimentoCaixaDia.Show();

        }

        private void registroDocumentosAntigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroProcuracaoAntiga procuracaoAntigaForm = new registroProcuracaoAntiga();
            procuracaoAntigaForm.MdiParent = this;
            procuracaoAntigaForm.Show();
        }

        private void relatoriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            relatorioEscrituraForm relEscrituraForm = new relatorioEscrituraForm();
            relEscrituraForm.MdiParent = this;
            relEscrituraForm.Show();
        }

        private void movimentoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relMovimentoDiarioForm relMovDiarioForm = new relMovimentoDiarioForm();
            abrirFormFilho(relMovDiarioForm);
        }

        private void movimentoCaixasPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimentoCaixasForm movimentoDiaForm = new movimentoCaixasForm();
            abrirFormFilho(movimentoDiaForm);
        }

        private void resumoOperaçõesPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            financeiro.resumoAtosPeriodoForm resumoAtosForm = new financeiro.resumoAtosPeriodoForm();
            abrirFormFilho(resumoAtosForm);
        }

        private void orçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processos.escrituraOrcamentoForm orcamentoForm = new escrituraOrcamentoForm();
            abrirFormFilho(orcamentoForm);
        }

        private void tJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcontas.mensalForm oMensalForm = new pcontas.mensalForm();
            abrirFormFilho(oMensalForm);
        }

        private void cadastroPessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processos.pessoaForm oPessoaForm = new pessoaForm();
            abrirFormFilho(oPessoaForm);
        }

        private void provimento18ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnj.provimento18Form oProvimento18Form = new cnj.provimento18Form();
            abrirFormFilho(oProvimento18Form);

                 
        }

        private void correntistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auxiliares.correntistaForm oCorrentistaForm = new correntistaForm();
            abrirFormFilho(oCorrentistaForm);
        }

        private void linkSisdoc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pathSISDOC);
        }

        private void tamanhoDeImagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tamanhoDeImagensToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listaTamanhoAssinForm oListaTamanhoAssinForm = new listaTamanhoAssinForm();
            abrirFormFilho(oListaTamanhoAssinForm);
        }

        private void cancelarSeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin == "admin")
            {
                admin.CancelaSeloForm cancelaSeloForm = new admin.CancelaSeloForm();
                abrirFormFilho(cancelaSeloForm);
            }
            else {
                utils.MessagensExcept.funMsgSistema("Você não tem previlégio para acessar esta opção",3);
            }
        }

        private void históricoDeMovimentoDeSelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin == "admin")
            {
                admin.HistoricoMovimentoSelosForm historicoMovimentoSelos  = new admin.HistoricoMovimentoSelosForm();
                abrirFormFilho(historicoMovimentoSelos);
            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Você não tem previlégio para acessar esta opção", 3);
            }
        }

        private void históricoDeCancelamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin == "admin")
            {
                admin.HistoricoCancelamentoPedidosForm historicoCancelamentoPedidos = new admin.HistoricoCancelamentoPedidosForm();
                abrirFormFilho(historicoCancelamentoPedidos);
            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Você não tem previlégio para acessar esta opção", 3);
            }
        }

        private void situaçãoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin == "admin")
            {
                admin.SituacaoPedidoForm situacaoPedidos = new admin.SituacaoPedidoForm();
                abrirFormFilho(situacaoPedidos);
            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Você não tem previlégio para acessar esta opção", 3);
            }
        }

        private void imprimirFitaDeArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin == "admin")
            {
                admin.ImprimirFitaArquivoForm imprimeFitaArquivoForm = new admin.ImprimirFitaArquivoForm();
                abrirFormFilho(imprimeFitaArquivoForm);
            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Você não tem previlégio para acessar esta opção", 3);
            }
        }

        private void reimpressãoDeUsoInternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caixa.ReimpressaoSangriaForm reimpressaoSangriaForm = new ReimpressaoSangriaForm();
            abrirFormFilho(reimpressaoSangriaForm);
        }

       


        
    }
}
