using System;
using Tool;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace Core
{
    public class InputSystem:StaticSingleton<InputSystem>
    {
        public event Action RButtonPress,LButtonPress;
        
        private ArduinoPort _arduinoPort;

        public void Intialize()
        {
            LButtonPress = null;
            RButtonPress = null;
        }
        
        private void Awake()
        {
            _arduinoPort = GetComponent<ArduinoPort>();
            _arduinoPort.OpenPort();
        }

        private void OnDisable()
        {
            _arduinoPort.ClosePort();
            Intialize();
        }
        private void Update()
        {
            if(Input.GetKey(KeyCode.D))RButtonPress?.Invoke();
            if(Input.GetKey(KeyCode.A))LButtonPress?.Invoke();
            
            var inPutStrings = _arduinoPort.Inputdata.Split(",");
            if (inPutStrings.Length == 2)
            {
                if(inPutStrings[0] == "1")RButtonPress?.Invoke();
                if(inPutStrings[1] == "1")LButtonPress?.Invoke();
            };
            
            //TODO:解決LB觸發頻率較慢問題
        }
        
    }
}