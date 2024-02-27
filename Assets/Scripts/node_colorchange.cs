using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node_colorchange : MonoBehaviour
{
    Renderer ren;
    // Reference to the colorchange_button script representing the current color state
    public colorchange_button currentColor;


    // Start is called before the first frame update
    void Start()
    {
        // Initialization code if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Check the current state of the button
        check_button();
     
    }

    // Update the color of the node based on the current state of the button
    void check_button()
    {
        ren = GetComponent<Renderer>();
        ren.material.color = currentColor.currentColor;
    }

}
