using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.utils
{
    static class MessagensExcept
    {
        public static void funMsgSistema(String txtMsg, Int16 nrMsg)
        {
            switch (nrMsg)
            {
                case 1:
                    {
                        MessageBox.Show(txtMsg, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                case 2:
                    {
                        MessageBox.Show(txtMsg, "Informação:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case 3:
                    {
                        MessageBox.Show(txtMsg, "Advertência:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }

                case 4:
                    {
                        MessageBox.Show(txtMsg, "Questionamento:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        break;
                    }

                default:
                    break;
            }
        }
    }
}
