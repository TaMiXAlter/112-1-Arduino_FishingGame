using System.IO;
using Application = UnityEngine.Application;

namespace Core.Assest
{
    public class TextReader 
    {
        public string ReadALLString(string path)
        {
            
            StreamReader reader = new StreamReader(Application.dataPath+ path);
            string _myText = reader.ReadToEnd();
            reader.Close();
            return _myText;
        }
        
    }
}
