using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    FireArm fireArm;
    public GameObject explosionPrefab;

    private void Awake()
    {
        fireArm = new FireArm();
        
    }

    void FixedUpdate()
    {
        transform.position += transform.up * fireArm.getSpeed() * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyObj>().thisEnemy.getDamage(fireArm.getDamage(),collision.gameObject);
            Destroy(this.gameObject);
            GameObject exp = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(exp, 1);
        }
        
    }
}
