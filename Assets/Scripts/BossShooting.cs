using UnityEngine;

public class BossShooting : MonoBehaviour
{
    float speed;
    public float damage = 80f;
   

    public GameObject explosionPrefab;

    private void Awake()
    {
        speed = Random.Range(3, 10);
    }

    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().playerGetDamage(damage);
            Destroy(this.gameObject);
            GameObject exp = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(exp, 1);
        }
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
            GameObject exp = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(exp, 1);
        }
    }
}
