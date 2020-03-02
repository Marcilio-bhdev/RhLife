using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RH_Life.Entities
{
    public class Banco
    {
        public List<Funcionarios> listRh = new List<Funcionarios>();

        public void AddFuncionario() 
        {
            listRh.Add(new Funcionarios(listRh));
        }

        public void FolhaDePagamento()
        {
            for (int i = 0; i < listRh.Count; i++)
            {
                double percento = (listRh[i].Salario * 55)/100;
                double rendimento = listRh[i].Salario * 12;
                Console.WriteLine("===================================");
                Console.WriteLine("|        Folha de Pagamento       |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].Nome}");
                Console.WriteLine($"Salario unitario  {listRh[i].Salario.ToString("F2", CultureInfo.InvariantCulture)} Rendimento anual sem imposto: {rendimento.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Salario unitario {listRh[i].Salario.ToString("F2", CultureInfo.InvariantCulture)} Rendimento anual com imoposto {(rendimento.ToString("F2", CultureInfo.InvariantCulture) + percento)}");
                Console.WriteLine("===================================");
            } 
        }

        public void AlteraSalario()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Alterando Salario        |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaSalario = listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            Console.Write("Digita o novo cargo: ");
            mudaSalario.Cargo = Console.ReadLine();
            Console.Write("Altere o salario: ");
            mudaSalario.Salario = double.Parse(Console.ReadLine());
        }

        public void DesligarFuncionario() 
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Desligando Empregado     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.WriteLine("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaStatus= listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            Console.WriteLine("Altere o Status do funcionario: ");
            //mudaStatus.Status = Console.ReadLine();
        }

        
    }
}
