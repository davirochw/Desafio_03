using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.View
{
    public class ImprimeMensagens
    {
        public static void MensagemDeErro(string erro)
        {
            Console.WriteLine();
            Console.WriteLine(erro);
            Console.ReadKey();
        }

        public static void MensagemDeCadastro(string mensagem)
        {
            Console.Write(mensagem);
        }

        public static void MensagemSituacao(string situacao)
        {
            Console.WriteLine();
            Console.WriteLine(situacao);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
