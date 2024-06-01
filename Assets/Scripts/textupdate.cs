using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TextUpdate : MonoBehaviour
{
    public TMP_Text uiText; 
    public Linked_list linkedList; 
    public bool isChoice = false;

    void Update()
    {
        if (linkedList != null && uiText != null)
        {
            uiText.text = isChoice ? UpdateChoiceNodeText() : UpdateNodeText();
        }
    }

    string UpdateNodeText()
    {
        GameObject[] currentNodes = linkedList.node;

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

    string UpdateChoiceNodeText()
    {
        List<GameObject> currentNodes = linkedList.usernodes;

        if (currentNodes != null && currentNodes.Count > 0)
        {
            string formattedText = "";
            for (int i = 0; i < currentNodes.Count; i++)
            {
                if (currentNodes[i] != null)
                {
                    formattedText += currentNodes[i].name;
                    if (i < currentNodes.Count - 1 && currentNodes[i + 1] != null)
                    {
                        formattedText += "->";
                    }
                    else
                    {
                        formattedText += " ";
                    }
                }
                else
                {
                    formattedText += " ";
                }
            }
            return formattedText;
        }
        return "No nodes selected";
    }

}
