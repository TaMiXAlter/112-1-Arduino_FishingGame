
using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

public class WelcomPageSystem : MonoBehaviour
{
    private bool LPressed, RPressed;
    private Image leftArrow, rightArrow;
    public Sprite yes;
    private void Awake()
    {
        leftArrow = GameObject.Find("Canvas-Views").transform.Find("LeftArrow").GetComponent<Image>();
        rightArrow = GameObject.Find("Canvas-Views").transform.Find("RightArrow").GetComponent<Image>();
        LPressed = false;
        RPressed = false;
        InputSystem.Instance.BindNewAction(LP,RP);
    }

    private void Update()
    {
        if(LPressed && RPressed) GameManager.Instance.SwitchSence(1,MainGameState.Su);
        if (LPressed) leftArrow.sprite = yes;
        if (RPressed) rightArrow.sprite = yes;
    }

    void LP() => LPressed = true;
    void RP() => RPressed = true;
}
