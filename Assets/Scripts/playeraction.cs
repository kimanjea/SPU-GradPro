using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraction : MonoBehaviour
{
    public Animator playerAnim;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 10f; 
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed; //this will help move our player object to move forward and sideways {Takes in our horizontal input)
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, verticalInput);

        if (Input.GetKeyDown(KeyCode.E)) // this will help with moving forward animation whenever we press forward
        {
            playerAnim.SetTrigger("emote"); // we set the trigger to look for our running transition to match what is in our Unity Animator object
            //playerAnim.ResetTrigger("idle"); //we reset the idle trigger to match  that we are transitions
          
        }

        if (Input.GetKeyDown(KeyCode.W)) // this will help with moving forward animation whenever we press forward
        {
            playerAnim.SetTrigger("walk"); // we set the trigger to look for our running transition to match what is in our Unity Animator object
            //playerAnim.ResetTrigger("idle"); //we reset the idle trigger to match  that we are transitions
          
        }

        if (Input.GetKeyDown(KeyCode.S)) // this will help with moving forward animation whenever we press forward
        {
            playerAnim.SetTrigger("walkback"); // we set the trigger to look for our running transition to match what is in our Unity Animator object
            //playerAnim.ResetTrigger("idle"); //we reset the idle trigger to match  that we are transitions
          
        }


    }
}
