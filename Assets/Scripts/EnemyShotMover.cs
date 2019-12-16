using System;
using UnityEngine;
public class EnemyShotMover : MonoBehaviour
{
    float speed = 9f;
    public float damage = 10f;
    Vector3 player;
    Rigidbody2D rb;
    
    public GameObject explosionPrefab;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 newDirection = (player - transform.position);
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }



    void FixedUpdate()
    {         
        rb.velocity = transform.up * -1 * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().playerGetDamage(damage);
            Destroy(this.gameObject);
            GameObject exp = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(exp, 1);
        }
    }
}



////SHIELD
///Vector2 newDirection = player - transform.position;
//float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
//Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.fixedDeltaTime);
//GetComponent<Rigidbody2D>().velocity = transform.up* -1 * speed;