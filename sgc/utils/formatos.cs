using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace sgc.utils
{
    public class formatos
    {
        public static String formatoCPFCNPJ(String id)
        {
            id = limpaCpfCnpj(id);
            if (id.Length == 11)
            {
                id = Formatar(id,"###.###.###-##");
            }

            if (id.Length == 14)
            {
                id = Formatar(id,"##.###.###/#####-##");
            }

            return id;
        }

        public static string formatoMoeda(String valor)
        {
            return valor = String.Format("{0:N2}", valor);
        }

        public static String limpaCpfCnpj(String id) 
        {
            return id.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static int[] convertStringIntArray(String num)
        {
            char[] numeros = num.ToCharArray();
            int x = num.Length;
            int[] convertido = new int[x];
            try
            {
                for (int i = 0; i < numeros.Length; i++)
                {
                    convertido[i] = (int)numeros[i];
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao converter sequencia de numeros "+e.Message);
            }

            return convertido;
        }

        public static string limpaStr(string str)
        {
            str = str.Replace(".","");
            str = str.Replace("-", "");
            str = str.Replace(",", "");
            str = str.Replace("/", "");
            return str;
        }


        public static string Formatar( string valor, string mascara )
        {
            StringBuilder dado = new StringBuilder();
            // remove caracteres nao numericos
            foreach ( char c in valor )
            {
                if ( Char.IsNumber(c) )
                    dado.Append(c);
            }
            int indMascara = mascara.Length;
            int indCampo = dado.Length;
            for (; indCampo > 0 && indMascara > 0; )
            {
                if ( mascara[--indMascara] == '#' )
                indCampo--;
            }
            StringBuilder saida = new StringBuilder();
            for (; indMascara < mascara.Length; indMascara++)
            {
                saida.Append( ( mascara[indMascara] == '#' ) ? dado[indCampo++] : mascara[indMascara] );
            }
            return saida.ToString();
        }


        public static bool ValidaCPF(string vrCPF)
        {
            
            
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");
 
            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

 

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
              numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

 
            return true;

        }

        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;

            resultado = new int[2];

            resultado[0] = 0;

            resultado[1] = 0;

            CNPJOk = new bool[2];

            CNPJOk[0] = false;

            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *  int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));

                }

 

                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }
            catch
            {
                return false;
            }

        }

        public static bool ValidaCpfCnpj(String pCpfCnpj)
        {
            bool result = false;
            
            if (pCpfCnpj.Length == 11)
            {
                result = ValidaCPF(pCpfCnpj);
            }

            if (pCpfCnpj.Length == 14)
            {
                result = ValidaCNPJ(pCpfCnpj);
            }
            
            return result;
        }


        public static string formatoData(String data,bool shot = false)
        { 
            //0123456789012345678
            //20/09/2011 20:51:24
            if(shot)
                return data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);
            else
                return data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2) + " " + data.Substring(11, 8);
        }

        public static string formataLinhaImpressao(String desc, double valor, int tamanho)
        {
            string sValor = String.Format("{0:N2}",valor).PadLeft(12,' ');
            int qtd = tamanho - desc.Length;

            return desc + sValor.PadLeft(qtd,' ') ;
        }

        public static double getSomaCampoGrid(DataGridView grid, int coluna)
        {
            double soma = 0;
            for (int i = 0; i < grid.RowCount; i++)
            {
                soma += Convert.ToDouble(grid[coluna, i].Value);
            }

            return soma;
        }

        public static string getValorCampoNumerico(string str) { 
            string r = "0";
            if (!str.Equals(""))
                r = str;

            return r;
        }

        public static string formataMoeda(string valor){
            return Convert.ToDouble(valor).ToString("###,###,##0.00");
        }

        public static string limpaCaracterMoeda(string valor) {
            return valor.Replace("R$", "");
        }
    }

    
}
