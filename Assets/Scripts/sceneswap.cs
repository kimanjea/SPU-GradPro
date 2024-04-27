using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Ensure this script persists across scene changes
    }

    public void SwapAndTeleport(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);

        // Teleport the player to the specified position after the scene has loaded
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
        };
    }
}
