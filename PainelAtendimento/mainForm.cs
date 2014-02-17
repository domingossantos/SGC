using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PainelAtendimento
{
    public partial class mainForm : Form
    {
        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        [DllImport("winmm.dll", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        SqlConnection con;
        IniFile iniFile = new IniFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini");

        public mainForm()
        {
            string strCon =  iniFile.IniReadValue("DBLOCAL", "Host");
            con = new SqlConnection(strCon);
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToLongTimeString();
            lbData.Text = DateTime.Now.ToLongDateString();
        }

        private void tChamada_Tick(object sender, EventArgs e)
        {
            getChamado();
        }

        private void getChamado() {
            try
            {
                string sql = "select top 1 f.nrAtendimento ,s.nmSetor "
                            + ",s.dsCor as corSetor,t.nmTipoAtendimento "
                            + ",t.dsCor as corTipo from tblFilaAtendimento f "
                            + "inner join tblTipoAtendimento  t on t.cdTipoAtendimento = f.cdTipoAtendimento "
                            + "inner join tblSetor s on s.cdSetor = f.cdSetor "
                            + "where f.stAtendimento =  'C' order by f.nrAtendimento ";
                string nSenha;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    nSenha = dr["nrAtendimento"].ToString().PadLeft(5,'0');
                    if (!lbSenha.Text.Equals(nSenha))
                    {
                        lbSenha.Text = dr["nrAtendimento"].ToString().PadLeft(5, '0');
                        lbSetor.Text = dr["nmSetor"].ToString();
                        PlaySound("sound.wav", new System.IntPtr(), PlaySoundFlags.SND_ASYNC);
                    }
                }

            }
           finally{
                con.Close();
            }
        }
    }
}
