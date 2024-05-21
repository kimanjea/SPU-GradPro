using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    public GameObject textObj;

    [SerializeField] private NPCConversation myConvo;

    void OnTriggerStay(Collider other) {
        // Check that the Player is inside the trigger
        if (other.CompareTag("Player")) {
            // Activate Guiding Text
            textObj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T)) {
                ConversationManager.Instance.StartConversation(myConvo);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            textObj.SetActive(false);
        }
    }
}
