using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletDamage = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        EnemyTankController enemyTank = collision.gameObject.GetComponent<EnemyTankController>();
        if (enemyTank != null)
        {
            enemyTank.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
