using UnityEngine;

public class DoubleTapToQuit : MonoBehaviour
{
    private bool isBackPressed = false;
    private float doubleTapTimeThreshold = 2.0f; // Adjust the time threshold as needed
    private float lastTapTime = 0.0f;

    void Update()
    {
        // Check for back button press (or any designated key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isBackPressed && Time.time - lastTapTime < doubleTapTimeThreshold)
            {
                // Double-tap detected, quit the application
                Application.Quit();
            }
            else
            {
                // First tap, set flag and record the time
                isBackPressed = true;
                lastTapTime = Time.time;

                // Show a message or perform other actions on the first tap if needed
                Debug.Log("Press back again to quit.");
            }
        }

        // Reset the flag if too much time has passed since the last tap
        if (Time.time - lastTapTime > doubleTapTimeThreshold)
        {
            isBackPressed = false;
        }
    }
}
