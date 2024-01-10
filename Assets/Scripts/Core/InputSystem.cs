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

        public void ClearAcction()
        {
            LButtonPress = null;
            RButtonPress = null;
        }

        public void ClosePort()
        {
            _arduinoPort.ClosePort();
        }

        public void OpenPort()
        {
            _arduinoPort.OpenPort();
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
            if(Input.GetKeyDown(KeyCode.D))RButtonPress?.Invoke();
            if(Input.GetKeyDown(KeyCode.A))LButtonPress?.Invoke();


            if(_arduinoPort.Inputdata == "R")RButtonPress?.Invoke();
            if(_arduinoPort.Inputdata == "L")LButtonPress?.Invoke();
            
            //TODO:解決LB觸發頻率較慢問題
        }
    }


}