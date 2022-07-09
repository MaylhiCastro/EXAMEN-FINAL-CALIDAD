using ExamenCalidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.DB.Map
{
    public class GastosCMap: IEntityTypeConfiguration<GastosC>
    {
        public void Configure(EntityTypeBuilder<GastosC> builder)
        {
            builder.ToTable("Gastos");
            builder.HasKey(gasto => gasto.Id);
            builder.HasOne(gasto => gasto.Cuenta)
                .WithMany()
                .HasForeignKey(gasto => gasto.CuentaId);
        }
    }
}
