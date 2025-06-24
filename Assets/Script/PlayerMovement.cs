using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody rb;


    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;

    private Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

      mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError(" Camera.main is NULL! Check camera setup.");
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
    }

    private void FixedUpdate()
    {
             if(movementDirection == Vector3.zero) { return; }

             rb.AddForce(movementDirection*forceMagnitude*Time.deltaTime,ForceMode.Force);

        rb.linearVelocity=Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
    }


    private void ProcessInput()
    {
        if (Touchscreen.current == null)
        {
            Debug.LogWarning(" Touchscreen input not available — are you running this on PC?");
            return;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Debug.Log(" Screen position" + touchPosition);

            Vector3 ConvertPos = new Vector3(touchPosition.x, touchPosition.y, 10f);
            // screen to world is giving z default if not assign z
            //To avaoid this , I am using another  (positive) Vctor3 varibale to convert with a fixed Z value.

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(ConvertPos);

            Debug.Log(" World position" + worldPosition);

            movementDirection = worldPosition - transform.position;
            movementDirection.z = 0f;
            movementDirection.Normalize();


        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition= transform.position;

       Vector3 viewPortPosition= mainCamera.WorldToViewportPoint(transform.position);

        if(viewPortPosition.x > 1f)
        {
            newPosition.x = -newPosition.x+ 0.1f;
        }

        if (viewPortPosition.x < 0f)
        {
            newPosition.x = -newPosition.x -0.1f;
        }

        if (viewPortPosition.y > 1f)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }

        if (viewPortPosition.y < 0f)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }
}
