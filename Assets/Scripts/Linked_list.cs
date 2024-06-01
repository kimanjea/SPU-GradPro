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
    public TextUpdate text; // Reference to the TextUpdate script
    Progress progression;

    public GameObject[] node; // correct orders of the nodes for each level
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
        UpdateLevelText(); // Initialize the level text at the start
    }

    void Update()
    {
            // Ensure that both the usernodes list and the node array have elements
            if (usernodes.Count > 0 && usernodes.Count == node.Length)
            {

                bool correctOrder = true;
                for (int i = 0; i < node.Length; i++)
                {
                    if (usernodes[i].name != node[i].name)
                    {
                        Debug.Log("Wrong Order");
                        lifecount--;
                        if (lifecount == 0)
                        {
                            StartCoroutine(levelfinished(5f));
                            return; // Exit the method to prevent further execution
                        }
                        else
                        {
                            // Incorrect order but still has lives, continue to the next attempt
                            ClearUserButtons();
                            correctOrder = false;
                            break; // Exit the loop to avoid further checking
                        }
                    }
                }

                if (correctOrder)
                {
                    // If the loop completes without returning, it means the order is correct
                    Debug.Log("Correct Order");
                    gamelevel++;
                    UpdateLevelText(); // Update the level text when the game level changes
                    ClearUserButtons(); // Clear user selections
                    SetnodeOrder(); // Set the node order for the next level
                    if (gamelevel > 3)
                    {
                        StartCoroutine(levelfinished(5f));
                    }
                }
            }else if (usernodes.Count > node.Length){
                ClearUserButtons();
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

                    if (usernodes.Count == 0)
                    {
                        // Add both first and second tablets if the list is empty
                        usernodes.Add(firstClickedTablet);
                        usernodes.Add(clickedTablet);
                    }
                    else
                    {
                        // Check if the last added node is different from the first clicked tablet
                        if (usernodes[usernodes.Count - 1] != firstClickedTablet)
                        {
                            // Add a space marker (null) to denote a new linked list
                            usernodes.Add(null);
                            usernodes.Add(firstClickedTablet);
                        }
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
            GameObject arrow = new GameObject("Arrow");
            LineRenderer lr = arrow.AddComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, fromTablet.transform.position);
            lr.SetPosition(1, toTablet.transform.position);
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.material = new Material(Shader.Find("Sprites/Default")) { color = Color.red };
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
            }
        }

        void addprogress()
        {
            Progress.level += 1;
        }

        void UpdateLevelText()
        {
            if (text != null)
            {
                //text.UpdateText("Level: " + gamelevel);
            }
        }
    }
