using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
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
        if (Touchscreen.current == null)
        {
            Debug.LogWarning(" Touchscreen input not available — are you running this on PC?");
            return;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition= Touchscreen.current.primaryTouch.position.ReadValue();

            Debug.Log(" Screen position" + touchPosition);
            
            Vector3 ConvertPos= new Vector3 (touchPosition.x,touchPosition.y, 10f);
            // screen to world is giving z default if not assign z
            //To avaoid this , I am using another  (positive) Vctor3 varibale to convert with a fixed Z value.

            Vector3 worldPosition= mainCamera.ScreenToWorldPoint(ConvertPos);

            Debug.Log(" World position" + worldPosition);
        }
    }
}
