using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseShip : MonoBehaviour
{
    public GameObject button;
    public void OnShipPressed()
    {
        string a = button.GetComponent<Image>().sprite.name;
        int index = a.IndexOf("_");
        a = a.Substring(index + 1);
        int.TryParse(a, out Stats.shipType);
        switch (Stats.shipType)
        {
            case 0:
                Stats.shotType = Ship.E_shotType.FireArm;
                break;
            case 1:
                Stats.shotType = Ship.E_shotType.Rocket;
                break;
            case 2:
                Stats.shotType = Ship.E_shotType.Laser;
                break;
        }
    }

}
