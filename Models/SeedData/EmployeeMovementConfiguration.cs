using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRD.Models.SeedData
{
    class EmployeeMovementConfiguration : IEntityTypeConfiguration<EmployeeMovement>
    {
        public void Configure(EntityTypeBuilder<EmployeeMovement> builder)
        {
            builder
                .HasData(
                new EmployeeMovement()
                {
                    Id = 1,
                    EmployeeId = 1,
                    DivisionId = 1,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 2,
                    EmployeeId = 2,
                    DivisionId = 1,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 3,
                    EmployeeId = 3,
                    DivisionId = 4,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 4,
                    EmployeeId = 4,
                    DivisionId = 5,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 5,
                    EmployeeId = 5,
                    DivisionId = 3,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 6,
                    EmployeeId = 6,
                    DivisionId = 2,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 7,
                    EmployeeId = 7,
                    DivisionId = 10,
                    MovementType = EmployeeMovementTypes.Найм,
                    Date = new DateTime(2021, 1, 1)
                },
                new EmployeeMovement()
                {
                    Id = 8,
                    EmployeeId = 4,
                    DivisionId = 1,
                    MovementType = EmployeeMovementTypes.Перемещение,
                    Date = new DateTime(2021, 1, 15)
                }
                );
        }
    }
}