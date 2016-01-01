using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolbarHandler : MonoBehaviour
{ 
	public GameObject errorLabel;
	public GameObject timerLabel;
    public GameObject hintLabel;
	void Update ()
	{
		errorLabel.GetComponent<Text> ().text = "Error: " + GameManager.errorCount.ToString () + "/" + GameManager.MAX_ERROR_NUMBER;
        hintLabel.GetComponent<Text> ().text = "Hint: " + GameManager.hintCount.ToString () + "/" + GameManager.MAX_HINT_NUMBER;
		timerLabel.GetComponent<Text> ().text = InGameTimer.countTime.ToString ();
        
	}
}
