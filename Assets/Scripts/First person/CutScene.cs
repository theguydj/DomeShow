using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{

    public GameObject Camera;
    public GameObject Location;

    public VideoPlayer Player;

    public bool Trigger = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger == true)
        {
            Camera.transform.position = Location.transform.position;
            Camera.transform.rotation = new Quaternion(0, 0, 0, 0);
            

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        Trigger = true;
        Player.Play();
    }
}
