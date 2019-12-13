using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    private Vector3 tmp;


    private void FixedUpdate()
    {
        tmp = transform.position;
        tmp.y -= 0.001f;
        transform.position = tmp;

        if (transform.position.y < -16f)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x,13.69f), transform.rotation);
        }
    }
}
