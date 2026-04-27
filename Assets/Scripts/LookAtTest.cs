using UnityEngine;

public class LookAtTest : MonoBehaviour
{

    public GameObject LookAt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(LookAt.transform, LookAt.transform.up);
        transform.RotateAround(transform.position, transform.right, 90);
    }
}
