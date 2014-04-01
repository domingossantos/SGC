using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DAO;
namespace sgc.pcontas
{
    public partial class mensalForm : Form
    {

        public mensalForm()
        {
            InitializeComponent();
        }

        private void btGerarArquivo_Click(object sender, EventArgs e)
        {
            String PATH = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            if (cbMes.Text.Equals("")) {
                MessageBox.Show("Selecione um mês de referência");
                return;
            }

            lblInfo.Text = "Gerando arquiv. Aguarde...";

            Conexao con = new Conexao(Dados.strConexao);
            
            SelosDAO oSelos = new SelosDAO(con.ObjCon);


            String[] datas = getDatasMes(cbMes.Text, DateTime.Now.Year).Split('@');
            con.ObjCon.Open();
            
            string ano = txAno.Text + "-";

            

            DataTable vDados = oSelos.getSelosPestacao(ano+datas[0], ano+datas[1]);

            if (!Directory.Exists(PATH + @"\PContas")) { 
                Directory.CreateDirectory(PATH + @"\PContas");
            }

            String nmArquivo = PATH+@"\PContas\Arquivo-"+cbMes.Text+".txt";


            if (File.Exists(nmArquivo)) {
                File.Delete(nmArquivo);
            }

                FileStream fs = File.Create(nmArquivo);
                StreamWriter sw = new StreamWriter(fs);
                
                DataView dvDados = new DataView(vDados);
                DataRow drDados;
                String linha = "";
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    // Velho            Novo
                    // 0 - Ato          - 2
                    // 1 - Valor ato    - 3
                    // 2 - Vlaor 10%    - 4
                    // 3 - Valor 2,5%   - 5
                    // 4 - Tipo Selo    - 6
                    // 5 - Ano          - 7
                    // 6 - Dt Inclusao  - 8
                    // 7 - Dt PEdido    - 9
                    // 8 - Selo         - 0
                    // 9 - Serie        - 1
                    linha = drDados[2].ToString().TrimEnd().PadLeft(3,'0')+";"
                            + (Convert.ToDouble(drDados[3]).ToString())+";"
                            + (Convert.ToDouble(drDados[4]).ToString()) + ";"
                            + (Convert.ToDouble(drDados[5]).ToString()) + ";"
                            + drDados[6].ToString() + ";"
                            + drDados[7].ToString() + ";"
                            + utils.formatos.formatoData(drDados[9].ToString()) + ";"
                            + utils.formatos.formatoData(drDados[9].ToString()) + ";"
                            + drDados[1].ToString().ToString().TrimEnd() + ";"
                            + drDados[0].ToString().TrimEnd() + ";";

                    sw.WriteLine(linha);

                }

                con.ObjCon.Close();
                MessageBox.Show("Arquivo Gerado!");
                lblInfo.Text = "Arquivo Gerado!";
                sw.Close();
                fs.Close();
            
            
        }

        public string formataNumero(string num) {
            if (num.IndexOf(",") > -1)
            {
                String[] numeros = num.Split(',');

                
                return numeros[0] + "." + numeros[1].PadRight(2, '0');
            }
            else {
                return num;
            }
        }

        public String getDatasMes(string mes, int ano)
        {
            String datas = "";
            int bisexto = ano % 4;

            


            switch (mes)
            {
                case "JAN":
                    datas = "01-01@01-31";
                    break;
                case "FEV":
                    if (bisexto == 0)
                    {
                        datas = "02-01@02-29";
                    }
                    else 
                    {
                        datas = "02-01@02-28";
                    }
                    break;
                case "MAR":
                    datas = "03-01@03-31";
                    break;
                case "ABR":
                    datas = "04-01@04-30";
                    break;
                case "MAI":
                    datas = "05-01@05-31";
                    break;
                case "JUN":
                    datas = "06-01@06-30";
                    break;
                case "JUL":
                    datas = "07-01@07-31";
                    break;
                case "AGO":
                    datas = "08-01@08-31";
                    break;
                case "SET":
                    datas = "09-01@09-30";
                    break;
                case "OUT":
                    datas = "10-01@10-31";
                    break;
                case "NOV":
                    datas = "11-01@11-30";
                    break;
                case "DEZ":
                    datas = "12-01@12-31";
                    break;

            }

            return datas;
        }
    }
}
