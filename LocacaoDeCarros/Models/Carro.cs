using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoDeCarros.Models;

[Table("CARROS")]
public class Carro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [Required]
    [MaxLength(100)]
    public string Modelo { get; private set; }

    [Required]
    [MaxLength(100)]
    public string Marca { get; private set; }

    [Required]
    public int Ano { get; private set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorDiaria { get; private set; }

    // Construtor para EF Core (não deve ser usado diretamente)
    protected Carro()
    {
        Modelo = null!;
        Marca = null!;
    }

    public Carro(string modelo, string marca, int ano, decimal valorDiaria)
    {
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
        ValorDiaria = valorDiaria;
    }

    public void Atualizar(string modelo, string marca, int ano, decimal valorDiaria)
    {
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
        ValorDiaria = valorDiaria;
    }
}
