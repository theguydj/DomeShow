using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GreyLadyJumpScare : MonoBehaviour
{

    public GameObject Camera;
    public GameObject ObjectToMove;

    private Vector3 endPosition;
    private Vector3 startPosition;
    private Vector3 offset = new Vector3(0, 0, 5);

    public float MoveDuration = 3f;
    private float elapsedTime;

    private bool hasTriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = ObjectToMove.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endPosition = Camera.transform.position + offset;


        if (hasTriggered == true)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / MoveDuration;

            ObjectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerHit Hit");

        //ObjectToMove.transform.position += new Vector3(MoveLeftAmount, 0, 0);
        //transform.position += new Vector3.Lerp(0, 0, 0);

        hasTriggered = true;

       // elapsedTime += Time.deltaTime;
       // float percentageComplete = elapsedTime / MoveDuration;

       // ObjectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);


    }
}

