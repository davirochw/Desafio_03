using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;

namespace ClinicaOdontologica.Controller.Pacientes
{
    public class ListaPacientesPorCPFController
    {
        public static void ListaPacientes()
        {
            var verificacaoData = new ValidacaoDeData();
            var pacienteCadastroDAO = new PacienteDAO();
            var consultaCadastroDAO = new ConsultaDAO();

            var cpfsOrdenados = pacienteCadastroDAO.CpfsOrdenados();

            Console.Clear();

            Console.WriteLine(@"------------------------------------------------------");
            Console.WriteLine(@"
|    CPF   |        Nome        | Data de Nascimento |");

            cpfsOrdenados.ForEach(cOrd =>
            {
                var idade = verificacaoData.IdadeDoPaciente(cOrd.DataNascimento);
                Console.WriteLine(@$"| {cOrd.Cpf} | {cOrd.Nome} | {cOrd.DataNascimento} | {idade} |");

                var consultasVerificadas = consultaCadastroDAO.ConsultarPorCpf(cOrd.Cpf);
                if (consultasVerificadas != null)
                {
                    var horaConsulta = TimeSpan.Parse((consultasVerificadas.HoraInicial).Replace(":", "").Insert(2, ":"));

                    Console.WriteLine(@$"
Agendado para: | {consultasVerificadas.DataConsulta}
               | {horaConsulta}  |");
                }
            });
            Console.WriteLine(@"------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
