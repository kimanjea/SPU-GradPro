using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ColorChangeScript : MonoBehaviour
{
    public bool isPressed;
    public GameObject button;
    public Color desiredColor = Color.green;
    public Color wrongColor = Color.red; 

    Renderer ren;
    Renderer buttonren;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonren = button.GetComponent<Renderer>();

        Material buttonmaterial = buttonren.material;
        Color buttonColor = buttonmaterial.color;
        Debug.Log("Current Material Color: " + buttonColor);    


        if (isPressed)
        {
            if (buttonColor == desiredColor)
            {
                ren.material.color = Color.green;
                Debug.Log("Current Material Color: " + buttonColor);
            }else{
                ren.material.color = Color.red;
                buttonmaterial.color = wrongColor;
            }

            // Reset isPressed to avoid continuous color changes
            isPressed = false;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
    }
}
