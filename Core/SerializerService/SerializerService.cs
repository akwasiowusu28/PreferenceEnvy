using Support.Exceptions;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Core.SerializerService
{
   public class SerializerService : ISerializerService
    {
        #region Constructors
        
        public SerializerService()
        {
        }
        
        #endregion

        #region Methods

        #region Public

        public void Serialize<T>(string filename,object obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(filename, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }

        public T Deserialize<T>(string filename) where T : new()
        {
            T obj = default(T);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                obj = (T)ser.Deserialize(fs);
                fs.Close();
            }
            catch (FileNotFoundException ex)
            {
                throw new CoreException(ex.Message, ex);
            }

            return obj;
        }

        #endregion

        #endregion
    }
}
