using UnityEngine;

public class BrokenPlatformScript : MonoBehaviour
{
    public Sprite newSprite; // Public variable for the new sprite

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if collided with the player
        {
            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Change the sprite to the public newSprite
            spriteRenderer.sprite = newSprite;

            //Destroy(collision.gameObject);
        }
    }
}
