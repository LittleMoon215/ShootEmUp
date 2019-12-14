using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Guns
{
    public float hp = 100f;
    protected enum E_shotType { Rocket, Laser, Bullet };
    public float speed = 10f;

}
