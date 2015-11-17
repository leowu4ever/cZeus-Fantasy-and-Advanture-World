using UnityEngine;
using System.Collections;

public class InputNumberHandler : MonoBehaviour {
    public void SendInputNumber (string buttonLabel)
    {
        if (GameManager.isInputing)
        {
            GameManager.inputString = GameManager.inputString + buttonLabel;
            Debug.Log(GameManager.inputString);
        }

    }
}   
