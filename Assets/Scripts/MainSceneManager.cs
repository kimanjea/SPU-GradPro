using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject lvl0Objects;
    [SerializeField] private GameObject lvl1Objects;

    // Start is called before the first frame update
    void Start()
    {        
        if (Progress.level == 0) {
            lvl0Objects.SetActive(true);
        }
        if (Progress.level == 1) {
            lvl1Objects.SetActive(true);
        }

        if (Progress.level < 2) {
            scoreText.text = "Freshman";
        }
        else {
            scoreText.text = "Sophomore";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
