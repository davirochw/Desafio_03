using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller.Consultas
{
    public class CancelaConsultaController
    {
        public static void Cancela()
        {
            string MsgDeCacelamento;

            var pacienteCadastroDAO = new PacienteDAO();
            var consultaCadastroDAO = new ConsultaDAO();

            Console.Clear();

            MsgDeCacelamento = "CPF: ";
            ImprimeMensagens.MensagemDeCadastro(MsgDeCacelamento);
            string cpf = Console.ReadLine();

            var pacienteCadastrado = pacienteCadastroDAO.ConsultarPorCpf(cpf);

            if (pacienteCadastroDAO.Contains(pacienteCadastrado))
            {
                MsgDeCacelamento = "Data da Consulta: ";
                ImprimeMensagens.MensagemDeCadastro(MsgDeCacelamento);
                string dataConsulta = Console.ReadLine();

                MsgDeCacelamento = "Hora inicial: ";
                ImprimeMensagens.MensagemDeCadastro(MsgDeCacelamento);
                string horaInicial = Console.ReadLine();

                var existeConsulta = consultaCadastroDAO.Remove(cpf, dataConsulta, horaInicial);

                if (existeConsulta)
                {
                    MsgDeCacelamento = "Agendamento cancelado com sucesso!";
                    ImprimeMensagens.MensagemSituacao(MsgDeCacelamento);
                }
                else
                {
                    MsgDeCacelamento = "Erro: agendamento não encontrado";
                    ImprimeMensagens.MensagemSituacao(MsgDeCacelamento);
                }
            }
            else
            {
                MsgDeCacelamento = "Erro: paciente não cadastrado";
                ImprimeMensagens.MensagemSituacao(MsgDeCacelamento);
            }
        }
    }
}
