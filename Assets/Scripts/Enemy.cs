using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected virtual float hp { get; set; }
    public abstract void enemyCreateShot(GameObject enemyPrefab, Transform enemyPos);
   
}
public class StandartEnemy : Enemy
{
    protected override float hp { get; set; } = 110f;
    public override void enemyCreateShot(GameObject enemyPrefab, Transform enemyPos)
    {

        Instantiate(enemyPrefab, enemyPos);
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