using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(SpeedBonusActive());
        }
    }
    private IEnumerator SpeedBonusActive()
    {
        
        Player.speed += 0.5f;
        Debug.Log("SpeedIncreased");
        yield return new WaitForSecondsRealtime(10f);
        Player.speed -= 0.5f;
        Debug.Log("SpeedDecreased");
        Destroy(this.gameObject);
    }
}
