using System.Collections.Generic;
using System.IO;
using Class;
using UnityEngine;


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
            List<Selection> _selections = new List<Selection>();
             string[] SelectionState = ReadALLString(_selectionPath).Split("\n");
            string[] AnswerState = ReadALLString(_answerPath).Split("\n");
            
            
            for (int i = 0; i < SelectionState.Length; i++)
            {
                Selection selection = new Selection();
                string[] _selectionText = SelectionState[i].Split("/");
                string[] _answerText = AnswerState[i].Split("/");
                selection.RightSelection = _selectionText[0];
                selection.WrongSelection = _selectionText[1];
                selection.RightAnswer = _answerText[0];
                selection.WrongAnswer = _answerText[1];
                
                _selections.Add(selection);
            }
        
            return _selections;
        }
    }
    public class Selection
    {
        public string RightSelection,WrongSelection,RightAnswer,WrongAnswer;
    }
}
