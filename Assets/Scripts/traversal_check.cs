using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class traversal_check : MonoBehaviour
{
    public string scenename;
    public GameObject[] buttons;
    public GameObject[] lv2Buttons;
    public GameObject[] lv3Buttons;
    public int lifecount = 3;
    public int gamelevel = 1;
    public bool wrongorder = false;
    public bool correctorder = false;
    public List<GameObject> userbuttons = new List<GameObject>();

    void Start()
    {
        // Initialize the buttons order for the first level
        SetButtonsOrder();
    }

    void Update()
    {
        Debug.Log("Life Count: " + lifecount);

        if (userbuttons.Count == buttons.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (userbuttons[i].name != buttons[i].name)
                {
                    Debug.Log("Wrong Order");
                    wrongorder = true;
                    wrongordercheck();
                    lifecount--;

                    if (lifecount <= 0)
                    {
                        // Game over logic or reset level
                        Debug.Log("Game Over");
                        lifecount = 3; //Resets life count after losing three times. Fix.
                        gamelevel = 1;
                        SetButtonsOrder();
                    }
                    else
                    {
                        // Incorrect order but still has lives, continue to the next attempt
                        ClearUserButtons();
                    }
                    return;
                }
            }

            Debug.Log("Correct Order");
            correctorder = true;
            correctordercheck();

            // If the correct order is pressed, move to the next level
            gamelevel++;
            SetButtonsOrder();
            ClearUserButtons();
            return;
        }
        if (gamelevel > 3)
        {
            StartCoroutine(levelsuccess(10f));
        }
        
    }

    public void Addtouserbuttons(GameObject buttonstoadd)
    {
        userbuttons.Add(buttonstoadd);
    }

    void wrongordercheck()
    {
        if (wrongorder)
        {
            Debug.Log("Wrong Order");
            ClearUserButtons();
        }
    }

    void correctordercheck()
    {
        if (correctorder)
        {
            Debug.Log("Correct Order");
            ClearUserButtons();
        }
    }

    void ClearUserButtons()
    {
        userbuttons.Clear();
    }

    void SetButtonsOrder()
    {
        if (gamelevel == 2)
        {
            buttons = lv2Buttons;
        }
        else if (gamelevel == 3)
        {
            buttons = lv3Buttons;
        }
    }
    IEnumerator levelsuccess(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scenename); 
    }

}
