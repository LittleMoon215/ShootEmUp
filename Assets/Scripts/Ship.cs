using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float hp = 100f;
    public enum E_shotType { Rocket, Laser, Bullet };
    public float speed = 10f;
    public E_shotType startType;
}
