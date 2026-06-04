using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCutscene()
    {
        SceneManager.LoadScene("CutSceneLVL");
    }


    private void OnTriggerEnter(Collider other)
    {
        ActivateCutscene();
    }
}
