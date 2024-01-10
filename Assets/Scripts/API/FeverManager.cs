
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Random = UnityEngine.Random;

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

    private void Start()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    public void ShowRightArrow(float scale)
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(true);
        rightArrow.transform.localScale = new Vector3(scale, scale);
        rightArrow.transform.localPosition = new Vector3(Random.Range(-707, 707), Random.Range(-50, 289));
    }
    
    public void ShowLeftArrow(float scale)
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(true);
        leftArrow.transform.localScale = new Vector3(scale, scale);
        leftArrow.transform.localPosition = new Vector3(Random.Range(-707, 707), Random.Range(-50, 289));
    }

    public void SetCountDownNum(float Num) =>CountDown.text = Num.ToString();
}
