namespace Core.Assest
{
    public class TextSorter
    {
        public string[] GetActorSectionTextFromPath(string path,TextReader _textReader)
        {
            return  _textReader.ReadALLString(path).Split("\n");
        }

        public string[] GetQAtext(string Selctions)
        {
            return Selctions.Split("/");
        }
    }
}
