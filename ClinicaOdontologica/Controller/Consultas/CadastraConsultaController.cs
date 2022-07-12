using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller.Consultas
{
    public class CadastraConsultaController
    {
        public static void Cadastra()
        {
            string MsgDeCadastro;

            var pacienteCadastroDAO = new PacienteDAO();
            var consultaCadastroDAO = new ConsultaDAO();
            var verificacaoCpf = new ValidacaoDeCpf();
            var verificacaoData = new ValidacaoDeData();

            Console.Clear();

            string cpf;
            do
            {
                MsgDeCadastro = "CPF: ";
                ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                cpf = Console.ReadLine();

            } while (!verificacaoCpf.ValidaCpf(cpf));

            var pacienteCadastrado = pacienteCadastroDAO.ConsultarPorCpf(cpf);

            bool a = pacienteCadastroDAO.Contains(pacienteCadastrado);

            if (a)
            {
                string dataConsulta;
                string horaInicial;
                string horaFinal;

                do
                {
                    MsgDeCadastro = "Data da Consulta: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    dataConsulta = Console.ReadLine();

                    MsgDeCadastro = "Hora inicial: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    horaInicial = Console.ReadLine();

                    MsgDeCadastro = "Hora final: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    horaFinal = Console.ReadLine();

                } while (!verificacaoData.ValidaDataConsulta(dataConsulta, horaInicial, horaFinal));

                var novaConsulta = new Consulta(cpf, dataConsulta, horaInicial, horaFinal);

                bool jaTemConsulta = consultaCadastroDAO.Contains(novaConsulta);

                if (!jaTemConsulta)
                {
                    consultaCadastroDAO.Add(novaConsulta);

                    MsgDeCadastro = "Agendamento realizado com sucesso!";
                    ImprimeMensagens.MensagemSituacao(MsgDeCadastro);
                }
                else
                {
                    MsgDeCadastro = "Erro: já existe uma consulta agendada nesta data/hora";
                    ImprimeMensagens.MensagemSituacao(MsgDeCadastro);
                }
            }
            else
            {
                MsgDeCadastro = "Erro: paciente não cadastrado";
                ImprimeMensagens.MensagemSituacao(MsgDeCadastro);
            }
        }
    }
}
