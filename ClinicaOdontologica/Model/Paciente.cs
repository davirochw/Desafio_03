using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Model
{
    public class Paciente
    {
        /*[Key]*/
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }

        public Paciente(string cpf, string nome, string dataNascimento)
        {
            /*Id += 1;*/
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
