using System;
using Tool;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Core
{
    public class InputSystem:MySingleton<InputSystem>
    {
        public event Action RButtonPress,LButtonPress;
        private ArduinoPort _arduinoPort;
        private void Awake()
        {
            _arduinoPort = GetComponent<ArduinoPort>();
            _arduinoPort.OpenPort();
            
            LButtonPress += () => Debug.Log("LB");
            RButtonPress += () =>Debug.Log("RB");
        }

        private void OnDisable()
        {
            _arduinoPort.ClosePort();
            LButtonPress = null;
            RButtonPress = null;
        }

        private void Update()
        {
            var inPutStrings = _arduinoPort.Inputdata.Split(",");
            if(inPutStrings.Length != 2)  return;
            if(inPutStrings[0] == "1"|| Input.GetKeyDown(KeyCode.D))RButtonPress?.Invoke();
            if(inPutStrings[1] == "1"|| Input.GetKeyDown(KeyCode.A))LButtonPress?.Invoke();
            //TODO:解決LB觸發頻率較慢問題
        }
    }
}