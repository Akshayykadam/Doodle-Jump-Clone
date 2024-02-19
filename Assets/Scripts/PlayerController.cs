using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveInput;
    public float speed = 5f;
    public TMP_Text scoreText;

    private float TopScore = 0.0f;

    readonly int targetFramerate = 120;

    private float accelerometerInputSmoothed;
    public float smoothingFactor = 0.1f;

    void Start()
    {
        GamePlayManager.Instance.GameOverPanel.SetActive(false);
        rigidBody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = targetFramerate;
        //if (SystemInfo.supportsAccelerometer)
        //{
        //    // Enable the gyroscope only on Android
        //    Input.supportsAccelerometer.enabled = true;
        //}

    }

    private void Update()
    {

        if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rigidBody.velocity.y > 0 && transform.position.y > TopScore)
        {
            TopScore = transform.position.y;
        }      

        scoreText.text = "Score : " + Mathf.Round(TopScore).ToString();

        // Check if player's velocity is less than -10
        if (rigidBody.velocity.y < -20f)
        {
            // Trigger game over
            Debug.Log("Game Over");
            GamePlayManager.Instance.GameOverPanel.SetActive(true);
        }

        float Score = Mathf.Round(TopScore);
        PlayerPrefs.SetFloat("TopScore", Score);
        PlayerPrefs.Save();
    }

    public void FixedUpdate()
    {
        float sensitivity = 2f;

        if (SystemInfo.supportsAccelerometer)
        {
            // Smooth the accelerometer input
            accelerometerInputSmoothed = Mathf.Lerp(accelerometerInputSmoothed, Input.acceleration.x, smoothingFactor);

            // Apply the smoothed and scaled accelerometer input to the player's velocity
            rigidBody.velocity = new Vector2(accelerometerInputSmoothed * speed * sensitivity, rigidBody.velocity.y);
        }

        else
        {
            //// For other platforms (including Unity Editor), use the previous input method (e.g., keyboard or touch)
            float moveInput = Input.GetAxis("Horizontal");
            rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
        }
    }
}
