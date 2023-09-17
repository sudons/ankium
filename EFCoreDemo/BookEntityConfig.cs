﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo
{
    public class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            builder.Property(e => e.Title).HasMaxLength(50).IsRequired();
            builder.Property(e => e.AuthorName).HasMaxLength(50).HasColumnType("varchar200");
        }
    }
}
