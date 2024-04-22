namespace CTRLInvesting.Model.CalculadoraRendaFixa;

public class CalculadoraSelic
{
    public double? valorInicial { get; set; }
    public double? valorMensal { get; set; } = 0;
    public int? Prazo { get; set; }
    public double? PercentualRentabilidade { get; set; }
    public string AnoMes { get; set; } = "Ano";
    public string AnoMesPercentual { get; set; } = "Ano";
}
