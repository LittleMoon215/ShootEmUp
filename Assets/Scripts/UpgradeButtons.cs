using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Button WEAPONHELL;
    ColorBlock colors;

  
    public void Update()
    {
        Text text = GameObject.Find("XPNUM").GetComponent<Text>();
        text.text = Stats.XP.ToString();
        colors = ALL.colors;
        if (Stats.AllStats)
        {
            ALL.interactable = false;
            if (Stats.XP >= 60 && !Stats.HP1)
            {
                HP1.interactable = true;
            }
            else
            {
                HP1.interactable = false;
            }
            if (Stats.XP >= 70 && !Stats.Damage1)
            {
                DAMAGE1.interactable = true;
            }
            else
            {
                DAMAGE1.interactable = false;
            }
            if (Stats.XP >= 55 && !Stats.Speed1)
            {
                SPEED1.interactable = true;
            }
            else
            {
                SPEED1.interactable = false;
            }
        }
        if (Stats.HP1)
        {
            HP1.colors = colors;
            HP1.interactable = false;
            if (Stats.XP >= 100 && !Stats.HP2)
            {
                HP2.interactable = true;
            }
            else
            {
                HP2.interactable = false;
            }

        }
        if (Stats.HP2)
        {
            HP2.colors = colors;
            HP2.interactable = false;
            if (Stats.XP >= 550 && !Stats.WeaponHell)
            {
                WEAPONHELL.interactable = true;
            }
            
        }
        if (Stats.Damage1)
        {
            DAMAGE1.colors = colors;
            DAMAGE1.interactable = false;
            if (Stats.XP >= 120 && !Stats.Damage2)
            {
                DAMAGE2.interactable = true;
            }
            else
            {
                DAMAGE2.interactable = false;
            }
        }
        if (Stats.Damage2)
        {
            DAMAGE2.colors = colors;
            DAMAGE2.interactable = false;
            if (Stats.XP >= 550 && !Stats.WeaponHell)
            {
                WEAPONHELL.interactable = true;
            }
        }
        if (Stats.Speed1)
        {
            SPEED1.colors = colors;
            SPEED1.interactable = false;
            if (Stats.XP >= 95 && !Stats.Speed2)
            {
                SPEED2.interactable = true;
            }
            else
            {
                SPEED2.interactable = false;
            }
        }
        if (Stats.Speed2)
        {
            SPEED2.colors = colors;
            SPEED2.interactable = false;
            if (Stats.XP >= 550 && !Stats.WeaponHell)
            {
                WEAPONHELL.interactable = true;
            }
        }
        if (Stats.WeaponHell)
        {
            WEAPONHELL.colors = colors;
            WEAPONHELL.interactable = false;
        }
    }
    public void allStatsChanged()
    {
        switch (Stats.shipType)
        {
            case 0:
                Stats.HeavyShipHP *= 1.1f;
                Stats.FireArmDamage *= 1.1f;
                Stats.HeavyShipSpeed *= 1.05f;
                break;
            case 1:
                Stats.MediumShipHP *= 1.15f;
                Stats.RocketDamage *= 1.2f;
                Stats.MediumShipSpeed *= 1.03f;
                break;
            case 2:
                Stats.LightShipHP *= 1.05f;
                Stats.LaserDamage *= 1.25f;
                Stats.LightShipSpeed *= 1.01f;
                break;
        }


    }
    public void hpChanged()
    {
        switch (Stats.shipType)
        {
            case 0:
                Stats.HeavyShipHP *= 1.2f;
                break;
            case 1:
                Stats.MediumShipHP *= 1.2f;
                break;
            case 2:
                Stats.LightShipHP *= 1.2f;
                break;
        }
        
    }
    public void damageChanged()
    {
        switch (Stats.shipType)
        {
            case 0:
                Stats.FireArmDamage *= 1.2f;
                break;
            case 1:
                Stats.MediumShipHP *= 1.25f;
                break;
            case 2:
                Stats.LightShipHP *= 1.15f;
                break;
        }
    }
    public void speedChanged()
    {
        switch (Stats.shipType)
        {
            case 0:
                Stats.HeavyShipSpeed *= 1.15f;
                break;
            case 1:
                Stats.MediumShipSpeed *= 1.2f;
                break;
            case 2:
                Stats.LightShipSpeed *= 1.1f;
                break;
        }
    }
    public void weaponHell()
    {
        Stats.shotType = Ship.E_shotType.All;
        
    }

    public void AllStatsPressed()
    {
        ALL.interactable = false;
        colors = ALL.colors;
        Stats.XP -= 40;
        allStatsChanged();
        Stats.AllStats = true;

    }
    public void HP1Pressed()
    {
        HP1.interactable = false;
        HP1.colors = colors;
        Stats.XP -= 60;
        hpChanged();
        Stats.HP1 = true;


    }
    public void HP2Pressed()
    {
        HP2.interactable = false;
        HP2.colors = colors;
        
        Stats.XP -= 100;
        hpChanged();
        Stats.HP2 = true;
    }
    public void DAMAGE1Pressed()
    {
        DAMAGE1.interactable = false;
        DAMAGE1.colors = colors;

        Stats.XP -= 70;
        damageChanged();
        Stats.Damage1 = true;
    }
    public void DAMAGE2Pressed()
    {
        DAMAGE2.interactable = false;
        DAMAGE2.colors = colors;
        Stats.XP -= 120;
        damageChanged();
        Stats.Damage2 = true;
    }
    public void SPEED1Pressed()
    {
        SPEED1.interactable = false;
        SPEED1.colors = colors;

        Stats.XP -= 55;
        speedChanged();
        Stats.Speed1 = true;
    }
    public void SPEED2Pressed()
    {
        SPEED2.interactable = false;
        SPEED2.colors = colors;

        Stats.XP -= 95;
        speedChanged();
        Stats.Speed2 = true;
    }
    public void GODPressed()
    {
        WEAPONHELL.interactable = false;
        WEAPONHELL.colors = colors;
        Stats.XP -= 550;
        weaponHell();
        Stats.WeaponHell = true;
    }
    public void OnExitPressed() => SceneManager.LoadScene("Game");

}
