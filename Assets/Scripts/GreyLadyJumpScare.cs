using UnityEngine;

public class GreyLadyJumpScare : MonoBehaviour
{


    public GameObject ObjectToMove;
    public float MoveLeftAmount;

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
        Debug.Log("Hit");
        ObjectToMove.transform.position += new Vector3 (MoveLeftAmount, 0, 0);
    }
}

