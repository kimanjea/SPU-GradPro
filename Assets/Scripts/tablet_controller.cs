using UnityEngine;

public class TabletController : MonoBehaviour
{
    private Linked_list manager;
    private Renderer render;

    void Start()
    {
        manager = FindObjectOfType<Linked_list>();
        render = GetComponent<Renderer>();
        if (manager == null)
        {
            Debug.LogError("LinkedListManager not found in the scene!");
        }
    }

    void OnMouseDown()
    {
        if (manager != null)
        {
            manager.OnTabletClicked(this.gameObject);
            HighlightTablet();
        }
    }

    void HighlightTablet()
    {
        if (manager.firstClickedTablet == this.gameObject)
        {
            render.material.color = Color.green; // First selected tablet color
        }
        else
        {
            render.material.color = Color.white; // Reset color if unselected
        }
    }
}
