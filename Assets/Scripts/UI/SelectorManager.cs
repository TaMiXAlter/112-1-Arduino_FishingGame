using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectorManager : MonoBehaviour
    {
        private Image LeftSelectBG, RightSelectBG;
        private TMP_Text LeftText, RightText,CountDownNum;

        private void Awake()
        {
            LeftText = transform.Find("LeftText").GetComponent<TMP_Text>();
            RightText = transform.Find("RightText").GetComponent<TMP_Text>();
            CountDownNum = transform.Find("CountDown").Find("Num").GetComponent<TMP_Text>();

            LeftSelectBG = transform.Find("LeftBG").GetComponent<Image>();
            RightSelectBG = transform.Find("RightBG").GetComponent<Image>();
        }

        public void SetLeftText(string delta) => LeftText.text = delta;
        public void SetRightText(string delta) => RightText.text = delta;
        public void SetCountDownNum(int num) => CountDownNum.text = num.ToString();

        public void SetLeftBG(Sprite newBG) => LeftSelectBG.sprite = newBG;
        public void SetRightBG(Sprite newBG) => RightSelectBG.sprite = newBG;

    }
}