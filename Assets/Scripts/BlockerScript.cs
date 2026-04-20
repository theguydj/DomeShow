using Unity.VisualScripting;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public bool OptionRight = false;
    //public bool OptionLeft = false;

    public GameObject Barrier;
    //public GameObject Barrier2;

    void Start()
    {
        Barrier.SetActive(false);
    }



    //Runs this code when a collision box is entered

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Barrier.SetActive(true);
            Debug.Log("BloackerScript Worked");
        }
    }

    // Update is called once per frame



    void Update()
    {
       

        
    }

    
}
