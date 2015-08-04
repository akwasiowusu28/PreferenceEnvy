using System;
namespace Core.Entities
{
    public interface IValue : IEntity
    {
        Entity Name { get; set; }
    }
}
