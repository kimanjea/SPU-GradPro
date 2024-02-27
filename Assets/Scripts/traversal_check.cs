using System.Collections.Generic;
using UnityEngine;

public class traversal_check : MonoBehaviour
{
    public GameObject[] buttons;
    public int lifecount = 3;
    public bool wrongorder = false;
    public bool correctorder = false;
    public List<GameObject> userbuttons = new List<GameObject>();

    void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        Debug.Log("Life Count: " + lifecount);
        if (userbuttons.Count == buttons.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                // Compare using a unique identifier (e.g., name, tag, etc.)
                if (userbuttons[i].name != buttons[i].name)
                {
                    Debug.Log("Wrong Order");
                    wrongorder = true;
                    wrongordercheck();
                    lifecount--;
                    return;
                }
            }
            Debug.Log("Correct Order");
            correctorder = true;
            correctordercheck();
            return;
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
            userbuttons.Clear();
        }
    }

    void correctordercheck()
    {
        if (correctorder)
        {
            Debug.Log("Correct Order");
            userbuttons.Clear();
        }
    }
}
