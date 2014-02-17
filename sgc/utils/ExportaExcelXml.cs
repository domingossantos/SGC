using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.IO;
using DAO;
namespace sgc.utils
{
    class ExportaExcelXml
    {
        public SqlDataReader _Leitor;
        public SqlDataAdapter _Adaptador;
        public DataTable _TabelaDados;
        public Conexao _conexao;
        

        public String gerarArquivoXML(string comandoSql, string NomeArquivoXML)
        {
            string _atCaminhoDiretorio = System.Windows.Forms.Application.StartupPath;
            string _caminhoXml;
            comandoSql += "For xml RAW('" + NomeArquivoXML + "'), ELEMENTS ";
            _conexao = new Conexao(Dados.strConexao);

            _caminhoXml = _atCaminhoDiretorio;
            if (_caminhoXml == "")
            {
                _caminhoXml = _atCaminhoDiretorio + @"\XML";

                if (!Directory.Exists(_caminhoXml))
                {
                    Directory.CreateDirectory(_caminhoXml);
                }
            }
            else
            {
                _caminhoXml = _caminhoXml + @"\XML";
                if (!Directory.Exists(_caminhoXml))
                {
                    Directory.CreateDirectory(_caminhoXml);
                }
            }
            String _caminhoCompletoArquivo = @"" + _caminhoXml + @"\" + NomeArquivoXML + ".xml";
            XmlTextWriter _locXml = new XmlTextWriter(_caminhoCompletoArquivo, encoding: UTF8Encoding.UTF8);
            string locSql = comandoSql;

            try
            {
                _locXml.WriteStartDocument();
                _locXml.Formatting = Formatting.Indented;
                _locXml.WriteStartElement(NomeArquivoXML);


                executandoSelectSql(locSql);
                while (_Leitor.Read())
                {
                    string StrXml = Convert.ToString(_Leitor[0]);
                    _locXml.WriteRaw(StrXml);
                }

                _locXml.WriteFullEndElement();
                _locXml.WriteEndDocument();
                _locXml.Flush();
                _locXml.Close();
                
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao exportar XML.\n" + ex.Message);
                _Leitor.Close();
            }
            finally
            {
                _Leitor.Close();
                
            }

            return _caminhoCompletoArquivo;
        }

        public void executandoSelectSql(string sql)
        {
            SqlCommand _comandoSql = new SqlCommand(sql, _conexao.ObjCon);
            try
            {
                _conexao.ObjCon.Open();
                _comandoSql.CommandTimeout = 0;
                _Leitor = _comandoSql.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar consulta.\n"+ex.Message);
                _Leitor.Close();
                _conexao.ObjCon.Close();
            }
        }
        

    }
}
