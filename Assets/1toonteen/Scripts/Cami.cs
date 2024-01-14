using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Norotation : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;

    }
    void update()
    {
        yaw += speedH + Input.GetAxis("Mouse X");
        pitch -= speedV + Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;

    }
}
