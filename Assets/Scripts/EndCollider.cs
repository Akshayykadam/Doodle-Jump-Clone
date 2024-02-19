using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPlatformPrefab;
    public GameObject brokenPlatformPrefab;
    private GameObject myPlate;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.name.StartsWith("Platform"))
        {
            // Check if a random number between 1 and 10 (inclusive) is 1
            int randomValue = Random.Range(1, 8);

            if (randomValue == 1)
            {
                // If true, destroy the current platform and instantiate a spring platform
                Destroy(collision.gameObject);
                Instantiate(springPlatformPrefab, new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f))), Quaternion.identity);
            }
            else if (randomValue <= 2)
            {
                // If the random number is 2, destroy the current platform and instantiate a broken platform //TODO
                Destroy(collision.gameObject);
                Instantiate(platformPrefab /*brokenPlatformPrefab*/, new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f))), Quaternion.identity);
            }
            else
            {
                // If false, move the current platform to a new random position
                collision.gameObject.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("SpringPlatform"))
        {
            // Check if a random number between 1 and 10 (inclusive) is 1
            if (Random.Range(1, 11) == 1)
            {
                // If true, move the spring platform to a new random position
                collision.gameObject.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f)));
            }
            else
            {
                // If false, destroy the spring platform and instantiate a regular or broken platform based on probability
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f))), Quaternion.identity);

            }
        }
        else if (collision.gameObject.name.StartsWith("BrokenPlatform"))
        {
            // Check if a random number between 1 and 10 (inclusive) is 1
            if (Random.Range(1, 11) == 1)
            {
                // If true, move the spring platform to a new random position
                collision.gameObject.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f)));
            }
            else
            {
                // If false, destroy the Broken platform and instantiate a regular platform based on probability
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-1.5f, 1.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f))), Quaternion.identity);

            }
        }
    }
}
