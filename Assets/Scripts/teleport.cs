using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public bool addProgress; // Flag to determine whether to add progress when teleporting
    public SceneSwap sceneSwap; // Reference to the SceneSwap script
    public bool needSwap = false;
    public string sceneName; // Name of the scene to teleport to
    public bool requiresGame = false; // Flag to determine whether a requirement must be met to use the teleport
    public int requiredProgress = 0; // If requiresGame is true, this variable determines the required level to use the teleport.


    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("Player"))
        {
            if (requiresGame && Progress.level < requiredProgress){

                Debug.Log("You need to complete the game to unlock this level");
                return;

            }else{

                SceneManager.LoadScene(sceneName);
                if (sceneSwap)
                {
                    sceneSwap.SwapAndTeleport(sceneName);
                }
                Debug.Log("New Scene Loaded: " + sceneName);

                SceneManager.LoadScene(sceneName);
            }

            
        }
    }

}

