using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHellBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(WeaponHellBonusActive());
        }
    }
    private IEnumerator WeaponHellBonusActive()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Ship.E_shotType tempShotType = Stats.shotType;
        Stats.shotType = Ship.E_shotType.All;
        Debug.Log("WeaponHellActive");
        yield return new WaitForSecondsRealtime(5f);
        Stats.shotType = tempShotType;
        Debug.Log("WeaponHellDisabled");
        Destroy(this.gameObject);
    }
}
