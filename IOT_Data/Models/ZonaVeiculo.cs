using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IOT_Data.Models
{
    public class ZonaVeiculo : IEquatable<ZonaVeiculo>
    {

        public int VeiculoId { get; set; }
        public int ZonaId { get; set; }

        public bool Equals( ZonaVeiculo other)
        {
            return VeiculoId.Equals(other.VeiculoId);
        }
    }
   
}
