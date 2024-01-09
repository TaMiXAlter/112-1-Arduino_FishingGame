using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectorManager : MonoBehaviour
    {
        private Image LeftSelectBG, RightSelectBG;
        private TMP_Text LeftText, RightText;

        private void Awake()
        {
            LeftText = transform.Find("LeftBG").GetComponentInChildren<TMP_Text>();
            RightText = transform.Find("RightBG").GetComponentInChildren<TMP_Text>();

            LeftSelectBG = transform.Find("LeftBG").GetComponent<Image>();
            RightSelectBG = transform.Find("RightBG").GetComponent<Image>();
        }

        public void SetLeftText(string delta) => LeftText.text = delta;
        public void SetRightText(string delta) => RightText.text = delta;

        public void SetLeftBG(Sprite newBG) => LeftSelectBG.sprite = newBG;
        public void SetRightBG(Sprite newBG) => RightSelectBG.sprite = newBG;

    }
}