using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.admin
{
    public partial class ImprimirFitaArquivoForm : Form
    {
        public ImprimirFitaArquivoForm()
        {
            InitializeComponent();
        }

        private void btEscolheArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArquivo = new OpenFileDialog();

            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                txArquivo.Text = abrirArquivo.FileName;
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader oReader = new StreamReader(txArquivo.Text);

                utils.IniFile iniFile = new utils.IniFile(utils.sessao.PathIniFile);

                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));
                MatrixReporter.Reporter imp = new MatrixReporter.Reporter();
                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                    {
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                    }
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();


                String linha = "";
                int i = 1;

                while ((linha = oReader.ReadLine()) != null)
                {
                    imp.PrintText(i, 0, linha);
                    i++;
                }

                 linha = "";
                imp.EndJob();
                imp.PrintJob();
                utils.MessagensExcept.funMsgSistema("Arquivo enviado para a impressora",2);
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao ler arquivo.\n"+ex.Message, 1);
            }


        }
    }
}
