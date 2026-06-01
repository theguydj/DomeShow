using System.Collections;
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
    public Vector3 offset = new Vector3(0, 0, 5);

    public float MoveDuration = 3f;
    private float elapsedTime;

    private bool hasTriggered = false;

    public bool despawnTimer = false;
    public int despawnTimerVal = 500;

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

            //Debug.Log("percentage :" + percentageComplete);
            if (percentageComplete > 1)
            {
                //Debug.Log("TimerRuns");
                despawnTimer = true;
            }



        }

        if (despawnTimer)
        {
            despawnTimerVal -= 1;
            if (despawnTimerVal < 0)
            {
                ObjectToMove.SetActive(false);
            }
        }

    }

    

    public void Despawner()
    {
        despawnTimer = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        hasTriggered = true;
    }
}

