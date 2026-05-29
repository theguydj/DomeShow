using UnityEngine;
using UnityEngine.InputSystem;

public class CutSceneCameraController : MonoBehaviour
{


    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.aKey.wasPressedThisFrame)
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
