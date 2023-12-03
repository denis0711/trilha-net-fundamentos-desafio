using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento()
        {

        }



        public void AdicionarVeiculo()
        {
            //Quando Adiciona o veiculo eu faço o usuario digitar todas as Opcões Cadastrais dele


            Console.WriteLine();
            Veiculo veiculo = new();
            TipoVeiculo TipoVeiculos = new();
            bool validarPlaca = true;
            string Placa = "";

            Console.WriteLine("Digite a placa do veículo para estacionar:");

            while (validarPlaca)
            {
                Placa = Console.ReadLine();

                if (veiculos.Where(x => x.Placa.ToUpper() == Placa.ToUpper()).Any())
                {
                    Console.WriteLine("Placa Ja sendo usada!");
                    Console.WriteLine("Digite Outra Placa!");
                }
                else
                {
                    validarPlaca = false;
                }
            }

            veiculo.Placa = Placa;
            veiculo.DataInicio = DateTime.Now;

            Console.WriteLine("Digite o Tipo do veículo:");
            TipoVeiculos.Tipo = Console.ReadLine();

            Console.WriteLine("Digite o Preco inicial cobrado Tipo do veículo:");
            TipoVeiculos.PrecoIncial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o Preco por hora desse veículo:");
            TipoVeiculos.PrecoPorHora = Convert.ToDecimal(Console.ReadLine());

            veiculo.Tipo = TipoVeiculos;

            this.veiculos.Add(veiculo);

        }

        public void RemoverVeiculo()
        {


            //Antes de remover o veiculo decidi mostrar para o usuario as placas disponiveis assim evitando ele 
            //digitar uma placa incorreta
            Console.WriteLine($"Digite a placa do veículo para remover:\n" +
                $"Opcões Abaixo");

            foreach (var veiculo in this.veiculos)
            {
                Console.WriteLine();
                veiculo.RetornarInformacoesVeiculoFinalizados(veiculo, "LISTA");
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            bool validaPlaca = false;

            do
            {
                string placa = Console.ReadLine();




                // Verifica se o veículo existe
                if (this.veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    Veiculo veiculo = this.veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());
                    int Horas = int.Parse(Console.ReadLine());
                    veiculo.PrecoTotal = veiculo.ValorTotal(veiculo, Horas);
                    veiculo.RetornarInformacoesVeiculoFinalizados(veiculo, null);
                    veiculo.DataEncerramento = DateTime.Now.AddHours(Horas);
                    this.veiculos.Remove(veiculo);
                    validaPlaca = false;

                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    validaPlaca = true;

                    Console.WriteLine($"As Opções corretas são");

                    foreach (var veiculo in this.veiculos)
                    {
                        Console.WriteLine();
                        veiculo.RetornarInformacoesVeiculoFinalizados(veiculo, "LISTA");
                    }

                    Console.WriteLine("--------------------------------TENTE NOVAMENTE---------------------------------------");

                }
            } while (validaPlaca);

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                foreach (var veiculo in this.veiculos)
                {
                    Console.WriteLine();
                    veiculo.RetornarInformacoesVeiculoFinalizados(veiculo, "LISTA");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
