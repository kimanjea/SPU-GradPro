using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public TextMeshProUGUI text;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        loadScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = (operation.progress * 100).ToString("F0") + "%";

            if (operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "Press Any Key to Continue";
            }

            yield return null;
        }

        
        if (Input.anyKeyDown)
        {
            operation.allowSceneActivation = true;
        }
    }
}
