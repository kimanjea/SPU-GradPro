using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you have TextMeshPro imported

public class Linked_list : MonoBehaviour
{
    public GameObject tabletPrefab;
    public List<GameObject> tablets = new List<GameObject>();
    public GameObject firstClickedTablet;

    private int[] values = { 5, 3, 8, 1, 6 }; // Example values for the tablets

    void Start()
    {
        if (tabletPrefab == null)
        {
            Debug.LogError("Tablet Prefab is not assigned in the Inspector.");
            return;
        }

        CreateTablets();
    }

    void CreateTablets()
    {
        for (int i = 0; i < values.Length; i++)
        {
            GameObject tablet = Instantiate(tabletPrefab, new Vector3(i * 3, 0, 0), Quaternion.identity);
            if (tablet == null)
            {
                Debug.LogError("Failed to instantiate tablet prefab.");
                continue;
            }

            TextMeshPro textMesh = tablet.GetComponentInChildren<TextMeshPro>();
            if (textMesh == null)
            {
                Debug.LogError("TextMeshPro component not found in tablet prefab.");
            }
            else
            {
                textMesh.text = values[i].ToString();
            }

            tablets.Add(tablet);
        }
    }

    public void OnTabletClicked(GameObject clickedTablet)
    {
        if (firstClickedTablet == null)
        {
            firstClickedTablet = clickedTablet;
            HighlightTablet(clickedTablet, Color.green);
        }
        else
        {
            CreateArrow(firstClickedTablet, clickedTablet);
            HighlightTablet(firstClickedTablet, Color.white);
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
        GameObject arrow = new GameObject("Arrow");
        LineRenderer lr = arrow.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, fromTablet.transform.position);
        lr.SetPosition(1, toTablet.transform.position);
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default")) { color = Color.red };
    }
}
