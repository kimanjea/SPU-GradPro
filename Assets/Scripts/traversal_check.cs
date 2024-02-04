using System.Collections.Generic;
using UnityEngine;

public class traversal_check : MonoBehaviour
{

    public GameObject[] buttons;

    public List<GameObject> userbuttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

               
    }

    // Update is called once per frame
    void Update()
    {
        if (userbuttons.Count == buttons.Length)
        {
            for(int i = 0;  i < buttons.Length; i++)
            {
                if (userbuttons[i] != buttons[i])
                {
                    Debug.Log("WASTED WRONG IDOT DUMBASS");
                    userbuttons.Clear();
                    return;
                }
            }
            Debug.Log("WOW YOU ACTUALLY DID IT");
            return;
        }       
    }

    public void Addtouserbuttons(GameObject buttonstoadd)
    {
        userbuttons.Add(buttonstoadd);
    }

}