using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraSmoothTurn : MonoBehaviour
{

    public Transform target;
    private Transform targetShuffle;

    public WaypointScript locationA;
    public WaypointScript locationB;

    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = locationB.transform;



        Vector3 targetDirection = target.position - transform.position;

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
