using ExamenCalidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.DB.Map
{
    public class IngresosMap:IEntityTypeConfiguration<Ingresos>
    {
        public void Configure(EntityTypeBuilder<Ingresos> builder)
        {
            builder.ToTable("Ingresos");
            builder.HasKey(ingreso => ingreso.Id);
            builder.HasOne(ingreso => ingreso.Cuenta)
                .WithMany()
                .HasForeignKey(ingreso => ingreso.CuentaId);
        }
        
    }
}
