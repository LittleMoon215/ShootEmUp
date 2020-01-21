using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DamageBonusFunc());
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public IEnumerator DamageBonusFunc()
    {
        
        Stats.LaserDamage += 100f;
        Stats.RocketDamage += 50f;
        Stats.FireArmDamage += 30f;
        Debug.Log("DamageIncreased");
        yield return new WaitForSecondsRealtime(7f);
        Stats.LaserDamage -= 100f;
        Stats.RocketDamage -= 50f;
        Stats.FireArmDamage -= 30f;
        Debug.Log("DamageDecreased");
        Destroy(this.gameObject);
    }
}
