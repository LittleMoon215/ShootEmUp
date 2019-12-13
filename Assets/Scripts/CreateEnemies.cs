using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyTransform;

    public EnemyCreator enemies;

    public List<Enemy> enemy = new List<Enemy>(10);
    float range = 1f;
    Vector3 pos;
    void Start()
    {
        pos = enemyTransform.position;
        enemies = new StandartEnemyCreator();
        for (int i=0; i < enemy.Capacity; ++i)
        {
            enemy.Add(enemies.EnemyCreate());   
            
        }
      foreach(var en in enemy)
        {
            en.enemyCreateShot(enemyPrefab, pos, enemyPrefab.transform.rotation);
            pos = new Vector3(pos.x+range,pos.y);
            
        }
    }

}
