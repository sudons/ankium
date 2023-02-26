using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //实体类Book对应数据库中名字为T_Books的表
            builder.ToTable("T_Books");
            builder.Property(e=>e.Title).HasMaxLength(50).IsRequired();
            builder.Property(e=>e.AuthorName).HasMaxLength(20).IsRequired();
        }
    }
}
