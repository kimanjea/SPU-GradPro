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
    private bool bgmWasPlayingBeforeMenuOpened;

    void Start()
    {
        // 如果 bgm 不为空，则记录下当前是否正在播放
        if (bgm != null)
        {
            bgmWasPlayingBeforeMenuOpened = bgm.isPlaying;
        }
    }

    void Update()
    {
        if(menuKeys)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;

                // 如果 bgm 不为空且当前正在播放，则暂停播放
                if (bgm != null && bgm.isPlaying)
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

                // 如果 bgm 不为空且在菜单打开之前正在播放，则恢复播放
                if (bgm != null && bgmWasPlayingBeforeMenuOpened)
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
        
        // 如果 bgm 不为空，则确保在返回时恢复播放
        if (bgm != null && bgmWasPlayingBeforeMenuOpened)
        {
            bgm.UnPause();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneID); 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
