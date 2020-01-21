using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Couratine Started");
            StartCoroutine(ActivateShield());
            Debug.Log("Couratine end");
        }
    }

    private IEnumerator ActivateShield()
    {
        GameObject.Find("Shield").GetComponent<CircleCollider2D>().enabled = true;
        GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Shield ON");
        yield return new WaitForSecondsRealtime(7f);
        GameObject.Find("Shield").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Shield OFF");
        Destroy(this.gameObject);
    }

}
