using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // The smoothness of the camera movement
    public Vector3 offset; // The offset from the target's position

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
