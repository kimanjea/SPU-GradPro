using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you have TextMeshPro imported

public class Linked_list : MonoBehaviour
{
    public List<GameObject> tablets = new List<GameObject>();
    public GameObject firstClickedTablet;
    public GameObject arrowPrefab; // Assign the arrow prefab in the Unity Editor

    public GameObject[] node; // Example values for the tablets
    private List<GameObject> selectedTablets = new List<GameObject>(); // List to keep track of selected tablets
    public List<GameObject> usernodes = new List<GameObject>();
    public int lifecount = 3;

    void Start()
    {

    }

    private void Update()
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

                        if (lifecount <= 0)
                        {
                            // Game over logic or reset level
                            Debug.Log("Game Over");
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
                ClearUserButtons(); // Clear user selections
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
            CreateArrow(firstClickedTablet, clickedTablet);
            HighlightTablet(firstClickedTablet, Color.white);
            selectedTablets.Add(clickedTablet); // Add the second clicked tablet to the selected list
            usernodes.Add(firstClickedTablet);
            if (usernodes.Count == node.Length - 1)
            {
                usernodes.Add(clickedTablet);
            }

            firstClickedTablet = null;
        }
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
    }

    void ClearUserButtons()
    {
        usernodes.Clear();
        removearrows();
    }

    void removearrows()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
    }
}
