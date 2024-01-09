
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    private Image BG, Actor,FavorabilityFill;
    private TMP_Text favorabilityNum;
    private void Awake()
    {
        favorabilityNum = transform.Find("Favorability").Find("Num").GetComponent<TMP_Text>();
        FavorabilityFill = transform.Find("Favorability").Find("Fill").GetComponent<Image>();

        BG = transform.Find("BackGround").GetComponent<Image>();
        Actor = transform.Find("Actor").GetComponent<Image>();
        
    }

    public void SetBackGround(Sprite newBG) => BG.sprite = newBG;
    public void SetActor(Sprite newActor) => Actor.sprite = newActor;
    public void SetFavorabilityNum(int newNum)
    {
        favorabilityNum.text = newNum.ToString();
        FavorabilityFill.transform.localPosition = new Vector3(0, Mathf.Lerp(-170, 0, newNum / 100), 0);
    }

    public void SetSelectorUIActive(bool active) => transform.Find("SelecterUI").GameObject().SetActive(active);
}
