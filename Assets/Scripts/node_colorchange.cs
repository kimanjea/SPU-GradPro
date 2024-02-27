using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node_colorchange : MonoBehaviour
{
    Renderer ren;
    public colorchange_button isPressed;
    public GameObject self;
    public colorchange_button desiredColor;


    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        check_button();
        
    }

    void check_button()
    {
        if (isPressed.isPressed == true)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = desiredColor.desiredColor;
        }
    }
}
