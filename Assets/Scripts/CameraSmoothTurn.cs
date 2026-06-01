using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraSmoothTurn : MonoBehaviour
{

    public Transform target;
    private Transform targetShuffle;
    public Vector3 offset = Vector3.zero;

    

    public WaypointScript locationA;
    public WaypointScript locationB;

    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        target = locationB.transform;


        Quaternion rotationB = Quaternion.Euler(30, 0, 0);


        Vector3 targetDirection = target.position - (transform.position + offset);

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection) * rotationB;
    }
}
