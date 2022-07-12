using ClinicaOdontologica.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Model.Validator
{
    public class ValidacaoDeCpf
    {
        public string MsgErroCpf { get; private set; }
        /// <summary>
        /// Esse método verifica se o cpf é válido
        /// </summary>
        public bool ValidaCpf(string cpf)
        {
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                this.MsgErroCpf = "CPF precisa ter exatamente 11 números";
                ImprimeMensagens.MensagemDeErro(MsgErroCpf);
                return false;
            }
            try
            {
                var cpfLong = long.Parse(cpf);
                if (cpfLong.Equals(00000000000) || cpfLong.Equals(11111111111) || cpfLong.Equals(22222222222)
                    || cpfLong.Equals(33333333333) || cpfLong.Equals(44444444444) || cpfLong.Equals(55555555555)
                    || cpfLong.Equals(66666666666) || cpfLong.Equals(77777777777) || cpfLong.Equals(88888888888)
                    || cpfLong.Equals(99999999999))
                {
                    this.MsgErroCpf = "CPF inválido";
                    ImprimeMensagens.MensagemDeErro(MsgErroCpf);
                    return false;
                }
                else
                {
                    int[] v1 = new int[9];
                    int[] v2 = new int[10];
                    int soma = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        v1[i] = int.Parse(cpf[i].ToString());
                        soma += v1[i] * (10 - i);
                    }

                    int resto = soma % 11;
                    int j = 0;

                    if (resto < 2)
                    {
                        j = 0;
                    }
                    else
                    {
                        j = 11 - resto;
                    }

                    soma = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        v2[i] = int.Parse(cpf[i].ToString());
                        soma += v2[i] * (11 - i);
                    }

                    resto = soma % 11;
                    int k = 0;

                    if (resto < 2)
                    {
                        k = 0;
                    }
                    else
                    {
                        k = 11 - resto;
                    }

                    if (j == int.Parse(cpf[9].ToString()) && k == int.Parse(cpf[10].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        this.MsgErroCpf = "CPF inválido";
                        ImprimeMensagens.MensagemDeErro(MsgErroCpf);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                this.MsgErroCpf = e.Message;
                ImprimeMensagens.MensagemDeErro(MsgErroCpf);
                return false;
            }
        }
    }
}
