using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRD.Models.SeedData
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Василий",
                    Surname = "Петров",
                    Patronymic = "Олегович"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Петр",
                    Surname = "Иванов",
                    Patronymic = "Михайлович"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Матвей",
                    Surname = "Качуровский",
                    Patronymic = "Вячеславович"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Екатерина",
                    Surname = "Шабунина",
                    Patronymic = "Юрьевна"
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Атнонина",
                    Surname = "Бочарникова",
                    Patronymic = "Николаевна"
                },
                new Employee()
                {
                    Id = 6,
                    Name = "Юлия",
                    Surname = "Шумкова",
                    Patronymic = "Михайловна"
                },
                new Employee()
                {
                    Id = 7,
                    Name = "Борис",
                    Surname = "Шимякин",
                    Patronymic = "Борисович"
                }
                );
        }
    }
}