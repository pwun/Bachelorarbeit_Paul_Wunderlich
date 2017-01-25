﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class Achievement2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public Sprite lvl4;
    GameObject infoPanel;

    // Use this for initialization
    void Start()
    {
        infoPanel = GameObject.Find("achievement2Info");
        infoPanel.transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("achievement2Counter").GetComponent<Text>().text = Game.current.hero.achievementCounter[1] + " / " + Game.current.hero.achievementMax[Game.current.hero.achievementLevel[1]];
        switch (Game.current.hero.achievementLevel[1])
        {
            case 1:
                GameObject.Find("achievement2").GetComponent<Image>().sprite = lvl2;
                break;
            case 2:
                GameObject.Find("achievement2").GetComponent<Image>().sprite = lvl3;
                break;
            case 3:
                GameObject.Find("achievement2").GetComponent<Image>().sprite = lvl4;
                break;
            default:
                GameObject.Find("achievement2").GetComponent<Image>().sprite = lvl1;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoPanel.transform.localScale = new Vector3(1, 1, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPanel.transform.localScale = new Vector3(0, 0, 0);
    }
}
