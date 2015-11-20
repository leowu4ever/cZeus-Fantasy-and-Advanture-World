using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputNumberBarHandler : MonoBehaviour
{
	public GameObject numberPrefab;
    public const string MYSTERY_NUMBER_CONTENT_TAG = "Mystery Number Content";
    public const string PAIR_CLUE_CONTENT_TAG = "Pair Clue Content";
    public const string SQUARE_CLUE_CONTENT_TAG = "Square Clue Content";

	public void SendInputNumber (string buttonLabel)
	{
		if (!GameManager.isGameover) {
			if (GameManager.isInputing) {
				GameObject currentPressedContent = BoardPressedHandler.currentPressedContent;
				ContentScript currentPressedContentScript = currentPressedContent.GetComponent<ContentScript> ();
                
                // Needs to check which type of content has been selected 
               
				if (currentPressedContent.tag == MYSTERY_NUMBER_CONTENT_TAG && !currentPressedContentScript.isAnswered) {
					if (buttonLabel == currentPressedContentScript.answer) {
                        UpdateACorrectAnswerTo(currentPressedContent, buttonLabel);
						CreateContentSpriteOn (currentPressedContent);
					} else {
						GameManager.IncreaseErrorCount ();
					}
				}

				if (currentPressedContent.tag == PAIR_CLUE_CONTENT_TAG) {

                    // Always remove the sprite for previous input, and ready for new input
					RemoveContentSpriiteOn (currentPressedContent);

                    // We dont want to the first digit of input is 0
                    if(!(currentPressedContentScript.content == "" && buttonLabel == "0"))
                    {   
                        // Only allow to display an input with two digits
					    if (currentPressedContentScript.content.Length < 2) {
						    currentPressedContentScript.content = currentPressedContentScript.content + buttonLabel;    // update content 
						    CreateContentSpriteOn (currentPressedContent);
					    } else {
                            // It removes the previous input when you try to input a new non-zero number
                            if(buttonLabel != "0")
                            {
                                currentPressedContentScript.content = buttonLabel;      
                                CreateContentSpriteOn(currentPressedContent);
                            }
					    }
                    }
                }

				if (currentPressedContent.tag == SQUARE_CLUE_CONTENT_TAG) {

					RemoveContentSpriiteOn (currentPressedContent);
                    if (!(currentPressedContentScript.content == "" && buttonLabel == "0"))
                    {
                        if (currentPressedContentScript.content.Length < 4)
                        {
                            currentPressedContentScript.content = currentPressedContentScript.content + buttonLabel;
                            CreateContentSpriteOn(currentPressedContent);
                        }
                        else
                        {
                            if (buttonLabel != "0")
                            {
                                currentPressedContentScript.content = buttonLabel;
                                CreateContentSpriteOn(currentPressedContent);
                            }
                        }
                    }      
				}

			}
		}
	}

	void CreateContentSpriteOn (GameObject targetContent)
	{
		ContentScript targetContentScript = targetContent.GetComponent<ContentScript> ();

		if (targetContentScript.content.Length == 1) {
			GameObject contentSprite = Instantiate (numberPrefab, targetContent.transform.position, Quaternion.identity) as GameObject;
			contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (targetContentScript.content));
			contentSprite.transform.parent = targetContent.transform;
		}
		if (targetContentScript.content.Length > 1) {
			for (int a = 0; a < targetContentScript.content.Length; a++) {
				GameObject contentSprite = Instantiate (numberPrefab, new Vector3 (targetContent.transform.position.x - 0.05f + a * (0.05f + 0.1f), targetContent.transform.position.y, targetContent.transform.position.z), Quaternion.identity) as GameObject;
				contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (targetContentScript.content.Substring (a, +1)));
				contentSprite.transform.parent = targetContent.transform;
				Debug.Log (targetContentScript.content.Substring (a, +1));
			}
		}
	}

	void RemoveContentSpriiteOn (GameObject parent)
	{
		int childCount = parent.transform.childCount;
		for (int i=0; i<childCount; i++) {
			GameObject.Destroy (parent.transform.GetChild (i).gameObject);
		}
	}

    void UpdateACorrectAnswerTo (GameObject correctContent, string answer) 
    {
        ContentScript correctContentScript = correctContent.GetComponent<ContentScript>();
        GameManager.IncreAnsweredCountByOne();
        correctContentScript.isAnswered = true;
        correctContentScript.content = answer;
    }
}   