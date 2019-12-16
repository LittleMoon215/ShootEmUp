using System;
using UnityEngine;

public class RocketMover : MonoBehaviour
{
    //public GameObject scriptObject;
    private Rigidbody2D rb;
    Rockets rocket;

    public GameObject rocketExplosion;
    private GameObject[] enemyObj;
    private GameObject playerObj;
    private float maxDist = float.MaxValue;
    private Vector2 enemyPos;
    private void Start()
    {
        rocket = new Rockets();
        //scriptObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        try
        {
            enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
        }
        catch (NullReferenceException)
        {
            rb.velocity = transform.up * rocket.getSpeed();
            
        }


        foreach (GameObject enemy in enemyObj)
        {
            float dist = Vector2.Distance(playerObj.transform.position, enemy.transform.position);
            if (maxDist > dist)
            {
                maxDist = dist;
                enemyPos = enemy.transform.position;
            }
        }
        
    }
    private void FixedUpdate()
    {
            Vector2 dir = (enemyPos - rb.position).normalized;
            float rotateAmount = Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -rotateAmount * rocket.getRotateSpeed();
            rb.velocity = transform.up * rocket.getSpeed();


        if (maxDist == float.MaxValue)
        {
            rb.angularVelocity = 0;
            rb.velocity = transform.up * rocket.getSpeed();
        }
    }
    private void OnTriggerEnter2D(Collider2D hitted)
    {
        if (hitted.tag == "Enemy")
        {
            GameObject exp = Instantiate(rocketExplosion, this.transform.position, this.transform.rotation);
            hitted.gameObject.GetComponent<EnemyObj>().thisEnemy.getDamage(rocket.getDamage(), hitted.gameObject);
            Destroy(exp, 1);
            Destroy(this.gameObject);
        }

    }

}
