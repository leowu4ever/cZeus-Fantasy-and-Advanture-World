using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolbarHandler : MonoBehaviour {

    public GameObject errorLabel;
    public GameObject timerLabel;
    void Update()
    {
        errorLabel.GetComponent<Text>().text = GameManager.errorCount.ToString();
        timerLabel.GetComponent<Text>().text = GameManager.remainingTime.ToString();
    }
}
