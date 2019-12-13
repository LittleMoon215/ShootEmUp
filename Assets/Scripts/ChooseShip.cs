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
        int.TryParse(a, out Player.shipType);
        
    }

}
