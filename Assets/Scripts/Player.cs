using System.Collections;
using UnityEngine;
public class Player : Ship
{
    
    Rockets rocket;
    FireArm fireArm;
    Laser laser;
    private Transform bar;
    private float rocketsFireTime = 0;
    private float fireArmFireTime = 0;
    private float laserFireTime = 0;
    public Transform shotPosition;
    public LineRenderer lineRenderer;

    private void Start()
    {

        bar = GameObject.Find("Bar").GetComponent<Transform>();
        this.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Ships")[Stats.shipType];
        this.GetComponent<BoxCollider2D>().size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;

        laser = new Laser();
        rocket = new Rockets();
        fireArm = new FireArm();

        switch (Stats.shipType)
        {
            case 0:
                speed = Stats.HeavyShipSpeed;
                hp = Stats.HeavyShipHP;

                break;
            case 1:
                speed = Stats.MediumShipSpeed;
                hp = Stats.MediumShipHP;

                break;
            case 2:
                speed = Stats.LightShipSpeed;
                hp = Stats.LightShipHP;

                break;
        }
        Stats.startHp = hp;
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

       
        
        switch (Stats.shotType)
        {
            case E_shotType.FireArm:
                if (Time.time > fireArmFireTime)
                {
                    fireArmFireTime = Time.time + fireArm.getFireRate();
                    fireArm.Shoot(Resources.Load<GameObject>("Prefabs/Bullet"), shotPosition);
                }
                break;
            case E_shotType.Rocket:
               
                if (Time.time > rocketsFireTime)
                {
                    rocketsFireTime = Time.time + rocket.getFireRate();
                    rocket.Shoot(Resources.Load<GameObject>("Prefabs/Rocket"), shotPosition);
                }
                break;
            case E_shotType.Laser:
                if (Time.time > laserFireTime)
                {
                    laserFireTime = Time.time + laser.getFireRate();
                    StartCoroutine(laser.Shoot(lineRenderer, shotPosition));
                }
                break;
            case E_shotType.All:
                if (Time.time > fireArmFireTime)
                {
                    fireArmFireTime = Time.time + fireArm.getFireRate();
                    fireArm.Shoot(Resources.Load<GameObject>("Prefabs/Bullet"), shotPosition);
                }
                if (Time.time > rocketsFireTime)
                {
                    rocketsFireTime = Time.time + rocket.getFireRate();
                    rocket.Shoot(Resources.Load<GameObject>("Prefabs/Rocket"), shotPosition);
                }
                if (Time.time > laserFireTime)
                {
                    laserFireTime = Time.time + laser.getFireRate();
                    StartCoroutine(laser.Shoot(lineRenderer, shotPosition));
                }
                break;

        }

        ///////////////HEALTH BAR//////////////
        if (hp > 0)
        {
            bar.localScale = new Vector3(hp / Stats.startHp, 1f);
        }
        else
        {
            bar.localScale = new Vector3(0f, 1f);
        }
        ///////////END OF HEALTH BAR//////////


    }
    public void playerGetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //Debug.Log("ETOT PAREN' BYL IZ TEH");
        }
       
    }
}
