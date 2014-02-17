using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sgc.utils
{
    class classeMascaraJa
    {

        //ATRIBUTOS--------

        private char tecla;
        private string palavra;
        private Int32 fator = 1;

        //METODOS PRIVATE--

        private void retiraCaractere(char carac)
        {   //retirando caractere da string
            string[] campos = palavra.Split(carac);
            palavra = Convert.ToDouble(string.Concat(campos)).ToString();
        }



        private void acrescentaZeros(int normal, int backspace)
        {   //acrescentado zeros a string

            /*while ((palavra.Length < normal) || ((palavra.Length < backspace) && (tecla == (char) Keys.Back)))
            {

                palavra = "0" + palavra;

            }*/

        }



        private void retornaFator()
        {   //compara se backspace

           // if (tecla == (char)Keys.Back)

                fator = 3;

        }



        public void limpaNumero(char simbolo, int min, int max)
        {   //chama funcao para retirada de caracter e insercao de zeros

            retiraCaractere(simbolo);

            acrescentaZeros(min, max);

            retornaFator();

        }



        //funcao recebe quantidade de parter do numero, 
        //inicio e quantidade de caracteres de cada parte dentro da string, 
        //caracter e efetua qualquer tipo de mascara.

        private void mascaraQualquer(Int32 quantidade, string[,] limites)
        {

            string partes = "";

            Int32 contador = 0;

            while (contador < quantidade)
            {

                partes += palavra.Substring(Convert.ToInt32(limites[contador, 0]), Convert.ToInt32(limites[contador, 1])) + limites[contador, 2];

                contador = contador + 1;

            }

            palavra = partes;

        }



        //METODODS PUBLICOS----

        public void recebeTecla(char x)
        {

            tecla = x;

        }



        public void recebePalavra(string y)
        {

            palavra = y;

        }



        //metodo recebe caracter e retorna falso se numero

        public bool mascaraNumero(Int32 maximo)
        {

            //if ((!char.IsNumber(tecla) || (palavra.Length >= maximo && Convert.ToInt32(palavra.Substring(0, 1)) != 0)) && (tecla != (char)Keys.Back))

              //  return true;

           // else

                return false;

        }



        //aplica a mascara no formato 00000-000

        public string mascaraCEP()
        {

            limpaNumero('-', 7, 9);

            string[,] partes = { { "0", "5", "-" }, { "5", Convert.ToString(1 + fator), "" } };



            mascaraQualquer(2, partes);

            return palavra;

        }


        public string mascaraMoeda()
        {
            limpaNumero(',', 3, 9);

            string[,] partes = { { "0", "7", "," }, { "2", Convert.ToString(1 + fator), "" } };



            mascaraQualquer(2, partes);

            return palavra;
        }


        //aplica a mascara no formato 00000000/0000-00

        public string mascaraCNPJ()
        {

            string[] camposAux;

            palavra = string.Concat(camposAux = palavra.Split('/'));

            limpaNumero('-', 13, 15);
            string[,] partes = { { "0", "8", "/" }, { "8", "4", "-" }, { "12", Convert.ToString(1 * fator), "" } };
            mascaraQualquer(3, partes);

            return palavra;

        }
    }
}
