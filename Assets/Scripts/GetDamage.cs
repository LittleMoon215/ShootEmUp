using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public float hp=100f;
    public void getDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this);
        }
    }
}