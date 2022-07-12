using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Model.Validator
{
    public class ValidacaoDeData
    {
        public string MsgErroData { get; private set; } 

        /// <summary>
        /// Esse método converte a hora da classe <class>Consulta</class> para o formato de hora do sistema 
        /// Caso ela não seja convertida, o programa retorno "-1" ou conversaoDeHoraInvalida;
        /// Caso seja convertida, mas não atende os requisitos do intervalo de horas do funcionamento do consultorio,
        /// e nem o intervalo de 15min, o programa retorna "0" ou intervaloDeHoraInvalida;
        /// </summary>
        private string ConverteHora(string horaInicial, string horaFinal)
        {
            try
            {
                horaInicial = horaInicial.Trim();
                horaFinal = horaFinal.Trim();
                horaInicial = horaInicial.Replace(":", "").Replace("-", "");
                horaFinal = horaFinal.Replace(":", "").Replace("-", "");

                horaInicial = horaInicial.Insert(2, ":");
                horaFinal = horaFinal.Insert(2, ":");

                var horaInicio = TimeSpan.Parse(horaInicial);
                var horaFim = TimeSpan.Parse(horaFinal);
                var horaAbreConsultorio = TimeSpan.Parse("09:00");
                var horaFechaConsultorio = TimeSpan.Parse("19:00");

                var inicio = (horaInicio >= horaAbreConsultorio && horaInicio < horaFim);
                var fim = (horaFim > horaInicio && horaFim <= horaFechaConsultorio);

                if ((inicio && fim) && (horaInicio.Minutes % 15 == 0 && horaFim.Minutes % 15 == 0))
                {
                    const string HORACERTA = "1";
                    return HORACERTA;
                }
                const string HORAINCORRETA = "0";
                return HORAINCORRETA;
            }
            catch
            {
                const string CONVERSAODEHORAINVALIDA = "-1";
                return CONVERSAODEHORAINVALIDA;
            }
        }

        /// <summary>
        /// Esse método valida a data da consulta da classe <class>Consulta</class>,
        /// e a data de nascimento da classe <class>Paciente</class>
        /// caso seja valida, o programa retorna true, caso contrario, o programa retorna false;
        /// </summary>
        public bool ValidaData(string dataCompleta)
        {
            try
            {
                var data = Convert.ToDateTime(dataCompleta);
                return true;
            }
            catch
            {
                this.MsgErroData = "Data inválida";
                ImprimeMensagens.MensagemDeErro(MsgErroData);
                return false;
            }
        }

        /// <summary>
        /// Esse método verifica primeiro se a data é valida, depois converte a hora inicial e final
        /// para o formato de hora do sistema, e depois verifica se a data é uma data futura para poder agendar, 
        /// e se a hora inicial é menor que a hora final.
        /// Caso seja valida, o programa retorna true, caso contrario, o programa retorna false;
        /// </summary>
        public bool ValidaDataConsulta(string data, string horaInicial, string horaFinal)
        {
            if (ValidaData(data))
            {
                var dataConsulta = Convert.ToDateTime(data);
                var qtdDias = (int) dataConsulta.Subtract(DateTime.Today).TotalDays;

                var hora = int.Parse(ConverteHora(horaInicial, horaFinal));

                if (qtdDias >= 0 && hora > 0)
                {
                    return true;
                }
                else
                {
                    this.MsgErroData = "Hora incorreta";
                    ImprimeMensagens.MensagemDeErro(MsgErroData);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Esse método verifica se a data de nascimento é valida, e depois verifica se a idade do paciente
        /// é menor que 13 anos.
        /// </summary>
        public bool ValidaDataNascimento(string dataNascimento)
        {
            if (ValidaData(dataNascimento))
            {
                var anoAtual = DateTime.Now.Year;
                var anoNascimento = Convert.ToDateTime(dataNascimento).Year;
                var idadePaciente = anoAtual - anoNascimento;

                if (idadePaciente < 13)
                {
                    this.MsgErroData = $"Erro: paciente só tem {idadePaciente} ano(s).";
                    ImprimeMensagens.MensagemDeErro(MsgErroData);
                    return false;
                }
                return true;
            }
            return false;
        }

        public int IdadeDoPaciente(string data)
        {
            var anoAtual = DateTime.Now.Year;
            var anoNascimento = Convert.ToDateTime(data).Year;
            var idade = anoAtual - anoNascimento;

            return idade;
        }
    }
}
