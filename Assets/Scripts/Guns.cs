using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    protected virtual float fireRate { get; set; }
    protected virtual float speed { get; set; }
    protected virtual float damage { get; set; } = 100f;
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
    protected override float damage { get => base.damage; set => base.damage = value; }
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {
        
            Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);
        
    }
}
public class FireArm : Guns
{
    protected override float fireRate { get; set; } = 0.5f;
    protected override float speed { get; set; } = 15f;
    protected override float damage { get => base.damage; set => base.damage = 50f; }
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {

        Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);

    }
}
public class Laser : Guns
{
    protected override float fireRate { get; set; } = 5f;
    protected override float damage { get => base.damage; set => base.damage = 300f; }
    public override void Shoot(GameObject shotPrefab, Transform shotPosition)
    {

        Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);

    }
}
    