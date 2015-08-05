using System;
namespace Entities
{
    public interface IValue : IEntity
    {
        Entity Name { get; set; }
    }
}
