using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.utils
{
    public class utils
    {
        public static int retornaValor(string valor)
        {
            if (valor.Equals(""))
                return 0;
            else
                return Convert.ToInt32(valor);
        }

        public static bool formCriado(Form[] filhos,String form)
        {
            bool retorno = false;
            for (int i = 0; i < filhos.Length; i++)
            {
                if (filhos[i].Name.Equals(form))
                    retorno = true;
            }

            return retorno;
        }

        public static void OpenForm(Type frmType)
        {
            bool bolCtl = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Equals(frmType))
                {
                    form.Show();
                    bolCtl = true;
                    break;
                }
            }

            if (!bolCtl)
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.Show();
            }
        }
    }
}
