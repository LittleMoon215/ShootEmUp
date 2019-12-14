using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    public virtual float damage { get; set; } = 100f;
    public void Shoot(GameObject shotPrefab, Transform shotPosition)
    {
        Instantiate(shotPrefab, shotPosition.position, shotPosition.rotation);
    }


}
public class Rockets : Guns
{
    public override float damage { get => base.damage; set => base.damage = value; }
}
public class FireArm : Guns
{
    public override float damage { get => base.damage; set => base.damage = 50f; }
}
public class Laser : Guns
{
    public override float damage { get => base.damage; set => base.damage = 300f; }
}
    