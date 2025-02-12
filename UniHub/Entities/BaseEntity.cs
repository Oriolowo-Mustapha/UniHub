using MassTransit;

namespace UniHub.Entities;

public class BaseEntity
{
    public Guid Id { get; set; } = NewId.Next().ToGuid();
    public DateTime DateOfCreation = DateTime.UtcNow;
}