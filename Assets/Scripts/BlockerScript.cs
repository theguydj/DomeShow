using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public bool OptionRight = false;
    //public bool OptionLeft = false;

    public GameObject Barrier;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
            Barrier.SetActive(true);

    }
}
