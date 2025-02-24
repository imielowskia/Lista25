using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lista25.Models;

[Table("students", Schema = "dbo")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("indeks")]
    [StringLength(6)]
    public string Indeks { get; set; } = null!;

    [Column("imie")]
    [StringLength(50)]
    public string Imie { get; set; } = null!;

    [Column("nazwisko")]
    [StringLength(50)]
    public string Nazwisko { get; set; } = null!;

    [Column("grupa_id")]
    public int? GrupaId { get; set; }

    [ForeignKey("GrupaId")]
    [InverseProperty("Students")]
    public virtual Grupa? Grupa { get; set; }
}
