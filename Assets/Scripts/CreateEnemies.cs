using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyTransform;

    public EnemyCreator[] enemies;

    public Enemy[] enemy;
    void Start()
    {
        for (int i=0; i<10; ++i)
        {
            enemies[i] = new StandartEnemyCreator();
            enemy[i] = enemies[i].EnemyCreate();
            enemy[i].transform.position = new Vector3(enemy[i].transform.position.x + 30 * i,enemy[i].transform.position.y, enemy[i].transform.position.z);
            enemy[i].enemyCreateShot(enemyPrefab, enemyTransform);
        }
      
    }

}
