using System.Collections;
using UnityEngine;
public abstract class Guns : MonoBehaviour
{
    protected virtual float fireRate { get; set; }
    protected virtual float speed { get; set; }
    protected virtual float damage { get; set; }
    public float getFireRate() { return fireRate; }
    public float getDamage() { return damage; }
    public float getSpeed() { return speed; }
    public abstract void Shoot(GameObject shotPrefab, Transform shotPosition);



}
public class Rockets : Guns
{
    protected override float fireRate { get; set; } = 1.5f;
    protected override float speed { get; set; } = 6f;

    protected float rotateSpeed { get; set; } = 300f;
    public float getRotateSpeed() { return rotateSpeed; }
    protected override float damage { get; set; } = Stats.RocketDamage;
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {

        Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);

    }
}
public class FireArm : Guns
{
    protected override float fireRate { get; set; } = 0.5f;
    protected override float speed { get; set; } = 15f;
    protected override float damage { get; set; } = Stats.FireArmDamage;
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {

        Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);

    }
}
public class Laser : Guns
{

    protected override float fireRate { get; set; } = 5f;
    protected override float damage { get; set; } = Stats.LaserDamage;
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {
        ;
    }
    public IEnumerator Shoot(LineRenderer lineRenderer, Transform shotPosition)
    {
        RaycastHit2D hitInfo;
        hitInfo = Physics2D.Raycast(shotPosition.position, shotPosition.up);
        do
        {

            if (hitInfo.transform.tag == "EnemyShot")
            {
                Destroy(hitInfo.transform.gameObject);
            }
            hitInfo = Physics2D.Raycast(shotPosition.position, shotPosition.up);
        } while (hitInfo.transform.tag == "EnemyShot");

        lineRenderer.SetPosition(0, shotPosition.position);
        lineRenderer.SetPosition(1, shotPosition.position + shotPosition.up * 20);
        if (hitInfo.transform.gameObject.tag == "Enemy")
        {
            hitInfo.transform.gameObject.GetComponent<EnemyObj>().thisEnemy.getDamage(damage, hitInfo.transform.gameObject);
            GameObject exp = Instantiate(Resources.Load<GameObject>("Prefabs/RocketExplosion"), hitInfo.point, hitInfo.transform.rotation);
            Destroy(exp, 1);
        }
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.6f);
        lineRenderer.enabled = false;
    }
}
