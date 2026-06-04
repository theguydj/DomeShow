using Unity.VisualScripting;
using UnityEngine;

public class CutScene2 : MonoBehaviour
{

    public Camera FlatCamera;
    public Camera DomeCamera;

    public bool CameraSwitch = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // DomeCamera.enabled = true;
       // FlatCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SwitchCamera()
    {
        DomeCamera.enabled = false;
        FlatCamera.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("CameraSwitched");
        SwitchCamera();
    }

    
}
