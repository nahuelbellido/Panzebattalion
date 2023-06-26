using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;  
    public float minAngle = -45f;  
    public float maxAngle = 45f;  

    private float currentAngle;

    private void Start()
    {
        currentAngle = transform.localRotation.eulerAngles.x;
    }

    private void Update()
    {
        
        float mouseY = -Input.GetAxis("Mouse Y");

        
        float rotationAmount = mouseY * rotationSpeed;

        
        currentAngle += rotationAmount;

       
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        
        transform.localRotation = Quaternion.Euler(currentAngle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
}
