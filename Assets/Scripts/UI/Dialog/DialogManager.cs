
using System;
using System.Collections.Generic;
using Class;
using Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private TMP_Text dialogUI, nameUI;
    private void Awake()
    {
        dialogUI = transform.Find("Dialog").GetComponentInChildren<TMP_Text>();
        nameUI = transform.Find("Name").GetComponentInChildren<TMP_Text>();
    }

    public void SetDialog(string delta) => dialogUI.text = delta;
    public void SetName(string delta) => nameUI.text = delta;
}


