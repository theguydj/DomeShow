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

  //  public bool isTrigger = false;
  //  public bool Triggered = false;

    public float CameraSpeed = 2.0f;
    public float RotationSpeed = 0.01f;
    public float rotateLerp = 0.0f;
    public float LerpAlpha = 0f;
    public float Offset = 0f;

    // public GameObject LookAt;
    


    public Quaternion rotationB = Quaternion.Euler(30, 0, 0);
    
    

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This script moves the cammera between 2 designated locations.

       // transform.LookAt(LookAt.transform);

        LerpAlpha += Time.deltaTime;
        //LerpAlpha = Mathf.Min(LerpAlpha, 1f);
        if(locationB  != null)
        {
            transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * CameraSpeed); //- (locationA.gameObject.transform.forward * Offset);
           // LookAt.transform.position = Vector3.Lerp(locationA.transform.position, locationB.transform.position, LerpAlpha * (CameraSpeed + LookAtTargetSpeed)) + (locationA.gameObject.transform.up * Offset);
        }


        //transform.LookAt(LookAt.transform);
        // transform.RotateAround(transform.position, transform.right, 90);
       // Vector3 targetDirection = Vector3.zero;


        if (locationB != null)
        {
            
            
       //         targetDirection = locationB.transform.position - transform.position;
            
        }


       


      //  float singleStep = LookAtTargetSpeed * Time.deltaTime;

      //  Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        //transform.rotation = Quaternion.LookRotation(newDirection);


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
                //gameObject.transform.rotation = locationA.newDirection;
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
