using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class CameraController : MonoBehaviour
{
    

    public WaypointScript locationA;
    public WaypointScript locationB;
    public bool isTrigger = false;
    public float CameraSpeed = 2.0f;
    public float LookAtTargetSpeed = 1.0f;
    public float LerpAlpha = 0f;
    public GameObject LookAt;

    public GameObject Barrier;
    //public GameObject Barrier2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Barrier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This script moves the cammera between 2 designated locations.

        Barrier.SetActive(false);

        transform.LookAt(LookAt.transform);

        LerpAlpha += Time.deltaTime;
        if(locationB  != null)
        {
            transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * CameraSpeed);
            LookAt.transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * (CameraSpeed + LookAtTargetSpeed));
        }

        if (LerpAlpha * CameraSpeed > 1)
        {
            if (locationA.NextWaypoint != null)
            {
                locationA = locationB;
                locationB = locationB.NextWaypoint;
                LerpAlpha = 0f;
            }
        }

        //alows us to shose between 2 different waypoints

        if (Input.GetKeyDown(KeyCode.A))
        {
            locationA.NextWaypoint = locationA.waypointPointOptionA;
            locationB = locationA.waypointPointOptionA;
            LerpAlpha = 0f;
            Debug.Log("A");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            locationA.NextWaypoint = locationA.waypointPointOptionB;
            locationB = locationA.waypointPointOptionB;
            LerpAlpha = 0f;
            Debug.Log("D");
  
        }
    }
    //Runs this code when a collision box is entered

    private void OnTriggerEnter(Collider collisionBox)
    {
        if (collisionBox.CompareTag("Player"))
        {
            Barrier.SetActive(true);
            Debug.Log("BloackerScript Worked");
        }
    }

    


}
