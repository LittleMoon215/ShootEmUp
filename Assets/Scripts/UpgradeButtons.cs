using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Button ALL;
    public Button HP1;
    public Button HP2;
    public Button DAMAGE1;
    public Button DAMAGE2;
    public Button SPEED1;
    public Button SPEED2;
    public Button GOD;
    ColorBlock colors;
    public void AllStatsPressed()
    {
        ALL.interactable = false;
        SPEED1.interactable = true;
        DAMAGE1.interactable = true;
        HP1.interactable = true;

        colors = ALL.colors;
    }
    public void HP1Pressed()
    {
        HP1.interactable = false;
        HP1.colors = colors;
        HP2.interactable = true;
        Ship.hp = hp * 1.2;
    }
    public void HP2Pressed()
    {
        HP2.interactable = false;
        HP2.colors = colors;
        if (GOD.colors != colors)
            GOD.interactable = true;
    }
    public void DAMAGE1Pressed()
    {
        DAMAGE1.interactable = false;
        DAMAGE1.colors = colors;
        DAMAGE2.interactable = true;
    }
    public void DAMAGE2Pressed()
    {
        DAMAGE2.interactable = false;
        DAMAGE2.colors = colors;
        if (GOD.colors != colors)
            GOD.interactable = true;
    }
    public void SPEED1Pressed()
    {
        SPEED1.interactable = false;
        SPEED1.colors = colors;
        SPEED2.interactable = true;
    }
    public void SPEED2Pressed()
    {
        SPEED2.interactable = false;
        SPEED2.colors = colors;
        if (GOD.colors != colors)
            GOD.interactable = true;
    }
    public void GODPressed()
    {
        GOD.interactable = false;
        GOD.colors = colors;
    }
}
