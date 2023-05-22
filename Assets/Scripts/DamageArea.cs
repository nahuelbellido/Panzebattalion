using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float damageInterval = 1f;

    private bool isTankInside = false;
    private float nextDamageTime;

    private void Update()
    {
        if (isTankInside && Time.time >= nextDamageTime)
        {
            TankStats tankStats = FindObjectOfType<TankStats>();
            if (tankStats != null)
            {
                tankStats.TakeDamage(damagePerSecond);
            }

            nextDamageTime = Time.time + damageInterval;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTankInside = true;
            nextDamageTime = Time.time + damageInterval;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTankInside = false;
        }
    }
}