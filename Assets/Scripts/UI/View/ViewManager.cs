
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    private Image BG, Actor;
    private TMP_Text favorabilityNum;
    private void Awake()
    {
        favorabilityNum = transform.Find("Favorability").Find("Num").GetComponent<TMP_Text>();

        BG = transform.Find("BackGround").GetComponent<Image>();
        Actor = transform.Find("Actor").GetComponent<Image>();
    }

    public void SetBackGround(Sprite newBG) => BG.sprite = newBG;
    public void SetActor(Sprite newActor) => Actor.sprite = newActor;
    public void SetFavorabilityNum(int newNum) => favorabilityNum.text = newNum.ToString();
}
