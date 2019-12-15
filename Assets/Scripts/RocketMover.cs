using System;
using UnityEngine;

public class RocketMover : MonoBehaviour
{
    //public GameObject scriptObject;
    private Rigidbody2D rb;

    public float speed = 6f;
    public float rotateSpeed = 300f;
    public GameObject rocketExplosion;
    private GameObject[] enemyObj;
    private GameObject playerObj;
    private float maxDist = float.MaxValue;
    private Vector2 enemyPos;
    private void Start()
    {
        //scriptObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        try
        {
            enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
        }
        catch (NullReferenceException)
        {
            rb.velocity = transform.up * speed;
            
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
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;


        if (maxDist == float.MaxValue)
        {
            rb.angularVelocity = 0;
            rb.velocity = transform.up * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitted)
    {
        if (hitted.tag == "Enemy")
        {
            GameObject exp = Instantiate(rocketExplosion, hitted.transform.position, hitted.transform.rotation);
            hitted.gameObject.GetComponent<EnemyObj>().getDamage(new Rockets().damage, hitted.gameObject);
            Destroy(exp, 1);
            Destroy(this.gameObject);
        }

    }

}
