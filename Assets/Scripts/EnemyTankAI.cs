using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public float movementSpeed = 5f; 
    public float rotationSpeed = 5f; 
    public float shootingRange = 10f; 
    public float visionRange = 15f; 
    public float fireRate = 2f; 
    public GameObject projectilePrefab; 
    
    public Transform firePoint; 
    public float projectileSpeed = 10f; 

    private Transform playerTank; 
    private float nextFireTime;

    private void Start()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
    }

    private void Update()
    {
        if (playerTank == null)
        {
            
            return;
        }

        
        Vector3 direction = playerTank.position - transform.position;
        float distance = direction.magnitude;

       
        if (distance > visionRange)
        {
            
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (distance < shootingRange && Time.time >= nextFireTime)
        {
            
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }

        if (distance > shootingRange)
        {
           
            Vector3 movement = direction.normalized * movementSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }

    private void Fire()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

       
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.velocity = firePoint.forward * projectileSpeed;

       
        Destroy(projectile, 5f);
    }
}
