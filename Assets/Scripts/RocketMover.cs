using System;
using UnityEngine;

public class RocketMover : MonoBehaviour
{
    //public GameObject scriptObject;
    private Rigidbody2D rb;
    
    public float speed = 6f;
    public float rotateSpeed = 300f;
    public GameObject rocketExplosion;
    private GameObject enemyObj;
    private void Start()
    {
        //scriptObject = GameObject.FindGameObjectWithTag("MainCamera");
        
        rb = GetComponent<Rigidbody2D>();
        try
        {
            enemyObj = GameObject.FindGameObjectWithTag("Enemy");
        }
        catch (NullReferenceException ex)
        {
            rb.velocity = transform.up * speed;
        }




    }
    private void FixedUpdate()
    {
        if (enemyObj != null)
        {
            Vector2 dir = ((Vector2)enemyObj.transform.position - rb.position).normalized;
            float rotateAmount = Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitted)
    {
        if (hitted.tag == "Enemy")
        {

            
            GameObject exp = Instantiate(rocketExplosion,hitted.transform.position,hitted.transform.rotation);
            hitted.gameObject.GetComponent<GetDamage>().getDamage(Guns.Rockets.damage);
            Destroy(exp, 1);
            Destroy(this.gameObject);
            
            
        }
        
    }

}
