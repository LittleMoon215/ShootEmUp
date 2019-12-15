using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    public enum ENEMY_TYPE { STANDART_ENEMY = 0, CAT_ENEMY, BOSS_ENEMY }
    protected virtual float hp { get; set; }
    public virtual ENEMY_TYPE type { get; protected set; }
    public abstract void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat);
    public abstract void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos, Quaternion shootRotation);

}
public class StandartEnemy : Enemy
{
    public override ENEMY_TYPE type { get; protected set; } = ENEMY_TYPE.STANDART_ENEMY;
    protected override float hp { get; set; } = 110f;
    public override void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat)
    {
        Instantiate(enemyPrefab, enemyPos, enemyQuat);
    }
    public override void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos, Quaternion shootRotation)
    {
        Instantiate(enemyShotPrefab, shootPos, shootRotation);
    }
}

public class CatEnemy : Enemy
{
    public override ENEMY_TYPE type { get; protected set; } = ENEMY_TYPE.CAT_ENEMY;
    protected override float hp { get; set; } = 300f;
    public override void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat)
    {
        Instantiate(enemyPrefab, enemyPos, enemyQuat);
    }
    public override void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos, Quaternion shootRotation)
    {

        Instantiate(enemyShotPrefab, shootPos, shootRotation);

    }
}
public class BossEnemy : Enemy
{
    Quaternion degree;
    public override ENEMY_TYPE type { get; protected set; } = ENEMY_TYPE.BOSS_ENEMY;
    protected override float hp { get; set; } = 6000f;
    public override void enemySpawn(GameObject enemyPrefab, Vector3 enemyPos, Quaternion enemyQuat)
    {
        Instantiate(enemyPrefab, enemyPos, enemyQuat);
    }
    public override void enemyShoot(GameObject enemyShotPrefab, Vector2 shootPos, Quaternion shootRotation)
    {
        degree = shootRotation;
        for (int i = 0; i < 60; ++i)
        {
            degree.eulerAngles = Vector3.forward * i * Random.Range(1,10);
            Instantiate(enemyShotPrefab, shootPos, degree);
        }
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
public class CatEnemyCreator : EnemyCreator
{
    public override Enemy EnemyCreate()
    {
        return new CatEnemy();
    }
}
public class BossEnemyCreator : EnemyCreator
{
    public override Enemy EnemyCreate()
    {
        return new BossEnemy();
    }
}