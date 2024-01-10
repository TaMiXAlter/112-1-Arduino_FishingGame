
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class FeverManager : MonoBehaviour
{
    private GameObject rightArrow,leftArrow;
    private TMP_Text CountDown;

    private void Awake()
    {
        rightArrow = transform.Find("RightArrow").GameObject();
        leftArrow = transform.Find("LeftArrow").GameObject();

        CountDown = transform.Find("CountDown").GetComponent<TMP_Text>();
    }

    public void ShowRightArrow(float scale)
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(true);
        rightArrow.transform.localScale = new Vector3(scale, scale);
    }
    
    public void ShowLeftArrow(float scale)
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(true);
        leftArrow.transform.localScale = new Vector3(scale, scale);
    }

    public void SetCountDownNum(float Num)
    {
        CountDown.text = Num.ToString();
    }
}
