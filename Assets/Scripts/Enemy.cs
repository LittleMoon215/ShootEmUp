using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected virtual float hp { get; set; }
    public virtual float damage { get; set; }
    public abstract void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat);
    public abstract void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos, Quaternion shootRotation);
}
public class StandartEnemy : Enemy
{
    protected override float hp { get; set; } = 110f;
    public override float damage { get; set; } = 20f;
    public override void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat)
    {
        Instantiate(enemyPrefab, enemyPos,enemyQuat);
    }
    public override void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos,Quaternion shootRotation)
    {
        Instantiate(enemyShotPrefab,shootPos,shootRotation);
    }
}

public abstract class EnemyCreator
{
    public abstract Enemy EnemyCreate();
}

public class StandartEnemyCreator : EnemyCreator
{
    public override Enemy EnemyCreate()
    {
        return new StandartEnemy();
    }
}