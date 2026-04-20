using System.Threading;
using UnityEngine;

public class CollisionBoxScript : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void nTriggerEnter(Collider other)
    {
        Debug.Log("BloackerScript Started");
        if (other.gameObject.tag == "ChoiceLeft")
        {
            Debug.Log("BloackerScript Left Worked");
            objectToSpawn.SetActive(true);
            
        }
        else if (Other.gameObject.tag == "ChoiceRight")
        {
            Debug.Log("BloackerScript Right Worked");
            Barrier2.SetActive(true);
            Triggered = true;

        }
    }
}
