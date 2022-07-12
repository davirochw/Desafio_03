using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.View
{
    public class Menu
    {
        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine(@"Menu Principal
1 - Cadastro de Paciente
2 - Agenda
3 - Fim
");
        }

        public static void MenuAgenda()
        {
            Console.Clear();
            Console.WriteLine(@"Agenda
1 - Agendar consulta
2 - Cancelar agendamento
3 - Listar agenda
4 - Voltar p/ menu principal
");
        }

        public static void MenuCadastroPaciente()
        {
            Console.Clear();
            Console.WriteLine(@"Menu Cadastro de Pacientes
1 - Cadastrar novo paciente
2 - Excluir paciente
3 - Listar pacientes(ordenado por CPF)
4 - Listar pacientes(ordenado por nome)
5 - Voltar p / menu principal
");
        }
    }
}
