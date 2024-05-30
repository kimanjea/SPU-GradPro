using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPageManager : MonoBehaviour
{
    [SerializeField] private TMP_Text quiz1Text;
    [SerializeField] private TMP_Text quiz2Text;
    [SerializeField] private TMP_Text finalText;
    [SerializeField] private TMP_Text yearText;

    // Start is called before the first frame update
    void Start()
    {
        if (Progress.quiz1Pass) {
            quiz1Text.text = "Passed";
        }
        else {
            quiz1Text.text = "Not Passed";
        }
        if (Progress.quiz2Pass) {
            quiz2Text.text = "Passed";
        }
        else {
            quiz2Text.text = "Not Passed";
        }
        if (Progress.quiz3Pass) {
            finalText.text = "Passed";
        }
        else {
            finalText.text = "Not Passed";
        }

        if (Progress.level < 2) {
            yearText.text = "Freshman";
        }
        else {
            yearText.text = "Sophomore";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
