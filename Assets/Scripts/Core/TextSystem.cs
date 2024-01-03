
using System;
using System.IO;
using Tool;
using UnityEngine;
using TextReader = Tool.TextReader;

public class TextSystem : MySingleton<TextSystem>
{
    private string[] currentActorSelection;
    
    private string SuSelectionPath = "/Dialog/SuSelection.txt";

    private void Start()
    {
        currentActorSelection =  TextReader.ReadALLString(SuSelectionPath).Split("\n");

        Debug.Log(currentActorSelection[0]);
    }
}
