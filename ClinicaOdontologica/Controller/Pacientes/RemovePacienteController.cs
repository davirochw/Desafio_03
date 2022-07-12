using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller.Pacientes
{
    public class RemovePacienteController
    {
        public static void Remove()
        {
            string MsgRemoverPaciente;

            var pacienteCadastroDAO = new PacienteDAO();
            var consultaCadastroDAO = new ConsultaDAO();

            Console.Clear();

            MsgRemoverPaciente = "CPF: ";
            ImprimeMensagens.MensagemDeCadastro(MsgRemoverPaciente);
            string cpf = Console.ReadLine();

            var pacienteCadastrado = pacienteCadastroDAO.ConsultarPorCpf(cpf);

            if (pacienteCadastroDAO.Contains(pacienteCadastrado))
            {
                var pacienteComConsultaFutura = consultaCadastroDAO.ConsultaFutura(cpf);

                if (pacienteComConsultaFutura == null)
                {
                    pacienteCadastroDAO.Remove(cpf);

                    MsgRemoverPaciente = "Paciente removido com sucesso!";
                    ImprimeMensagens.MensagemSituacao(MsgRemoverPaciente);
                }
                else
                {
                    MsgRemoverPaciente = $"Erro: paciente está agendado para {pacienteComConsultaFutura.DataConsulta} as {pacienteComConsultaFutura.HoraInicial}h.";
                    ImprimeMensagens.MensagemSituacao(MsgRemoverPaciente);
                }
            }
            else
            {
                MsgRemoverPaciente = "Erro: paciente não cadastrado";
                ImprimeMensagens.MensagemSituacao(MsgRemoverPaciente);
            }
        }
    }
}
