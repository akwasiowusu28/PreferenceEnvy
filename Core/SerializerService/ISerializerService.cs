using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SerializerService
{
    public interface ISerializerService
    {
        void Serialize<T>(string filename, object obj);
        T Deserialize<T>(string filename) where T : new();
    }
}
