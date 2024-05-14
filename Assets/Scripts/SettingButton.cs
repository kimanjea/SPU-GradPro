using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainCanvas; 
    public GameObject settingsCanvas; 

    void Start1()
    {
        
        settingsCanvas.SetActive(false);
    }

    public void ShowSettings()
    {
        
        settingsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        
        settingsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
