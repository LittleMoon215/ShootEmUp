using UnityEngine;

public class Player : Ship
{
    public static int shipType = 1;
    Rockets rocket;
    FireArm fireArm;

    private float rocketsFireTime = 0;
    private float fireArmFireTime = 0;
    public Transform shotPosition;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Ships")[shipType];
        this.GetComponent<BoxCollider2D>().size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;
        switch(shipType)
        {
            case 0:
                startType = E_shotType.Laser;
                break;
            case 1:
                startType = E_shotType.Bullet;
                break;
            case 2:
                startType = E_shotType.Rocket;
                break;
        }
        rocket = new Rockets();
        fireArm = new FireArm();
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

        if (Time.time > fireArmFireTime)
        {
            fireArmFireTime = Time.time + fireArm.getFireRate();
            fireArm.Shoot(Resources.Load<GameObject>("Prefabs/Bullet"), shotPosition);
        }
        if (Time.time > rocketsFireTime)
        {
            rocketsFireTime = Time.time + rocket.getFireRate();
            fireArm.Shoot(Resources.Load<GameObject>("Prefabs/Rocket"), shotPosition);
        }

    }
    public void playerGetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("TEBE PIZDA");
        }
    }
}
