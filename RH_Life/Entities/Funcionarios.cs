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
            Console.Write("Data de Nascimento ex.dd/mm/aaaa: ");
            Data_Nasc = DateTime.Parse(Console.ReadLine());
            while (ValidandoDataNascimentos(Data_Nasc))
            {
                Console.WriteLine("Data com formato incorreto!!!");
                Console.WriteLine("Favor ensira data correta:");
                Data_Nasc = DateTime.Parse(Console.ReadLine());
                ValidandoDataNascimentos(Data_Nasc);
            }
            Console.Write("CPF: ");
            CPF = Console.ReadLine();
            while (!ValidandoCpf(CPF))
            {
                Console.WriteLine("CPF Inválido");
                Console.WriteLine("Digite Novamente");
                CPF = Console.ReadLine();
                ValidandoCpf(CPF);
            }
            
            Console.Write("Sexo M / F: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.Write("Nascionalidade: ");
            Nacionalidade = Console.ReadLine();
            Console.Write("Cargo: ");
            Cargo = Console.ReadLine();
            Console.Write("Status 0 - Trabalhando / 1 - Desligado: ");
            string Status = Console.ReadLine();
            Status status = (Status)Enum.Parse(typeof(Status), Status);
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

        public bool ValidandoDataNascimentos(DateTime Data_Nasc) 
        {
            
            var convertido = DateTime.TryParseExact(Console.ReadLine(),
                                "dd/MM/yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out Data_Nasc);
            return convertido;
        }

        //public static bool IsCnpj(string cnpj)
        //{
        //    int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int soma;
        //    int resto;
        //    string digito;
        //    string tempCnpj;
        //    cnpj = cnpj.Trim();
        //    cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        //    if (cnpj.Length != 14)
        //        return false;
        //    tempCnpj = cnpj.Substring(0, 12);
        //    soma = 0;
        //    for (int i = 0; i < 12; i++)
        //        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        //    resto = (soma % 11);
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;
        //    digito = resto.ToString();
        //    tempCnpj = tempCnpj + digito;
        //    soma = 0;
        //    for (int i = 0; i < 13; i++)
        //        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        //    resto = (soma % 11);
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;
        //    digito = digito + resto.ToString();
        //    return cnpj.EndsWith(digito);
        //}

    }
}
