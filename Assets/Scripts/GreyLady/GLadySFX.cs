using UnityEngine;

public class GLadySFX : MonoBehaviour
{


    public AudioClip clip; 
       
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));


    }

   
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
