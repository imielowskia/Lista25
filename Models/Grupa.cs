using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lista25.Models;

[Table("grupas", Schema = "dbo")]
public partial class Grupa
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("grupa")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Grupa1 { get; set; }

    [InverseProperty("Grupa")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
