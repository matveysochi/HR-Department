using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRD.Models.SeedData
{
    class DivisionMovementConfiguration : IEntityTypeConfiguration<DivisionMovement>
    {
        public void Configure(EntityTypeBuilder<DivisionMovement> builder)
        {
            builder
                .HasData(
                new DivisionMovement()
                {
                    Id = 1,
                    DivisionId = 1,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 2,
                    DivisionId = 2,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 3,
                    DivisionId = 3,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 4,
                    DivisionId = 4,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 5,
                    DivisionId = 5,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 6,
                    DivisionId = 6,
                    ParentDivisionId = 3,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 7,
                    DivisionId = 7,
                    ParentDivisionId = 5,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 8,
                    DivisionId = 8,
                    ParentDivisionId = 4,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 9,
                    DivisionId = 9,
                    ParentDivisionId = 5,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 10,
                    DivisionId = 10,
                    ParentDivisionId = 9,
                    MovementType = DivisionMovementTypes.Включить,
                    Date = new DateTime(2021, 1, 1)
                },
                new DivisionMovement()
                {
                    Id = 11,
                    DivisionId = 4,
                    ParentDivisionId = 3,
                    MovementType = DivisionMovementTypes.Перемещение,
                    Date = new DateTime(2021, 1, 15)
                }
                );
        }
    }
}