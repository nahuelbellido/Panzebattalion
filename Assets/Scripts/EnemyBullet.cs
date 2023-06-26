using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 10f;
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si colisiona con el tanque del jugador
        TankStats tankStats = collision.gameObject.GetComponent<TankStats>();
        if (tankStats != null)
        {
            tankStats.TakeDamage(damage); // Resta vida al tanque del jugador
        }

        // Instancia la explosión
        

        // Destruye la bala
       
    }
}
