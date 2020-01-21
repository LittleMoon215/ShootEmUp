using UnityEngine;

public class HealBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (Player.hp + 100 < Player.hp)
            {
                Player.hp += 100f;
            }
            else
            {
                Player.hp = Stats.startHp;
            }
            Destroy(this.gameObject);
        }
    }
}
