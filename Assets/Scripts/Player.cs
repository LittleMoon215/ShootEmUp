using System.Collections;
using UnityEngine;
public class Player : Ship
{
    public static int shipType = 1;
    Rockets rocket;
    FireArm fireArm;
    Laser laser;
    private float rocketsFireTime = 0;
    private float fireArmFireTime = 0;
    private float laserFireTime = 0;
    public Transform shotPosition;
    public LineRenderer lineRenderer;
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Ships")[shipType];
        this.GetComponent<BoxCollider2D>().size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;
        switch(shipType)
        {
            case 0:
                fireArm = new FireArm();
                break;
            case 1:
                rocket = new Rockets();
                speed = 6f;
                hp = 550f;
                break;
            case 2:
                speed = 6f;
                hp = 300f;
                laser = new Laser();
                break;
        }  
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
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

        switch(shipType)
        {
            case 0:
                if (Time.time > fireArmFireTime)
                {
                    fireArmFireTime = Time.time + fireArm.getFireRate();
                    fireArm.Shoot(Resources.Load<GameObject>("Prefabs/Bullet"), shotPosition);
                }
                break;
            case 1:
               
                if (Time.time > rocketsFireTime)
                {
                    rocketsFireTime = Time.time + rocket.getFireRate();
                    rocket.Shoot(Resources.Load<GameObject>("Prefabs/Rocket"), shotPosition);
                }
                break;
            case 2:
                if (Time.time > laserFireTime)
                {
                    laserFireTime = Time.time + laser.getFireRate();
                    StartCoroutine(laser.Shoot(lineRenderer, shotPosition));
                }
                break;

        }

        
        
        
    }
    public void playerGetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("ETOT PAREN' BYL IZ TEH");
        }
    }
}
