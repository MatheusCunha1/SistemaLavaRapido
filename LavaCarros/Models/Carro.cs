public class Carro
{
    public int Id { get; set; }
    public string Dono { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int? TipoLavagemId { get; set; }
    public ServicoLavagem? TipoLavagem { get; set; }

    public Carro(string dono, string placa, string modelo)
    {
        Dono = dono;
        Placa = placa;
        Modelo = modelo;
    }
}
