using System.Collections.Generic;
using System.IO;
using Class;
using Application = UnityEngine.Application;

namespace Dialog
{
    public class TextReader 
    {
        private string ReadALLString(string path)
        {
            StreamReader reader = new StreamReader(Application.dataPath+ path);
            string _myText = reader.ReadToEnd();
            reader.Close();
            return _myText;
        }
        
        public  List<Selection> GetSortSelectionData (string _selectionPath,string _answerPath)
        {
            List<Selection> _selection = new List<Selection>();
            string[] SelectionState = ReadALLString(_selectionPath).Split("\n");
            string[] AnswerState = ReadALLString(_answerPath).Split("\n");
            
            for (int i = 0; i < SelectionState.Length; i++)
            {
                string[] _selectionText = SelectionState[i].Split("/");
                string[] _answerText = AnswerState[i].Split("/");
                _selection[i].RightSelection = _selectionText[0];
                _selection[i].WrongSelection = _selectionText[1];
                _selection[i].RightAnswer = _answerText[0];
                _selection[i].WrongAnswer = _answerText[1];
            }

            return _selection;
        }
    }
    public class Selection
    {
        public string RightSelection,WrongSelection,RightAnswer,WrongAnswer;
    }
}
