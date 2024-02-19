using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class teleport : MonoBehaviour
{ 
    public string scenename;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         
            SceneManager.LoadScene(scenename);
			Debug.Log("New Scene Loaded");
            
        }
    }

}
