using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;

namespace ClinicaOdontologica.Controller.Pacientes
{
    public class ListaPacientesPorNomeController
    {
        public static void ListaPacientes()
        {
            var verificacaoData = new ValidacaoDeData();
            var pacienteCadastroDAO = new PacienteDAO();
            var consultaCadastroDAO = new ConsultaDAO();

            var nomesOrdenados = pacienteCadastroDAO.NomesOrdenados();

            Console.Clear();

            Console.WriteLine(@"------------------------------------------------------");
            Console.WriteLine(@"
|    CPF   |        Nome        | Data de Nascimento |");

            nomesOrdenados.ForEach(nOrd =>
            {
                var idade = verificacaoData.IdadeDoPaciente(nOrd.DataNascimento);
                Console.WriteLine($"| {nOrd.Cpf} | {nOrd.Nome} | {nOrd.DataNascimento} | {idade} |");

                var consultasVerificadas = consultaCadastroDAO.ConsultarPorCpf(nOrd.Cpf);
                if (consultasVerificadas != null)
                {
                    Console.WriteLine(@$"
Agendado para: | {consultasVerificadas.DataConsulta}
               | {consultasVerificadas.HoraInicial}  |");
                }
            });
            Console.WriteLine(@"------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
