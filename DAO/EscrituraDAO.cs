using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class EscrituraDAO
    {
        private SqlConnection con;

        public EscrituraDAO(SqlConnection c)
        {
            con = c;
        }


        public int novaEscritura() {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;

                sql = "INSERT INTO tblEscritura (dtRegistro) VALUES (getdate()); select @@IDENTITY;";

                cmd.CommandText = sql;
             
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Escritura " + ex.Message);
            }
        }

        public void addEscritura(Escritura esc, SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "INSERT INTO tblEscritura (cdAto,tpRequerente,vlDocumento,vlVenal,vlBaseCalculo"
                    + ",nrProcessoLaudemio,nrProcessoITBI,dsContato,dsEndereco,nrCEP"
                    + ",nmCidade,dsUF,dsFoneContato,dsEmailContato,dtOrcamento,tpEscritura,dsLogin,stSegundaNota) VALUES "
                    + "(@cdAto,@tpRequerente,@vlDocumento,@vlVenal,@vlBaseCalculo"
                    + ",@nrProcessoLaudemio,@nrProcessoITBI,@dsContato,@dsEndereco"
                    + ",@nrCEP,@nmCidade,@dsUF,@dsFoneContato,@dsEmailContato,@dtOrcamento"
                    + ",@tpEscritura,@dsLogin,@stSegundaNota); select @@IDENTITY;";

                cmd.CommandText = sql;

                if (esc.CdAto.Equals(0))
                    cmd.Parameters.AddWithValue("@cdAto", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@cdAto", esc.CdAto);


                if (esc.TpRequerente.ToString().Equals(""))
                    cmd.Parameters.AddWithValue("@tpRequerente", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@tpRequerente", esc.TpRequerente);

                if (esc.VlDocumento.ToString().Equals(""))
                    cmd.Parameters.AddWithValue("@vlDocumento", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@vlDocumento", esc.VlDocumento);

                if (esc.VlVenal.ToString().Equals(""))
                    cmd.Parameters.AddWithValue("@vlVenal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@vlVenal", esc.VlVenal);

                if (esc.VlBaseCalculo.ToString().Equals(""))
                    cmd.Parameters.AddWithValue("@vlBaseCalculo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@vlBaseCalculo", esc.VlBaseCalculo);

                cmd.Parameters.AddWithValue("@nrProcessoLaudemio", esc.NrProcessoLaudemio);
                cmd.Parameters.AddWithValue("@nrProcessoITBI", esc.NrProcessoITBI);
                cmd.Parameters.AddWithValue("@dsContato", esc.DsContato);
                cmd.Parameters.AddWithValue("@dsEndereco", esc.DsEndereco);
                cmd.Parameters.AddWithValue("@nrCEP", esc.NrCEP);
                cmd.Parameters.AddWithValue("@nmCidade", esc.NmCidade);
                cmd.Parameters.AddWithValue("@dsUF", esc.DsUF);
                cmd.Parameters.AddWithValue("@dsFoneContato", esc.DsFoneContato);
                cmd.Parameters.AddWithValue("@dsEmailContato", esc.DsEmailContato);

                if (esc.DtOrcamento.ToString().Equals(""))
                    cmd.Parameters.AddWithValue("@dtOrcamento", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@dtOrcamento", esc.DtOrcamento);

                
                cmd.Parameters.AddWithValue("@tpEscritura", esc.TpEscritura);
                cmd.Parameters.AddWithValue("@dsLogin", esc.DsLogin);
                cmd.Parameters.AddWithValue("@stSegundaNota", esc.StSegundaNota);

                esc.IdEscritura = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) {
                throw new Exception("Erro ao gravar Escritura " + ex.Message);
            }
        }

        public void salvaEscritura(Escritura esc, SqlTransaction trans = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "UPDATE tblEscritura "
                       +" SET cdAto = @cdAto, tpRequerente = @tpRequerente,vlDocumento = @vlDocumento "
                       +"    ,vlVenal = @vlVenal, vlBaseCalculo = @vlBaseCalculo, nrProcessoLaudemio = @nrProcessoLaudemio"
                       + "   ,nrProcessoITBI = @nrProcessoITBI, stSegundaNota = @stSegundaNota"
                       +"    ,tpEscritura = @tpEscritura, dsContato = @dsContato, dsEndereco = @dsEndereco"
                       +"    ,nrCEP = @nrCEP, nmCidade = @nmCidade, dsUF = @dsUF, dsFoneContato = @dsFoneContato"
                       +"    ,dsEmailContato = @dsEmailContato, stRegistro = @stRegistro"
                       +"    ,dsLogin = @dsLogin, cdTipoEscritura = @cdTipoEscritura"
                       + "   ,nrSelo = @nrSelo, cdTipoSelo = @cdTipoSelo ,"
                       +"    nrLivro = @nrLivro ,nrFolha = @nrFolha, idOrcamento = @idOrcamento"
                       +"  WHERE idEscritura = @idEscritura";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@cdAto", esc.CdAto);
                cmd.Parameters.AddWithValue("@tpRequerente", esc.TpRequerente);
                cmd.Parameters.AddWithValue("@vlDocumento", esc.VlDocumento);
                cmd.Parameters.AddWithValue("@vlVenal", esc.VlVenal);
                cmd.Parameters.AddWithValue("@vlBaseCalculo", esc.VlBaseCalculo);
                cmd.Parameters.AddWithValue("@nrProcessoLaudemio", esc.NrProcessoLaudemio);
                cmd.Parameters.AddWithValue("@nrProcessoITBI", esc.NrProcessoITBI);
                cmd.Parameters.AddWithValue("@stSegundaNota", esc.StSegundaNota);
                cmd.Parameters.AddWithValue("@tpEscritura", esc.TpEscritura);
                cmd.Parameters.AddWithValue("@dsContato", esc.DsContato);
                cmd.Parameters.AddWithValue("@dsEndereco", esc.DsEndereco);
                cmd.Parameters.AddWithValue("@nrCEP", esc.NrCEP);
                cmd.Parameters.AddWithValue("@nmCidade", esc.NmCidade);
                cmd.Parameters.AddWithValue("@dsUF", esc.DsUF);
                cmd.Parameters.AddWithValue("@dsFoneContato", esc.DsFoneContato);
                cmd.Parameters.AddWithValue("@dsEmailContato", esc.DsEmailContato);
                cmd.Parameters.AddWithValue("@stRegistro", esc.StRegistro);
                cmd.Parameters.AddWithValue("@dsLogin", esc.DsLogin);
                cmd.Parameters.AddWithValue("@cdTipoEscritura", esc.TpEscritura);
                cmd.Parameters.AddWithValue("@idEscritura", esc.IdEscritura);


                cmd.Parameters.AddWithValue("@idOrcamento", esc.IdOrcamento);

                if (esc.NrSelo == null || esc.NrSelo.Equals(0))
                {
                    cmd.Parameters.AddWithValue("@nrSelo", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@nrSelo", esc.NrSelo);
                }

                if (esc.CdTipoSelo == null || esc.CdTipoSelo.Equals(0))
                {
                    cmd.Parameters.AddWithValue("@cdTipoSelo", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@cdTipoSelo", esc.CdTipoSelo);
                }

                if (esc.NrLivro == null)
                {
                    cmd.Parameters.AddWithValue("@nrLivro", DBNull.Value );
                }
                else {
                    cmd.Parameters.AddWithValue("@nrLivro", esc.NrLivro);
                }

                if (esc.NrFolha == null)
                {
                    cmd.Parameters.AddWithValue("@nrFolha", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@nrFolha", esc.NrFolha);
                }

                



                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Escritura " + ex.Message);
            }
        }


        public Escritura getEscritura(int id) {
            try
            {
                Escritura esc = null;

                string sql = "SELECT  idEscritura,cdAto,tpRequerente,vlDocumento"
                            + ",vlVenal,vlBaseCalculo,nrProcessoLaudemio,nrProcessoITBI"
                            + ",dtEntrada,dtSaida,tpEscritura,dsContato,dsEndereco"
                            + ",nrCEP,nmCidade,dsUF,dsFoneContato,dsEmailContato"
                            + ",stRegistro,stSegundaNota "
                            + ",dtOrcamento,idOrcamento FROM tblEscritura where idEscritura = @id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {

                    esc = new Escritura();

                    esc.IdEscritura = Convert.ToInt32(dr["idEscritura"].ToString());
                    if (!dr["cdAto"].ToString().Equals(""))
                        esc.CdAto = Convert.ToInt32(dr["cdAto"].ToString());

                    esc.DsContato = dr["dsContato"].ToString();
                    esc.DsEmailContato = dr["dsEmailContato"].ToString();
                    esc.DsEndereco = dr["dsEndereco"].ToString();
                    esc.DsFoneContato = dr["dsFoneContato"].ToString();
                    esc.DsUF = dr["dsUF"].ToString();
                    esc.NmCidade = dr["nmCidade"].ToString();
                    esc.NrCEP = dr["nrCEP"].ToString();
                    esc.NrProcessoITBI = dr["nrProcessoITBI"].ToString();
                    esc.NrProcessoLaudemio = dr["nrProcessoLaudemio"].ToString();

                    esc.TpEscritura = Convert.ToChar(dr["tpEscritura"]);

                    if (!dr["tpRequerente"].ToString().Equals(""))
                        esc.TpRequerente = Convert.ToChar(dr["tpRequerente"]);


                    if (!dr["stSegundaNota"].ToString().Equals(""))
                        esc.StSegundaNota = Convert.ToInt16(dr["stSegundaNota"]);


                    if (!dr["idOrcamento"].ToString().Equals(""))
                        esc.IdOrcamento = Convert.ToInt16(dr["idOrcamento"]);
                    else
                        esc.IdOrcamento = 0;

                    if (!dr["dtEntrada"].ToString().Equals(""))
                        esc.DtEntrada = DateTime.Parse(dr["dtEntrada"].ToString());
                    if (!dr["dtSaida"].ToString().Equals(""))
                        esc.DtSaida = DateTime.Parse(dr["dtSaida"].ToString());
                    if (!dr["dtOrcamento"].ToString().Equals(""))
                        esc.DtOrcamento = DateTime.Parse(dr["dtOrcamento"].ToString());

                    if (!dr["vlBasecalculo"].ToString().Equals(""))
                        esc.VlBaseCalculo = Convert.ToDouble(dr["vlBasecalculo"].ToString());

                    if (!dr["vlDocumento"].ToString().Equals(""))
                        esc.VlDocumento = Convert.ToDouble(dr["vlDocumento"].ToString());

                    if (!dr["vlVenal"].ToString().Equals(""))
                        esc.VlVenal = Convert.ToDouble(dr["vlVenal"].ToString());

                }

                return esc;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public DataTable getEscrituras(string filtro = "")
        {

            string sql = "SELECT  idEscritura,cdAto,tpRequerente,vlDocumento"
                            + ",vlVenal,vlBaseCalculo,nrProcessoLaudemio,nrProcessoITBI"
                            + ",dtEntrada,dtSaida,tpEscritura,dsContato,dsEndereco"
                            + ",nrCEP,nmCidade,dsUF,dsFoneContato,dsEmailContato"
                            + ",dtOrcamento,idOrcamento FROM tblEscritura where 1 = 1 " + filtro;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }
        public DataTable getEscriturasRelatorio(string filtro = "")
        {

            string sql = "SELECT  e.idEscritura,e.cdAto,e.tpRequerente,e.vlDocumento"
                            + ",e.vlVenal,e.vlBaseCalculo,e.nrProcessoLaudemio,e.nrProcessoITBI"
                            + ",e.dtEntrada,e.dtSaida,e.tpEscritura,e.dsContato,e.dsEndereco"
                            + ",e.nrCEP,e.nmCidade,e.dsUF,e.dsFoneContato,e.dsEmailContato"
                            + ",e.dtOrcamento,a.dsAto, a.vlAto FROM tblEscritura e"
                            + " inner join tblAtosOperacoes a ON e.cdAto = a.cdAto "
                            + "where 1 = 1 " + filtro;
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }


        public DataTable getEscriturasValores(string filtro = "")
        {

            string sql = "select e.idEscritura,e.tpEscritura,e.dtSaida,e.dtEntrada, "
	                    +"(select isnull(sum(mc.vlMovimento),0) from tblMovimentoDeposito mc where "
                        +"mc.idEscritura = e.idEscritura and mc.tpMovimento = 'C') vlCredito, "
	                    +" (select isnull(sum(md.vlMovimento),0) from tblMovimentoDeposito md where "
                        +"md.idEscritura = e.idEscritura and md.tpMovimento = 'D') vlDebito, "
	                    +"(select isnull(sum(mc.vlMovimento),0) from tblMovimentoDeposito mc where "
                        +"mc.idEscritura = e.idEscritura and mc.tpMovimento = 'C') - "
	                    +"(select isnull(sum(md.vlMovimento),0) from tblMovimentoDeposito md where "
                        +"md.idEscritura = e.idEscritura and md.tpMovimento = 'D') vlSaldo "
                        +"from tblEscritura e where 1 = 1 "+filtro+" order by e.idEscritura;";
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }
    }
}
