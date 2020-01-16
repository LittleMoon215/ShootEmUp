using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public virtual float hp { get; set; }
    protected enum E_shotType { Rocket, Laser, Bullet };
    public virtual float speed { get; set; }

}

public class FastShip : Ship
{
    public override float hp { get; set; } = 330f;
    public override float speed { get; set; } = 4f;
}

public class MediumShip : Ship
{
    public override float hp { get; set; } = 550f;
    public override float speed { get; set; } = 6f;
}

public class HeavyShip : Ship
{
    public override float hp { get; set; } = 1000f;
    public override float speed { get; set; } = 6f;
}
