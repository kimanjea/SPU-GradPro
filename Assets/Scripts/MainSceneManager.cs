using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject lvl0Objects;
    [SerializeField] private GameObject lvl1Objects;
    [SerializeField] private GameObject lvl2Objects;
    [SerializeField] private GameObject lvl3Objects;
    [SerializeField] private GameObject lvl4Objects;

    // Start is called before the first frame update
    void Start()
    {      
        Debug.Log(Progress.level);
        Debug.Log(Progress.treeGameClear);
        Debug.Log(Progress.linkListGameClear);
        Debug.Log(Progress.quiz1Pass);
        Debug.Log(Progress.quiz2Pass);
        Debug.Log(Progress.quiz3Pass);

        if (Progress.level == 0) {
            lvl0Objects.SetActive(true);
        }
        if (Progress.level == 1) {
            lvl1Objects.SetActive(true);
        }
        if (Progress.level == 2) {
            lvl2Objects.SetActive(true);
        }
        if (Progress.level == 3) {
            lvl3Objects.SetActive(true);
        }
        if (Progress.level == 4) {
            lvl4Objects.SetActive(true);
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
