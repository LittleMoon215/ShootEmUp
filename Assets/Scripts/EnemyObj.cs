using System.Collections.Generic;
using UnityEngine;
public class EnemyObj : MonoBehaviour
{
    private float fireTime = 0;
    public float fireRate = 2.5f;
    private float hp = 0;
    public Enemy thisEnemy;
    public GameObject enemyShotPrefab;
    public Transform enemyShotPosition;

    private void Start()
    {
        fireTime = Random.Range(0, 3);

        switch (this.gameObject.name)
        {
            case "Enemy(Clone)":
                thisEnemy = new StandartEnemy();
                
                break;
            case "EnemyCat(Clone)":
                thisEnemy = new CatEnemy();
                
                break;
            case "EnemyCatBoss(Clone)":
                thisEnemy = new BossEnemy();
                
                break;
        }
    }
    
    private void FixedUpdate()
    {
        if (Time.time > fireTime)
        {
            fireTime = Time.time + fireRate + Random.Range(10, 20) / 9.99f;
            if (thisEnemy.type == Enemy.ENEMY_TYPE.BOSS_ENEMY)
            {
                thisEnemy.enemyShoot(Resources.Load<GameObject>("Prefabs/BossShot"), enemyShotPosition.position, enemyShotPosition.rotation);
            }
            else
            {
                thisEnemy.enemyShoot(enemyShotPrefab, enemyShotPosition.position, enemyShotPosition.rotation);
            }          
        }

    }
}