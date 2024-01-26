using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange_button : MonoBehaviour
{

    public bool isPressed;
   Renderer ren;
    public Color desiredColor = Color.green;


    // Update is called once per frame
    void Update()
    {

        if (isPressed)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = desiredColor;
        }
        
    }

    void OnMouseDown()
    {
       isPressed = true;
    }
}
