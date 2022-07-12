using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaOdontologica.Controller.Consultas;
using ClinicaOdontologica.Controller.Pacientes;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller
{
    public class MainController
    {
        public static void Iniciar()
        {
            while (true)
            {
                Menu.MenuPrincipal();

                int opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                switch (opcaoMenuPrincipal)
                {
                    case 1:
                        Menu.MenuCadastroPaciente();

                        int opcaoMenuCadastroPaciente = int.Parse(Console.ReadLine());

                        switch (opcaoMenuCadastroPaciente)
                        {
                            case 1:
                                CadastraPacienteController.Cadastra();
                                break;
                            case 2:
                                RemovePacienteController.Remove();
                                break;
                            case 3:
                                ListaPacientesPorCPFController.ListaPacientes();
                                break;
                            case 4:
                                ListaPacientesPorNomeController.ListaPacientes();
                                break;
                            case 5:
                                Menu.MenuPrincipal();
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                break;
                        }
                        break;
                    case 2:
                        Menu.MenuAgenda();

                        int opcaoMenuAgenda = int.Parse(Console.ReadLine());

                        switch (opcaoMenuAgenda)
                        {
                            case 1:
                                CadastraConsultaController.Cadastra();
                                break;
                            case 2:
                                CancelaConsultaController.Cancela();
                                break;
                            case 3:
                                ListaAgendaController.ListaAgenda();
                                break;
                            case 4:
                                Menu.MenuPrincipal();
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                break;
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
