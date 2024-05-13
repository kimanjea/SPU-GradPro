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

    public RawImage rawImage;

    public void LoadNextLevel(int sceneID)
    {
        StartCoroutine(LoadLevel(sceneID));
    }

    IEnumerator LoadLevel(int sceneID)
    {
        loadScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = (operation.progress * 100).ToString("F0") + "%";

            if (operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "Press Any Key to Continue";

                if (Input.anyKeyDown) 
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
