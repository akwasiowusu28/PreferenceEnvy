using System;
namespace Core.Entities
{
    public interface IPreference : IEntity
    {
        string DefaultValue { get; set; }
        Entity Name { get; set; }
        string Type { get; set; }
        Value[] Values { get; set; }
    }
}
