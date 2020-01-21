using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class CreateEnemies : MonoBehaviour
{
    int number = 5;
    public GameObject enemyPrefab;
    public Transform enemySpawner;
    public GameObject crookEnemyPrefab;
    public GameObject catEnemyPrefab;
    public GameObject bossEnemyPrefab;
    private EnemyCreator standartEnemyCreator;
    private CatEnemyCreator catEnemyCreator;
    private CrookEnemyCreator crookEnemyCreator;
    public List<Enemy> enemy;
    float range = 1f;
    Vector3 pos;

   
    void Awake()
    {
        number = Stats.Level * 3;
        pos = enemySpawner.position;
        standartEnemyCreator = new StandartEnemyCreator();
        catEnemyCreator = new CatEnemyCreator();
        crookEnemyCreator = new CrookEnemyCreator();
        for (int i = 0; i < number; ++i)
        {
            if (i % 3 == 0)
                enemy.Add(crookEnemyCreator.EnemyCreate());
            else if (i % 2 == 0)
                    enemy.Add(catEnemyCreator.EnemyCreate());
            else if (i % 1 == 0)
                enemy.Add(standartEnemyCreator.EnemyCreate());
        }
        
        if (Stats.Level % 2 != 0)
        {
            foreach (var en in enemy)
            {

                switch (en.type)
                {

                    case Enemy.ENEMY_TYPE.CAT_ENEMY:
                        en.enemySpawn(catEnemyPrefab, pos, catEnemyPrefab.transform.rotation);
                        break;
                    case Enemy.ENEMY_TYPE.STANDART_ENEMY:
                        en.enemySpawn(enemyPrefab, pos, enemyPrefab.transform.rotation);
                        break;
                    case Enemy.ENEMY_TYPE.CROOK_ENEMY:
                        en.enemySpawn(crookEnemyPrefab, pos, crookEnemyPrefab.transform.rotation);
                        break;
                }



                pos = new Vector3(pos.x + range, pos.y);

            }
        }
        else
        {
            new BossEnemy().enemySpawn(bossEnemyPrefab, new Vector3(0, 5.6f), bossEnemyPrefab.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            GameObject.Find("ExitTrigger").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("ExitTrigger").GetComponent<SpriteRenderer>().enabled = true;
        }

       
       
        
    }

}
