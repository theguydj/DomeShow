using System.Threading;
using UnityEngine;

public class CollisionBoxScript : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectToSpawn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BloackerScript Started");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("BloackerScript Left Worked");
            objectToSpawn.SetActive(true);

        }
    }




}
