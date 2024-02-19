using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpScript : MonoBehaviour
{
    public float springConstant = 10f; // Spring constant (k)
    public float dampingFactor = 2f; // Damping factor (d)
    public float maxForceMagnitude = 50f; // Maximum force magnitude to apply

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 displacement = (Vector2)transform.position - collision.contacts[0].point;

                // Calculate spring force using Hooke's Law: F = -k * x - d * v
                Vector2 springForce = -springConstant * displacement - dampingFactor * rb.velocity;

                // Cap the maximum force magnitude
                springForce = Vector2.ClampMagnitude(springForce, maxForceMagnitude);

                // Apply the spring force to the colliding object
                rb.AddForce(springForce, ForceMode2D.Impulse);
            }
        }
    }
}
