using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float backwardSpeed = 2.5f;
    public float rotationSpeed = 100f;
    public float boostMultiplier = 2f;
    public float raycastDistance = 1f;

    private Rigidbody tankRigidbody;
    private Collider tankCollider;

    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody>();
        tankCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");
        bool boostInput = Input.GetKey(KeyCode.LeftShift);

        float speed = moveInput > 0f ? forwardSpeed : backwardSpeed;
        if (boostInput)
        {
            speed *= boostMultiplier;
        }

        Vector3 movement = transform.forward * moveInput * speed * Time.deltaTime;
        tankRigidbody.MovePosition(tankRigidbody.position + movement);

        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        Quaternion rotationQuaternion = Quaternion.Euler(0f, rotation, 0f);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * rotationQuaternion);

        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider != tankCollider)
            {
                tankRigidbody.MovePosition(tankRigidbody.position - movement); // Revertir el movimiento
            }
        }
    }
}
