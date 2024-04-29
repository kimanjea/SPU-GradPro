using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public bool addProgress; // Flag to determine whether to add progress when teleporting
    Progress Progress;
    public SceneSwap sceneSwap; // Reference to the SceneSwap script
    public string sceneName; // Name of the scene to teleport to

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            sceneSwap.SwapAndTeleport(sceneName);
            Debug.Log("New Scene Loaded: " + sceneName);
            addprogress();
         
            SceneManager.LoadScene(sceneName);
            
        }
    }

    void addprogress()
    {
        Progress.progression += 25;
    }

}