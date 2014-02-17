using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
namespace sgc.utils
{
    public partial class sqlForm : Form
    {
        public sqlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao(Dados.strConexao);
            con.ObjCon.Open();
            try
            {
                if (txComando.Text.ToLower().Substring(0, 6).Equals("select"))
                {
                    SqlDataAdapter da = new SqlDataAdapter(txComando.Text, con.ObjCon);
                    DataTable dados = new DataTable();
                    da.Fill(dados);
                    dataGridView1.DataSource = dados;
                    da.Dispose();
                }
                else {
                    SqlCommand cmd = new SqlCommand(txComando.Text, con.ObjCon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Commando Executado");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.StackTrace);
            }
            finally{
                con.ObjCon.Close();
            }
        }
    }
}
