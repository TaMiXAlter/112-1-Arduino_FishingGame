using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;

    namespace Tool
    {
    public class ArduinoPort :MonoBehaviour
    {

        public string Inputdata;
        
        string portName_1 = "COM4";
        int setBaudRate = 9600;
        Parity parity = Parity.None;
        int dataBits = 8;
        StopBits stopBits = StopBits.One;
        SerialPort serialPort ;


        private void Update()
        {
            ReadData();
        }

        public void OpenPort() 
        {
            serialPort = new SerialPort(portName_1, setBaudRate, parity, dataBits, stopBits);
            // check whether port is open 
            try{
                serialPort.Open();
            }catch(Exception e)
            {
                Debug.Log(e.Message);
                StartCoroutine(OpenPortAgain(3));
            }

            
        }

        public void ClosePort() 
        {
            try{
                serialPort.Close();
            }catch(Exception ex) 
            {
                Debug.Log(ex.Message);
            }
        }

        public void ReadData()
        {
            if (!serialPort.IsOpen) return ;
            Inputdata = serialPort.ReadLine();
         
        }


        
        private IEnumerator OpenPortAgain(float dletaTime)
        {
            yield return new WaitForSeconds(dletaTime);
            OpenPort();
        }
    }
}
