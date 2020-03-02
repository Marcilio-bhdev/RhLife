using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using RH_Life.Entities.Enums;

namespace RH_Life.Entities
{
    public class Funcionarios
    {
        public string Nome { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public double Salario { get; set; }
        public double Aumento { get; set; }
        public double Reajuste { get; set; }
        public string Cargo { get; set; }
        public Status Status { get; set; }

        public Funcionarios(List<Funcionarios> listRh)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("|  Cadastro de Funcionários |");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.Write("Nome: ");
            Nome = Console.ReadLine();
            Console.Write("Salario: ");
            Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Data de Nascimento: ");
            Data_Nasc = DateTime.Parse(Console.ReadLine());
            Console.Write("CPF: ");
            CPF = Console.ReadLine();
            Console.Write("Sexo: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.Write("Nascionalidade: ");
            Nacionalidade = Console.ReadLine();
            Console.Write("Cargo: ");
            Cargo = Console.ReadLine();
            Console.Write("Status: ");
            string Status = Console.ReadLine();
            Status status = (Status)Enum.Parse(typeof(Status), Status);
            Console.WriteLine("====================================");

        }

    }
}
