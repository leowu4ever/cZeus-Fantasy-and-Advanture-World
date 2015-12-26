﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputNumberBarHandler : MonoBehaviour
{
	public GameObject numberPrefab;

	public const string MYSTERY_NUMBER_CONTENT_TAG = "Mystery Number Content";
	public const string PAIR_CLUE_CONTENT_TAG = "Pair Clue Content";
	public const string SQUARE_CLUE_CONTENT_TAG = "Square Clue Content";

	public void SendInputNumberWith (string buttonLabel)
	{
		if (!GameManager.isGameover && GameManager.isInputing) {  
				GameObject curPressedContent = BoardPressedHandler.curPressedContent;
				ContentScript curPressedContentScript = curPressedContent.GetComponent<ContentScript> ();

				if (curPressedContent.tag == MYSTERY_NUMBER_CONTENT_TAG && !curPressedContentScript.isAnswered) {
					if (buttonLabel == curPressedContentScript.answer) {   // CORRECT INPUT !!!
						UpdateMysteryAnswerOn (curPressedContent);
						CreateContentSpriteOn (curPressedContent);
                        
					} else {    // WRONG INPUT !!!
						GameManager.IncreaseErrorCount ();   
					}
				}

				if (curPressedContent.tag == PAIR_CLUE_CONTENT_TAG) {
					TryInputNumberOn (curPressedContent, buttonLabel, 2);
				}

				if (curPressedContent.tag == SQUARE_CLUE_CONTENT_TAG) {
					TryInputNumberOn (curPressedContent, buttonLabel, 4);
                }
		}
	}

	void UpdateMysteryAnswerOn (GameObject content)
	{
		GameManager.IncreNumOfAnsweredByOne ();
        ContentScript contentScript = content.GetComponent<ContentScript> ();
		contentScript.isAnswered = true;
		contentScript.content = contentScript.answer;
	}
    
	void TryInputNumberOn (GameObject content, string newInput, int maxInputLength)
	{
		// Always remove the sprite for previous input, and ready for new input
		RemoveContentSpriteOn (content);
		ContentScript contentScript = content.GetComponent<ContentScript> ();

		// We dont want to the first digit of input is 0
		if (contentScript.content != "" || newInput != "0") {   
			// Only allow to display an input with two digits
			if (contentScript.content.Length < maxInputLength) {
				contentScript.content += newInput;    // update content 
				CreateContentSpriteOn (content);
			} else {
				// It removes the previous input when you try to input a new non-zero number
				if (newInput != "0") {
					contentScript.content = newInput;      
					CreateContentSpriteOn (content);
				}
			}
		}
	}

	void CreateContentSpriteOn (GameObject content)
	{
		ContentScript contentScript = content.GetComponent<ContentScript> ();
		if (contentScript.content.Length == 1) {
			GameObject contentSprite = Instantiate (numberPrefab, content.transform.position, Quaternion.identity) as GameObject;
			contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentScript.content));
			contentSprite.transform.parent = content.transform;
            DoInputAnimation (contentSprite);
            
            
		}
		if (contentScript.content.Length > 1) {
			for (int a = 0; a < contentScript.content.Length; a++) {
				GameObject contentSprite = Instantiate (numberPrefab, new Vector3 (content.transform.position.x - ContentScript.xShift + a * (ContentScript.xShift + ContentScript.xDisplacement), content.transform.position.y, content.transform.position.z), Quaternion.identity) as GameObject;
				contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentScript.content.Substring (a, +1)));
				contentSprite.transform.parent = content.transform;
                DoInputAnimation (contentSprite);
            
			}
		}
	}

	void RemoveContentSpriteOn (GameObject parent)
	{
		int childCount = parent.transform.childCount;
		for (int i=0; i < childCount; i++) {
			GameObject.Destroy (parent.transform.GetChild (i).gameObject);
		}
	}
    
    void DoInputAnimation (GameObject contentSprite) {
         float scale = 1/1.8f;
            contentSprite.transform.localScale = new Vector3 (0,0,0);
            LeanTween.scale (contentSprite, new Vector3 (scale, scale, scale), 1f).setEase(LeanTweenType.easeOutBounce);
    }
}   