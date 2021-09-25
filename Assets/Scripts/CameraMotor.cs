using System;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform LookAt;

    public float BoundX = 0.15f;
    public float BoundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = LookAt.position.x - transform.position.x;
        if (deltaX > BoundX || deltaX < -BoundX)
        {
            if (transform.position.x < LookAt.position.x)
            {
                delta.x = deltaX - BoundX;
            }
            else
            {
                delta.x = deltaX + BoundX;
            }
        }
        
        float deltaY = LookAt.position.y - transform.position.y;
        if (deltaY > BoundY || deltaY < -BoundY)
        {
            if (transform.position.y < LookAt.position.y)
            {
                delta.y = deltaY - BoundY;
            }
            else
            {
                delta.y = deltaY + BoundY;
            }
        }

        if (delta != Vector3.zero)
            transform.position += new Vector3(delta.x, delta.y, 0.0f);
    }
}
