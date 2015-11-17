using UnityEngine;
using System.Collections;

public class InputNumberHandler : MonoBehaviour {
    public void SendInputNumber (string buttonLabel)
    {
        if (GameManager.isInputing)
        {

            if (BoardPressedHandler.currentPressedContent.tag == "Mystery Number Content")
            {
                BoardPressedHandler.currentPressedContent.GetComponent<ContentScript>().content = buttonLabel;
            }
        }

    }
}   
