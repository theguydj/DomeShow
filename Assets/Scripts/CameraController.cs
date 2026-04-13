using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;


public class CameraController : MonoBehaviour
{
    

    public WaypointScript locationA;
    public WaypointScript locationB;
    public bool isTrigger = false;
    public float CameraSpeed = 2.0f;
    public float LerpAlpha = 0f;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This script moves the cammera between 2 designated locations.

        

        LerpAlpha += Time.deltaTime;
        if(locationB  != null)
        {
            transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * CameraSpeed);
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


   
}
