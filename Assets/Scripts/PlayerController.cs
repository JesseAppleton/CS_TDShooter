using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public bool useController;

    // Start is called before the first frame update
    void Start()
    {
        // gets whatever model is set for player
        myRigidbody = GetComponent<Rigidbody>();

        // acknowledges camera for this object
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sets movement input variable to vector3, x, y, z.
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        
        // Rotate with mouse
        if(!useController) 
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {   
                // forces object to look at the point of mouse
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

                // shows ray from camera to mouse position
                // Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            }

            // detects gun firing or not
            if(Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }

        // Rotate with controller
        if (useController)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * -Input.GetAxisRaw("Vertical");

            if(playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if(Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                theGun.isFiring = true;
            }
            if(Input.GetKeyUp(KeyCode.JoystickButton5))
            {
                theGun.isFiring = false;
            }
        }


    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity; 
    }
}
