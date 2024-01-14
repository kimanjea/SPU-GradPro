using UnityEngine;
using UnityEngine.SceneManagement;

public class doorclose : MonoBehaviour
{
    public GameObject Door;
    public bool doorisclosing;
    
    void Update()
    {
        if (doorisclosing == true)
        {
            Door.transform.Translate(Vector3.down * Time.deltaTime * 5);
        }
        if (Door.transform.position.y < 5.9f)
        {
            doorisclosing = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorisclosing = true;
        }
    }

  

}
