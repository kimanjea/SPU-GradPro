// PlayerController.cs
using UnityEngine;

namespace MyProject.Characters {
public class PlayerController : MonoBehaviour {

  public float moveSpeed = 10f;

  public void Move(Vector3 direction) {
    // Move the player in the specified direction
    transform.position += direction * moveSpeed * Time.deltaTime; 
  }

}
}