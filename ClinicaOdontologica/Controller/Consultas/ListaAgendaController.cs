using ClinicaOdontologica.Model;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller.Consultas
{
    public class ListaAgendaController
    {
        public static void ListaAgenda()
        {
            string MsgListaAgenda;
            var consultaCadastroDAO = new ConsultaDAO();
            var todasConsultas = consultaCadastroDAO.Consultas();

            Console.Clear();

            MsgListaAgenda = "Apresentar a agenda T-Toda ou P-Periodo: P\n";
            Console.WriteLine();
            ImprimeMensagens.MensagemDeCadastro(MsgListaAgenda);

            char aprensentaAgenda = char.Parse(Console.ReadLine());

            if (aprensentaAgenda == 'T' || aprensentaAgenda == 't')
            {
                var datasOrdenadas = todasConsultas.OrderBy(d => d.DataConsulta).ToList();

                ImprimeLista(datasOrdenadas);
            }
            else if (aprensentaAgenda == 'P' || aprensentaAgenda == 'p')
            {
                MsgListaAgenda = "Data inicial: ";
                ImprimeMensagens.MensagemDeCadastro(MsgListaAgenda);
                string dataInicialConsulta = Console.ReadLine();

                MsgListaAgenda = "Data final: ";
                ImprimeMensagens.MensagemDeCadastro(MsgListaAgenda);
                string dataFinalConsulta = Console.ReadLine();

                var dataInicio = DateTime.Parse(dataInicialConsulta);
                var dataFim = DateTime.Parse(dataFinalConsulta);

                var datasOrdenadas = todasConsultas.OrderBy(d => dataInicio >= Convert.ToDateTime(d.DataConsulta) && dataFim <= Convert.ToDateTime(d.DataConsulta)).ToList();

                ImprimeLista(datasOrdenadas);
            }
            else
            {
                MsgListaAgenda = "Opção incorreta, digite novamente";
                ImprimeMensagens.MensagemSituacao(MsgListaAgenda);
            }
        }

        private static void ImprimeLista(List<Consulta> listaDeDatas)
        {
            var pacienteCadastroDAO = new PacienteDAO(); ;

            Console.WriteLine(@"
---------------------------------------------------------------------------------------------");
            Console.WriteLine(@"
Data        |    H.Ini    |    H.Fim    |    Tempo    |         Nome         |    Dt.Nasc.   ");
            Console.WriteLine(@"
---------------------------------------------------------------------------------------------");

            listaDeDatas.ForEach(d =>
            {
                var pacientesVerificados = pacienteCadastroDAO.ConsultarPorCpf(d.Cpf);

                var horaInicio = TimeSpan.Parse((d.HoraInicial).Replace(":", "").Insert(2, ":"));
                var horaFim = TimeSpan.Parse((d.HoraFinal).Replace(":", "").Insert(2, ":"));

                var tempo = (int)horaFim.Subtract(horaInicio).TotalHours;

                Console.WriteLine($"{d.DataConsulta} |    {d.HoraInicial}    |    {d.HoraFinal}" +
                    $"    |    {tempo}    |         {pacientesVerificados.Nome}         |    " +
                    $"{pacientesVerificados.DataNascimento}");
                
                Console.ReadKey();
            });  
        }
    }
}
