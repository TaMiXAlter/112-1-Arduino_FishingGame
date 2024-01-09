using System;
using Tool;
using UnityEngine;

namespace Core
{
    public class InputSystem:StaticSingleton<InputSystem>
    {
        private event Action RButtonPress,LButtonPress;
        
        private ArduinoPort _arduinoPort;
        public void Intialize()
        {
            LButtonPress = null;
            RButtonPress = null;
        }
        public void BindNewAction(Action LAction,Action RAction)
        {
            LButtonPress = LAction;
            RButtonPress = RAction;
        }
        
        private void Awake()
        {
            _arduinoPort = GetComponent<ArduinoPort>();
            _arduinoPort.OpenPort();
            //for test
            LButtonPress += () => Debug.Log("L");
            RButtonPress += () => Debug.Log("R");
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