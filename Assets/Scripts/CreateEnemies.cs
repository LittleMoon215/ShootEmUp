using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateEnemies : MonoBehaviour
{
    const int number = 2;
    public GameObject enemyPrefab;
    public Transform enemySpawner;
    public GameObject catEnemyPrefab;
    public GameObject bossEnemyPrefab;
    private EnemyCreator standartEnemyCreator;
    private CatEnemyCreator catEnemyCreator;
    public List<Enemy> enemy = new List<Enemy>(number);
    int count = 0;
    float range = 1f;
    Vector3 pos;
    void Start()
    {
        pos = enemySpawner.position;
        standartEnemyCreator = new StandartEnemyCreator();
        catEnemyCreator = new CatEnemyCreator();
        for (int i = 0; i < 1; ++i)
        {
            if (i % 2 == 0)
                enemy.Add(standartEnemyCreator.EnemyCreate());
            else
                enemy.Add(catEnemyCreator.EnemyCreate());
        }
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
            }

                 
            
            pos = new Vector3(pos.x + range, pos.y);

        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && count == 0)
        {
            enemy[0].enemySpawn(bossEnemyPrefab, new Vector3(0, 5.6f), bossEnemyPrefab.transform.rotation);

            ++count;
        }
    }

}
