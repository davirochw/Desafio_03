using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaOdontologica.Model;
using ClinicaOdontologica.Model.Validator;
using ClinicaOdontologica.View;

namespace ClinicaOdontologica.Controller.Pacientes
{
    public class CadastraPacienteController
    {
        public static void Cadastra()
        {
            string MsgDeCadastro;

            var verificacaoCpf = new ValidacaoDeCpf();
            var verificacaoNome = new ValidacaoDeNome();
            var verificacaoDataNascimento = new ValidacaoDeData();
            var pacienteCadastroDAO = new PacienteDAO();

            Console.Clear();

            while (true)
            {
                string cpf;
                do
                {
                    MsgDeCadastro = "CPF: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    cpf = Console.ReadLine();

                } while (!verificacaoCpf.ValidaCpf(cpf));

                string nome;
                do
                {
                    MsgDeCadastro = "Nome: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    nome = Console.ReadLine();

                } while (!verificacaoNome.ValidaNome(nome));

                string dataNascimento;
                do
                {
                    MsgDeCadastro = "Data de Nascimento: ";
                    ImprimeMensagens.MensagemDeCadastro(MsgDeCadastro);
                    dataNascimento = Console.ReadLine();

                } while (!verificacaoDataNascimento.ValidaDataNascimento(dataNascimento));

                var novoPaciente = new Paciente(cpf, nome, dataNascimento);

                var verificaPacienteCadastrado = pacienteCadastroDAO.Contains(novoPaciente);

                if (verificaPacienteCadastrado)
                {
                    MsgDeCadastro = "Paciente já está cadastrado";
                    ImprimeMensagens.MensagemSituacao(MsgDeCadastro);
                }
                else
                {
                    pacienteCadastroDAO.Add(novoPaciente);

                    MsgDeCadastro = "Cadastro realizado com sucesso!";
                    ImprimeMensagens.MensagemSituacao(MsgDeCadastro);
                    return;
                }
            }
        }
    }
}
