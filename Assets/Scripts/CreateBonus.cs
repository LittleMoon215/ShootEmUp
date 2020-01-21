using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBonus : MonoBehaviour
{
    private float spawnTime = 10f;
    public GameObject[] bonuses = new GameObject[5];
    private GameObject instantiated;


    void FixedUpdate()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + Random.Range(7f, 14f);
            instantiated = Instantiate(bonuses[Random.Range(0, 5)],new Vector3(Random.Range(-10,10),10f,0f),Quaternion.identity);

        }
        if(instantiated)
        {
            instantiated.transform.position = new Vector3(instantiated.transform.position.x,instantiated.transform.position.y-0.1f,instantiated.transform.position.z);
            if(instantiated.transform.position.y<-150f)
            {
               Destroy(instantiated);
            }
        }
    }
}
