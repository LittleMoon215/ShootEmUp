using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Guns
{
    public int hp = 100;
    protected enum E_shotType { Rocket, Laser, Bullet };
    public float speed = 10f;

}
