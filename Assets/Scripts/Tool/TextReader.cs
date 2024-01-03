using System.Collections.Generic;
using System.IO;
using UnityEngine.Device;
using Application = UnityEngine.Application;

namespace Tool
{
    public class TextReader 
    {
        public static string ReadALLString(string path)
        {
            
            StreamReader reader = new StreamReader(Application.dataPath+ path);
            string _myText = reader.ReadToEnd();
            reader.Close();
            return _myText;
        }
        
    }
}
