using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using RH_Life.Entities.Enums;
using RH_Life.Entities.Controller;

namespace RH_Life.Entities
{
    public class Funcionarios
    {
        public string nome { get; set; }
        public DateTime data_nasc { get; set; }
        public string cpf { get; set; }
        public char sexo { get; set; }
        public string nacionalidade { get; set; }
        public double salario { get; set; }
        public string cargo { get; set; }
        public Status status { get; set; }

        public Funcionarios(List<Funcionarios> listRh)
        {
            Metodos metodos = new Metodos();
            
            Console.WriteLine("=============================");
            Console.WriteLine("|  Cadastro de Funcionário  |");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            bool aprovado = true;
            List<char> numerais = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            while (aprovado)
            {
                if (numerais.Where(x => nome.Contains(x)).Any())
                {
                    Console.WriteLine("Entrada incorreta");
                    Console.Write("Digite novamente: ");
                    nome = Console.ReadLine();
                }
                else if (nome.Length > 50)
                {
                    Console.WriteLine("Numero de caractere excedido");
                    Console.Write("Digite Novamente: ");
                    nome = Console.ReadLine();
                }
                else 
                {
                    aprovado = false;
                }
            }
            Console.Write("Salario R$: ");
            salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Data de Nascimento ex.dd/mm/aaaa: ");
            data_nasc = metodos.ValidandoDataNascimento(listRh);
            Console.Write("CPF ex.999.999.999-99: ");
            cpf = Console.ReadLine();
            bool validador = !metodos.ValidandoCpf(cpf) || metodos.ConfereCpfDuplicado(listRh, cpf); // Criei uma variável booleana recebendo os 2 metodos
            while (validador)// o while vai avaliar os metodos 
            {
                if (!metodos.ValidandoCpf(cpf))
                {
                    Console.WriteLine("CPF Inválido");
                    Console.Write("Digite Novamente: ");
                    cpf = Console.ReadLine();
                }
                else if (metodos.ConfereCpfDuplicado(listRh, cpf))
                {
                    Console.WriteLine("CPF já consta no banco de dados!!!!");
                    Console.Write("Digite Novamente: ");
                    cpf = Console.ReadLine();
                }
                else 
                {
                    validador = false;
                }
            }
            Console.Write("Sexo M / F: ");
            sexo = char.Parse(Console.ReadLine());

            while (!(sexo == 'm' || sexo == 'f' || sexo == 'M' || sexo == 'F'))
            {
                Console.WriteLine("Favor inserir somente: m / f ou M / F");
                Console.Write("Digite Novamente: ");
                sexo = char.Parse(Console.ReadLine());
            }
            Console.Write("Nacionalidade: ");
            nacionalidade = Console.ReadLine();
            bool teste = true;
            List<char> numeros = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            while (teste)
            {    /* usei Lambda expression
                 * .where para ele verificar dentro da
                 * variaval Nacionalidade se tem Valor */
                if (numeros.Where(x => nacionalidade.Contains(x)).Any())
                {
                    Console.WriteLine("Entrada não Aceita");
                    Console.Write("Digite Novamente: ");
                    nacionalidade = Console.ReadLine();
                }
                else if (nacionalidade.Length >= 20)
                {
                    Console.WriteLine("Numero de caractere excedido");
                    Console.Write("Digite Novamente: ");
                    nacionalidade = Console.ReadLine();
                }
                else
                {
                    teste = false;
                }
            }
            Console.Write("Cargo: ");
            cargo = Console.ReadLine();
            while (cargo.Length >= 20)
            {
                Console.WriteLine("Numero de caractere extenso.");
                Console.Write("Digite novamente: ");
                cargo = Console.ReadLine();
            }
            Console.Write("Status 0 - Trabalhando / 1 - Desligado: ");
            string Status = Console.ReadLine();
            Status status = (Status)Enum.Parse(typeof(Status), Status);
            while (!(Status == "0" || Status == "Trabalhando" || Status == "1" || Status == "Desligado"))
            {
                Console.WriteLine("Favor Usar Somente as opções: 0 - Trabalhando / 1 - Desligado  ");
                Console.Write("Digite Novamente: ");
                Status = Console.ReadLine();
                status = (Status)Enum.Parse(typeof(Status), Status);
            }
            Console.WriteLine("====================================");
        }

        
    }
}
