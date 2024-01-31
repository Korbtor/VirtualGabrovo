using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraHeight = 10f; // Height of the camera over the game map
    public float cameraSpeed = 5f; // Speed of camera movement

    private Vector2 touchStartPos;
    private bool isTouching = false;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record the starting position of the touch
                    touchStartPos = touch.position;
                    isTouching = true;
                    break;

                case TouchPhase.Moved:
                    if (isTouching)
                    {
                        // Calculate the delta movement of the touch
                        Vector2 deltaPos = touch.position - touchStartPos;

                        // Adjust the delta movement based on the camera's height
                        deltaPos /= cameraHeight;

                        // Invert the movement for opposite camera movement
                        deltaPos = -deltaPos;

                        // Move the camera in the opposite direction
                        Vector3 cameraMovement = new Vector3(deltaPos.x, 0f, deltaPos.y) * cameraSpeed * Time.deltaTime;
                        transform.Translate(cameraMovement, Space.World);

                        // Update the starting position for the next frame
                        touchStartPos = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isTouching = false;
                    break;
            }
        }
    }
}
