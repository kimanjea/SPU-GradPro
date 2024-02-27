using System.Collections;
using UnityEngine;

public class colorchange_button : MonoBehaviour
{
    public bool isPressed;
    public GameObject self;

    Renderer ren;
    public Color desiredColor;
    public Color currentColor;

    public traversal_check userbuttons;
    public traversal_check wrongorder;
    public traversal_check correctorder;

    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        // Change color if the button is pressed and the color is not already the desired color
        if (isPressed && ren.material.color != desiredColor)
        {
            ren.material.color = desiredColor;
        }

        // Check for correct and wrong orders
        CheckCorrectOrder();
        CheckWrongOrder();

        currentColor = ren.material.color;
    }

    void OnMouseDown()
    {
        // Check if the button is not already pressed before processing
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("Button pressed");
            AddButtons(self);
        }
        else
        {
            Debug.Log("Already pressed");
        }
    }

    void AddButtons(GameObject buttons)
    {
        // Add the button to the user buttons list
        if (userbuttons != null)
        {
            userbuttons.Addtouserbuttons(buttons);
            Debug.Log("Button added to user buttons");
        }
    }

    void CheckCorrectOrder()
    {
        // Check for correct order and initiate color change if needed
        if (correctorder != null && correctorder.correctorder)
        {
            isPressed = false;
            StartCoroutine(CorrectColorAndWait(3f));
        }
    }

    IEnumerator CorrectColorAndWait(float waitTime)
    {
        // Change color to green, wait, and then reset to white
        ren.material.color = Color.green;
        yield return new WaitForSeconds(waitTime);
        ren.material.color = Color.white;
        correctorder.correctorder = false; // Reset correct order flag
    }

    void CheckWrongOrder()
    {
        // Check for wrong order and initiate color change if needed
        if (wrongorder != null && wrongorder.wrongorder)
        {
            isPressed = false;
            StartCoroutine(WrongColorAndWait(3f));
        }
    }

    IEnumerator WrongColorAndWait(float waitTime)
    {
        // Change color to red, wait, and then reset to white
        ren.material.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        ren.material.color = Color.white;
        wrongorder.wrongorder = false; // Reset wrong order flag
    }
}
