using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject menuList;
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgm;
    
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
                    bgm.Stop();
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
                    bgm.Play();
                }
            }
        }
    }

    public void Return()
    {
        menuList.SetActive(false);
        menuKeys = true;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(5);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
