using UnityEngine;


public class dooractivate : MonoBehaviour
{
    public bool touch { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {

            touch = true;

        }
    }
}
