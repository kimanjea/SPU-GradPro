
using UnityEngine;

public class Doorcontroller : MonoBehaviour
{
    public GameObject spawndoor;
    public bool doorisOpening;
   
        // Update is called once per frame
    void Update()
    {

        if (doorisOpening == true)
        {
            spawndoor.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if (spawndoor.transform.position.y > 10f)
        {
            doorisOpening = false;
        }

    }

    void OnMouseDown()
    {
        doorisOpening = true;
    }

    
}
