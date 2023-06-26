using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;  
    public float shootForce = 100f;  
    public AudioClip shootSound;  
    public AudioSource audioSource;  
    public float shootDelay = 0.5f;  

    private float shootTimer = 0f;  

    private void Update()
    {
        
        shootTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && shootTimer >= shootDelay)
        {
            Shoot();
            shootTimer = 0f;  
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        
        bulletRigidbody.velocity = firePoint.forward * shootForce;

        audioSource.PlayOneShot(shootSound);

        Destroy(bullet, 3f);
    }
}



