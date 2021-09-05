using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRD.Models.SeedData
{
    class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder
                .HasData(
                new Division()
                {
                    Id = 1,
                    Code = "001",
                    Name = "АУП",
                },
                new Division()
                {
                    Id = 2,
                    Code = "002",
                    Name = "Бухгалтерия",
                },
                new Division()
                {
                    Id = 3,
                    Code = "003",
                    Name = "Техническая служба",
                },
                new Division()
                {
                    Id = 4,
                    Code = "004",
                    Name = "ИТ",
                },
                new Division()
                {
                    Id = 5,
                    Code = "005",
                    Name = "СПИР",
                },
                new Division()
                {
                    Id = 6,
                    Code = "006",
                    Name = "Дворники",
                },
                new Division()
                {
                    Id = 7,
                    Code = "007",
                    Name = "Горничные",
                },
                new Division()
                {
                    Id = 8,
                    Code = "008",
                    Name = "Отдел связи",
                },
                new Division()
                {
                    Id = 9,
                    Code = "009",
                    Name = "СПА",
                }
                ,
                new Division()
                {
                    Id = 10,
                    Code = "010",
                    Name = "Бассейн",
                }
                );
        }
    }
}