using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableObject
{
    //HeavyShip
    public static float HeavyShipHP = 1000f;
    public static float HeavyShipSpeed = 4.5f;


    //MediumShip
    public static float MediumShipHP = 550f;
    public static float MediumShipSpeed = 5f;


    //LightShip
    public static float LightShipHP = 330f;
    public static float LightShipSpeed = 6f;


    //Guns
    public static float RocketDamage = 100f;
    public static float FireArmDamage = 50f;
    public static float LaserDamage = 300f;

    //Player
    public static int XP = 0;
    public static Ship.E_shotType shotType;
    public static int shipType = 0;
    public static float startHp;

    //Buttons
    public static bool AllStats = false;
    public static bool HP1 = false;
    public static bool HP2 = false;
    public static bool Damage1 = false;
    public static bool Damage2 = false;
    public static bool Speed1 = false;
    public static bool Speed2 = false;
    public static bool WeaponHell = false;

    //LevelState
    public static int Level = 1;
}
