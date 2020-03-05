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
            Console.Write("Salario R$: ");
            Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Data de Nascimento ex.dd/mm/aaaa: ");
            ValidandoDataNascimento();
            Console.Write("CPF ex.999.999.999-99: ");
            CPF = Console.ReadLine();
            while (!ValidandoCpf(CPF))
            {
                Console.WriteLine("CPF Inválido");
                Console.Write("Digite Novamente: ");
                CPF = Console.ReadLine();
                ValidandoCpf(CPF);
            }
            
            Console.Write("Sexo M / F: ");
            Sexo = char.Parse(Console.ReadLine());

            while (!(Sexo == 'm' || Sexo == 'f' || Sexo == 'M' || Sexo == 'F'))
            {   
                Console.WriteLine("Favor inserir somente: m / f ou M / F");
                Console.Write("Digite Novamente: ");
                Sexo = char.Parse(Console.ReadLine());
            } 

            Console.Write("Nascionalidade: ");
            Nacionalidade = Console.ReadLine();
            Console.Write("Cargo: ");
            Cargo = Console.ReadLine();
            Console.Write("Status 0 - Trabalhando / 1 - Desligado: ");
            string Status = Console.ReadLine();
            Status status = (Status)Enum.Parse(typeof(Status), Status);
            if (Status != "0"|| Status != "Trabalhando" || Status != "1" || Status != "Desligado")
            {
                Console.WriteLine("Favor Usar Somente as opções: 0 - Trabalhando / 1 - Desligado  ");
                Console.Write("Digite Novamente: ");
                Status = Console.ReadLine();
                status = (Status)Enum.Parse(typeof(Status), Status);

            }
            Console.WriteLine("====================================");
        }

        public bool ValidandoCpf(string CPF)
        {
            int multiplicador1 = 10;
            int multiplicador2 = 11;

            string temCPF;
            string Digito;
            int Soma;
            int Resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length!=11)
              return false;
          

            temCPF = CPF.Substring(0, 9);
            Soma = 0;

            for (int i = 0; i < 9; i++)
            {
                Soma += int.Parse(temCPF[i].ToString()) * (multiplicador1-i);
            }

            Resto = Soma % 11;

            if (Resto < 2)
            {
                Resto = 0;
            }
            else 
            {
                Resto = 11 - Resto;
            }

            Digito = Resto.ToString();
            temCPF = temCPF + Digito;

            Soma = 0;

            for (int i = 0; i < 10; i++)
            {
                Soma += int.Parse(temCPF[i].ToString()) * (multiplicador2-i);
            }

            Resto = Soma % 11;

            if (Resto < 2)
            {
                Resto = 0;
            }
            else
            {
                Resto = 11 - Resto;
            }

            Digito = Digito + Resto.ToString();

            return CPF.EndsWith(Digito);
            
        }
        public static bool ValidandoDataNascimento() 
        {
            DateTime Data_Nasc;
               var convertido = DateTime
                .TryParseExact(Console.ReadLine(),
                               "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out Data_Nasc);
            while ((convertido == false))
            {
                Console.WriteLine("Formato incorreto!!!");
                Console.Write("Favor insira data correta: ");
                convertido = DateTime
                .TryParseExact(Console.ReadLine(),
                               "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out Data_Nasc);
            }
            if (Data_Nasc > DateTime.Now)
            {
                Console.WriteLine("Data de Nascimento inválida!!!");
                Console.Write("Favor insira data correta: ");
                convertido = DateTime
                .TryParseExact(Console.ReadLine(),
                               "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out Data_Nasc);
            }
            return convertido;
        }
        



        

    }
}
