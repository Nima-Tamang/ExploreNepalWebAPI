﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Models
{
    
    public  class TblProductimage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("productcode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Productcode { get; set; }

        [Column("productimage", TypeName = "image")]
        public byte[]? Productimage { get; set; }
    }
}
