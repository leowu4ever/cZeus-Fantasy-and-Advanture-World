using UnityEngine;
using System.Collections;

public class InputNumberBarHandler : MonoBehaviour {

    public GameObject numberPrefab;

    public void SendInputNumber(string buttonLabel)
    {

        if (GameManager.errorCount <= GameManager.maxError)
        {
            if (GameManager.isInputing)
            {
                GameObject currentPressedContent = BoardPressedHandler.currentPressedContent;
                ContentScript currentPressedContentScript = BoardPressedHandler.currentPressedContent.GetComponent<ContentScript>();
                
                if (currentPressedContent.tag == "Mystery Number Content" && !currentPressedContentScript.isAnswered)
                {
                    if (buttonLabel == currentPressedContentScript.answer)
                    {
                        // assign new content to mystery number 
                        currentPressedContentScript.isAnswered = true;
                        currentPressedContentScript.content = buttonLabel;
                        GameObject contentSprite = Instantiate(numberPrefab, currentPressedContent.transform.position, Quaternion.identity) as GameObject;
                        contentSprite.GetComponent<NumberSpriteScript>().SetSpriteTo(int.Parse(currentPressedContentScript.content));
                        contentSprite.transform.parent = currentPressedContent.transform;
                    }
                    else
                    {
                        GameManager.IncreaseErrorCount();
                    }
                }
            }
        }
    }
}   
