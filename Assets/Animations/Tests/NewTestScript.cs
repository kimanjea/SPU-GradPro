using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Animations;

using MyProject; // Add using directive for the namespace

namespace MyProject {
    public class PlayerTest  : MonoBehaviour {

   public Animator playerAnim;

    public Rigidbody playerRigid;

    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;

    public bool walking;

    public Transform playerTrans;

    public void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {

            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
			
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;

        }

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {

            playerAnim.SetTrigger("walk");

            playerAnim.ResetTrigger("idle");

            walking = true;

            //steps1.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            playerAnim.ResetTrigger("walk");

            playerAnim.SetTrigger("idle");

            walking = false;

            //steps1.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            playerAnim.SetTrigger("walkback");

            playerAnim.ResetTrigger("idle");
			

            //steps1.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {

            playerAnim.ResetTrigger("walkback");

            playerAnim.SetTrigger("idle");

            //steps1.SetActive(false);

        }

        if (Input.GetKey(KeyCode.A))
        {

            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);

        }

        if (Input.GetKey(KeyCode.D))
        {

            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);

        }

        if (walking == true)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                //steps1.SetActive(false);

                //steps2.SetActive(true);

                w_speed = w_speed + rn_speed;

                playerAnim.SetTrigger("run");

                playerAnim.ResetTrigger("walk");

            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {

                //steps1.SetActive(true);

                //steps2.SetActive(false);

                w_speed = olw_speed;

                playerAnim.ResetTrigger("run");

                playerAnim.SetTrigger("walk");

            }

        }

    }
    }
}


public class NewTestScript
{
private PlayerTest test;
  private Animator animator;
  private Rigidbody rigidbody;
  

  [SetUp]
  public void SetUp() {
    // Create test object
    test = new GameObject("TestPlayer").AddComponent<PlayerTest>();

    // Add required components
    animator = test.gameObject.AddComponent<Animator>();
    rigidbody = test.gameObject.AddComponent<Rigidbody>();

    
    

    // Assign fields
    test.playerAnim = animator; 
    test.playerRigid = rigidbody;
  }

  [UnityTest]
  public IEnumerator WalkingEnablesWalkAnimation() {
    // Arrange
    test.walking = false;

    // Act
    test.Update();
    yield return null;

    // Assert
    Assert.IsTrue(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Walk"));
  }

  [UnityTest]
  public IEnumerator RunningIncreasesMoveSpeed() {
    
    // Arrange
    test.w_speed = 5f;
    test.olw_speed = 5f;
    test.rn_speed = 10f;

    // Act
    test.Update();
    yield return null;

    // Assert
    Assert.AreEqual(15f, test.w_speed);
  }
}

