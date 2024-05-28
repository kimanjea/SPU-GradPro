using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Collections.Generic;

public class TextUpdate : MonoBehaviour
{
    public TMP_Text uiText; // Reference to a UI Text component
    public Linked_list linkedlist;


    
    void Update()
    {
       if (linkedlist != null){
        
        uiText.text = updateNodeText();

        }
    }
    string updateNodeText()
    {
        GameObject[] currentNodes = linkedlist.node;

        if (currentNodes != null && currentNodes.Length > 0)
        {
            string formattedText = "";
            for (int i = 0; i < currentNodes.Length; i++)
            {
                formattedText += currentNodes[i].name;
                if (i < currentNodes.Length - 1)
                {
                    formattedText += "->";
                }
            }
            return formattedText;
        }
        return "No nodes available";
    }
}
