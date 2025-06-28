using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody rb;

    [SerializeField] private float forceMagnitude = 5f;
    [SerializeField] private float maxVelocity = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError(" Camera.main is NULL! Check your setup.");
        }
        else
        {
            Debug.Log(" Camera found: " + mainCamera.name);
        }
    }

    void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) return;

        rb.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);

        // Clamp player speed
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current == null)
        {
            Debug.LogWarning(" Touchscreen input not available. Are you testing on PC?");
            return;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 screenPosition = new Vector3(touchPosition.x, touchPosition.y, 10f); // Z = distance from camera
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

            movementDirection = worldPosition - transform.position;
            movementDirection.z = 0f; // Stay in 2D plane
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x > 1f) newPosition.x = -newPosition.x + 0.1f;
        if (viewPortPosition.x < 0f) newPosition.x = -newPosition.x - 0.1f;
        if (viewPortPosition.y > 1f) newPosition.y = -newPosition.y + 0.1f;
        if (viewPortPosition.y < 0f) newPosition.y = -newPosition.y - 0.1f;

        transform.position = newPosition;
    }

    private void RotateToFaceVelocity()
    {
        Vector3 velocity = rb.linearVelocity;

        if (velocity.sqrMagnitude < 0.001f) return;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f); // Adjust based on model orientation

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
