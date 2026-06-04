using JetBrains.Annotations;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class CameraController : MonoBehaviour
{
    

    public WaypointScript locationA;
    public WaypointScript locationB;

    public float CameraSpeed = 2.0f;
    public float LerpAlpha = 0f;


    // Update is called once per frame
    void Update()
    {

        LerpAlpha += Time.deltaTime;
        
        if(locationB  != null)
        {
            transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * CameraSpeed); 
           
        }



        if (locationB != null)
        {
            gameObject.transform.rotation = locationB.newDirection;
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

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("A");
            locationA.NextWaypoint = locationA.waypointPointOptionA;
            locationB = locationA.waypointPointOptionA;
            LerpAlpha = 0f;
            
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
