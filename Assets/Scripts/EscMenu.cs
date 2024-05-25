using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject menuList;
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private int sceneID; 

    void Update()
    {
        if(menuKeys)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                
                if (bgm != null)
                {
                    bgm.Pause(); 
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(false);
                menuKeys = true;
                
                if (bgm != null)
                {
                    bgm.UnPause(); 
                }
            }
        }
    }

    public void Return()
    {
        menuList.SetActive(false);
        menuKeys = true;
        
        if (bgm != null)
        {
            bgm.UnPause(); 
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneID); 
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(0); 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
