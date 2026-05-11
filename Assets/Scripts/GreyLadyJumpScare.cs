using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GreyLadyJumpScare : MonoBehaviour
{


    public GameObject ObjectToMove;
    public float MoveLeftAmount;
    public float MoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerHit Hit");

        transform.position = Vector3.Lerp(transform.position, ObjectToMove.position,
        MoveLeftAmount * Time.deltaTime);

    }
}

