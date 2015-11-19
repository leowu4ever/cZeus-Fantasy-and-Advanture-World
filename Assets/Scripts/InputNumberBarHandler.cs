using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputNumberBarHandler : MonoBehaviour
{

	public GameObject numberPrefab;

	public void SendInputNumber (string buttonLabel)
	{

		if (GameManager.errorCount <= GameManager.MAX_ERROR_NUMBER) {
			if (GameManager.isInputing) {
				GameObject currentPressedContent = BoardPressedHandler.currentPressedContent;
				ContentScript currentPressedContentScript = currentPressedContent.GetComponent<ContentScript> ();
                
				if (currentPressedContent.tag == "Mystery Number Content" && !currentPressedContentScript.isAnswered) {
					if (buttonLabel == currentPressedContentScript.answer) {
						GameManager.answeredCount++;
						// assign new content to mystery number 
						currentPressedContentScript.isAnswered = true;
						currentPressedContentScript.content = buttonLabel;
						CreateContentSpriteOn (currentPressedContent);
					} else {
						GameManager.IncreaseErrorCount ();
					}
				}

				if (currentPressedContent.tag == "Pair Clue Content") {

					RemoveContentSpriiteOn (currentPressedContent);


					if (currentPressedContentScript.content.Length < 2) {
						currentPressedContentScript.content = currentPressedContentScript.content + buttonLabel;
						CreateContentSpriteOn (currentPressedContent);
					} else {
						currentPressedContentScript.content = buttonLabel;
						CreateContentSpriteOn (currentPressedContent);
					}
				}
				if (currentPressedContent.tag == "Square Clue Content") {

					RemoveContentSpriiteOn (currentPressedContent);

					if (currentPressedContentScript.content.Length < 4) {
						currentPressedContentScript.content = currentPressedContentScript.content + buttonLabel;
						CreateContentSpriteOn (currentPressedContent);
					} else {
						currentPressedContentScript.content = buttonLabel;
						CreateContentSpriteOn (currentPressedContent);
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

	void RemoveContentSpriiteOn (GameObject root)
	{
		int childCount = root.transform.childCount;
		for (int i=0; i<childCount; i++) {
			GameObject.Destroy (root.transform.GetChild (i).gameObject);
		}
	}
	
}   
