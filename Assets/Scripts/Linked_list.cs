using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Linked_list : MonoBehaviour
{
    public List<GameObject> tablets = new List<GameObject>();
    public GameObject firstClickedTablet;
    public GameObject arrowPrefab; // Assign the arrow prefab in the Unity Editor
    public string scenename;
    Progress progression;

    public GameObject[] node; // correct orders of the nodes for each lvl
    public GameObject[] lvl2node;
    public GameObject[] lvl3node;
    private List<GameObject> selectedTablets = new List<GameObject>(); // List to keep track of selected tablets
    public List<GameObject> usernodes = new List<GameObject>();
    public int gamelevel = 1;
    public int lifecount = 3;

    // List to store created links
    private List<(GameObject, GameObject)> createdLinks = new List<(GameObject, GameObject)>();

    void Start()
    {
        // Initialize your game here if necessary
    }

    void Update()
    {
        // Ensure that both the usernodes list and the node array have elements
        if (usernodes.Count > 0 && node.Length > 0)
        {
            // Ensure that the usernodes list has the same count as the node array
            if (usernodes.Count == node.Length)
            {
                for (int i = 0; i < node.Length; i++)
                {
                    if (usernodes[i].name != node[i].name)
                    {
                        Debug.Log("Wrong Order");
                        lifecount--;
                        if (lifecount == 0)
                        {
                            StartCoroutine(levelfinished(5f));
                        }

                        if (lifecount <= 0)
                        {
                            // Game over logic or reset level
                            Debug.Log("Game Over");
                            // Add any additional game over logic here
                        }
                        else
                        {
                            // Incorrect order but still has lives, continue to the next attempt
                            ClearUserButtons();
                        }
                        return;
                    }
                }
                // If the loop completes without returning, it means the order is correct
                Debug.Log("Correct Order");
                gamelevel++;
                ClearUserButtons(); // Clear user selections
                SetnodeOrder(); // Set the node order for the next level
                if (gamelevel > 3)
                {
                    StartCoroutine(levelfinished(5f));
                }
            }
        }
    }

    public void OnTabletClicked(GameObject clickedTablet)
    {
        if (firstClickedTablet == null)
        {
            firstClickedTablet = clickedTablet;
            HighlightTablet(clickedTablet, Color.green);
            selectedTablets.Add(clickedTablet); // Add the first clicked tablet to the selected list
        }
        else if (firstClickedTablet == clickedTablet)
        {
            HighlightTablet(firstClickedTablet, Color.white);
            firstClickedTablet = null;
        }
        else
        {
            // Check if the link already exists before creating a new arrow
            if (!LinkExists(firstClickedTablet, clickedTablet))
            {
                CreateArrow(firstClickedTablet, clickedTablet);
                createdLinks.Add((firstClickedTablet, clickedTablet)); // Add the link to the list
                HighlightTablet(firstClickedTablet, Color.white);
                selectedTablets.Add(clickedTablet); // Add the second clicked tablet to the selected list
                usernodes.Add(firstClickedTablet);
                if (usernodes.Count == node.Length - 1)
                {
                    usernodes.Add(clickedTablet);
                }
            }
            firstClickedTablet = null;
        }
    }

    bool LinkExists(GameObject fromTablet, GameObject toTablet)
    {
        // Check if a link already exists in either direction
        return createdLinks.Contains((fromTablet, toTablet)) || createdLinks.Contains((toTablet, fromTablet));
    }

    void HighlightTablet(GameObject tablet, Color color)
    {
        Renderer renderer = tablet.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    void CreateArrow(GameObject fromTablet, GameObject toTablet)
    {
        GameObject arrow = Instantiate(arrowPrefab); // Instantiate arrow prefab
        arrow.transform.position = (fromTablet.transform.position + toTablet.transform.position) / 2f; // Position arrow between two tablets
        arrow.transform.LookAt(toTablet.transform.position); // Make arrow point towards the 'toTablet'
        Vector3 scale = arrow.transform.localScale;
        scale.z = Vector3.Distance(fromTablet.transform.position, toTablet.transform.position); // Scale arrow to fit between two tablets
        arrow.transform.localScale = scale;
        arrow.tag = "Arrow"; // Ensure the arrow has the "Arrow" tag
    }

    void ClearUserButtons()
    {
        usernodes.Clear();
        selectedTablets.Clear(); // Clear the selectedTablets list as well
        removearrows();
        // Reset the color of the tablets if necessary
        foreach (GameObject tablet in tablets)
        {
            HighlightTablet(tablet, Color.white);
        }
        createdLinks.Clear(); // Clear the created links list
    }

    void removearrows()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
    }

    void SetnodeOrder()
    {
        if (gamelevel == 2)
        {
            node = lvl2node;
        }
        else if (gamelevel == 3)
        {
            node = lvl3node;
        }
    }

    IEnumerator levelfinished(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scenename);
        if (gamelevel > 3)
        {
            addprogress();
        }//first clear
    }
    void addprogress()
    {
        progression.progression += 25;
    }

}
