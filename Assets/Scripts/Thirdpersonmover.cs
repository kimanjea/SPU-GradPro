using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirdpersonmover : MonoBehaviour
{
   //Needed stuffs
    CharacterController Controller;
    public Transform cam;
    float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    //Movemnt
    Vector2 movement;
    public float walkspeed;
    public float sprintSpeed;
    float truespeed;

    //Jumping

    public float jumpheight;
    public float gravity;
    bool isground;
    Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        truespeed = walkspeed;
        Controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(transform.position, .1f, 1);

        if(isground && Velocity.y < 0)
        {
            Velocity.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            truespeed = sprintSpeed;
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            truespeed = walkspeed;
        }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

           Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Controller.Move(moveDirection.normalized * truespeed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isground)
        {
            Velocity.y = Mathf.Sqrt((jumpheight * 10) * -2f * gravity);
        }

        Velocity.y += (gravity * 10) * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }
}
