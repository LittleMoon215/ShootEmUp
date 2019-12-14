using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    public static int shipType = 2;

    
    public float fireRate;
    private float fireTime=0;
    public Transform shotPosition;
    public GameObject shotPrefab;
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Ships")[shipType];
        this.GetComponent<BoxCollider2D>().size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) )
        {
            transform.Translate(Vector2.left * Time.fixedDeltaTime * speed);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.fixedDeltaTime * speed);
        }
        if (Time.time > fireTime)
        {
            fireTime = Time.time + fireRate;
            Rockets rocket = new Rockets();
            rocket.Shoot(shotPrefab,shotPosition);
            
            
        }
        
        
    }
    public void playerGetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
        {
            Debug.Log("TEBE PIZDA");
        }
    }
}
