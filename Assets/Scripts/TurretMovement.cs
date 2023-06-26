using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;  

    private void Update()
    {
       
        Vector3 mousePosition = Input.mousePosition;

        
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

       
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float raycastDistance;
        if (groundPlane.Raycast(ray, out raycastDistance))
        {
           
            Vector3 targetPosition = ray.GetPoint(raycastDistance);

            
            Vector3 targetDirection = targetPosition - transform.position;
            targetDirection.y = 0f; 

            if (targetDirection != Vector3.zero)
            {
               
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

               
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}