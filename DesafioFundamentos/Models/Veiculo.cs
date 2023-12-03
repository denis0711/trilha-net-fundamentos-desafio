using System.Globalization;

namespace DesafioFundamentos.Models;

public class Veiculo
{

    public string Placa { get; set; }

    public TipoVeiculo Tipo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataEncerramento { get; set; }
    public decimal PrecoTotal { get; set; }


    public void RetornarInformacoesVeiculoFinalizados(Veiculo veiculo, string tipo)
    {
        if (tipo == "LISTA")
        {
            Console.WriteLine($"Veiculo do Tipo: {veiculo.Tipo.Tipo} da Placa: {veiculo.Placa}\n");
        }
        else
        {
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");


            Console.WriteLine($"Veiculo do Tipo: {veiculo.Tipo.Tipo} da Placa: {veiculo.Placa} Foi Encerrado com Sucesso!\n" +
                $"Entrou:{veiculo.DataInicio.ToString("dd/MM/yyyy HH:mm")} e Saiu as {DataEncerramento.ToString("dd/MM/yyyy HH:mm")}, dando um Total a ser pago de \n" +
                $"{veiculo.PrecoTotal.ToString("C2", culturaBrasileira)}");
        }
       
    }



    public decimal ValorTotal(Veiculo veiculo, int HorasTotal)
    {
        var PrecoIncial = veiculo.Tipo.PrecoIncial;
        var PrecoTotalHora = veiculo.Tipo.PrecoPorHora * HorasTotal;

        return PrecoIncial + PrecoTotalHora;

    }
}

