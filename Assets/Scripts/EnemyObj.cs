using System.Collections.Generic;
using UnityEngine;
public class EnemyObj : MonoBehaviour
{
    private float fireTime = 0;
    public float fireRate = 2.5f;
    public float hp = 100f;

    public GameObject enemyShotPrefab;
    public Transform enemyShotPosition;

    private void Start()
    {
        fireTime = Random.Range(0, 3);
       
        
    }
    public void getDamage(float damage, GameObject go)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(go);
        }
    }
    private void FixedUpdate()
    {
        if (Time.time > fireTime)
        {
            fireTime = Time.time + fireRate + Random.Range(10, 20) / 9.99f;
            switch (this.gameObject.name)
            {
                case "Enemy(Clone)":
                    var z = new CatEnemy();
                    z.enemyShoot(enemyShotPrefab, enemyShotPosition.position, enemyShotPosition.rotation);
                    break;
                case "EnemyCat(Clone)":
                    var x = new StandartEnemy();
                    x.enemyShoot(enemyShotPrefab, enemyShotPosition.position, enemyShotPosition.rotation);
                    break;
                case "EnemyCatBoss(Clone)":
                    var c = new BossEnemy();
                    c.enemyShoot(Resources.Load<GameObject>("Prefabs/BossShot"), enemyShotPosition.position, enemyShotPosition.rotation);
                    break;
            }
        }

    }
}