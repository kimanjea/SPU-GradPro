using UnityEngine;

public class Progress : MonoBehaviour
{
    public int progression = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(progression);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            progression += 25;
        }
    }




}
