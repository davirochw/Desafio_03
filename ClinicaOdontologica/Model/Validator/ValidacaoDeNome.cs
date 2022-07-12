using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Model.Validator
{
    public class ValidacaoDeNome
    {
        public string MsgErroNome { get; private set; }

        /// <summary>
        /// Esse método verifica se o nome do paciente tem mais de 5 caracteres
        /// </summary>
        public bool ValidaNome(string nome)
        {
            if (nome.Length >= 5)
            {
                return true;
            }
            else
            {
                this.MsgErroNome = "Nome inválido";
                ImprimeMensagens.MensagemDeErro(MsgErroNome);
                return false;
            }
        }
    }
}
