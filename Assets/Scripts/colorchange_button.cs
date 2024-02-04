using UnityEngine;

public class colorchange_button : MonoBehaviour
{

    public bool isPressed;
    public GameObject self;


    Renderer ren;
    public Color desiredColor;

    public traversal_check userbuttons;


    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = desiredColor;
            
        }

    }

    void OnMouseDown()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("hello");
            Addbuttons(self);
        }
        else
        {
            Debug.Log("already pressed");
        }

    }

    void Addbuttons(GameObject buttons)
    {
        if (userbuttons != null)
        {
            userbuttons.Addtouserbuttons(buttons);
            Debug.Log("YEAH WE ADDIN");
        }
    }

}
