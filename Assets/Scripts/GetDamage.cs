using UnityEngine;
using System.Collections.Generic;
public class GetDamage : MonoBehaviour
{
    private float fireTime = 0;
    private float fireRate = 1.8f;
    public float hp = 100f;
    Enemy a;
    public GameObject enemyShotPrefab;
    public Transform enemyShotPosition;
    private void Start()
    {
        fireTime = Random.Range(0, 5);
        a = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CreateEnemies>().enemy[0];
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
            fireTime = Time.time + fireRate + Random.Range(0,4);
            a.enemyShoot(enemyShotPrefab,enemyShotPosition.position,enemyShotPosition.rotation);

        }

    }
}