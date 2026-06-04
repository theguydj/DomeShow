using UnityEngine;
using UnityEngine.InputSystem;

public class CutSceneCameraController : MonoBehaviour
{


    public float moveSpeed;

    public float sensX;
    public float sensY;

    public Transform orientation;
    

    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse  X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse  Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        







        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.position = transform.position + new Vector3(moveSpeed * -1, 0, 0);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.position = transform.position + new Vector3(moveSpeed, 0, 0);
        }



        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            transform.position = transform.position + new Vector3(0, 0, moveSpeed);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.position = transform.position + new Vector3(0, 0, moveSpeed * -1);
        }
    }
}
