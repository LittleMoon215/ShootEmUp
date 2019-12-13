using UnityEngine;

public class Guns : MonoBehaviour
{
    public class Rockets : Guns
    {

        public static float damage = 100f;
        public Rockets(GameObject shotPrefab, Transform shotPosition)
        {
           
            Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);
            
        }
        
    }
    public class FireArm : Guns
    {

    }
    public class Laser : Guns
    {

    }
}