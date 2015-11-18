using UnityEngine;
using System.Collections;

public class InputNumberHandler : MonoBehaviour {

    public GameObject numberPrefab;

    public void SendInputNumber (string buttonLabel)
    {
       
        if (GameManager.isInputing)
        {

            if (BoardPressedHandler.currentPressedContent.tag == "Mystery Number Content")
            {
                // assign new content to mystery number 
                BoardPressedHandler.currentPressedContent.GetComponent<ContentScript>().content = buttonLabel;
                GameObject contentSprite = Instantiate(numberPrefab, BoardPressedHandler.currentPressedContent.transform.position, Quaternion.identity) as GameObject;
                contentSprite.GetComponent<NumberSpriteScript>().SetSpriteTo(int.Parse(BoardPressedHandler.currentPressedContent.GetComponent<ContentScript>().content));

            }
        }

    }
}   
