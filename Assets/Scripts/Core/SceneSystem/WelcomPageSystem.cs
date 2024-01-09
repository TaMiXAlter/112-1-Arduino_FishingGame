
using System;
using Core;
using UnityEngine;

public class WelcomPageSystem : MonoBehaviour
{
    private bool LPressed, RPressed;
    private void Awake()
    {
        LPressed = false;
        RPressed = false;
        InputSystem.Instance.BindNewAction(LP,RP);
    }

    private void Update()
    {
        if(LPressed && RPressed) GameManager.Instance.SwitchSence(1,MainGameState.Su);
    }

    void LP() => LPressed = true;
    void RP() => RPressed = true;
}
