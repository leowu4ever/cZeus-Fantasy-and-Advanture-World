using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.isGameover) {
            if (Input.GetMouseButtonDown (0)) {
                RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
                if (hit.collider != null) {
                    GameObject pressedBoard = hit.transform.parent.gameObject;
                    GameObject pressedContent = hit.transform.gameObject;
                    ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript> ();
                    if (pressedContentScript.content == pressedContentScript.answer) {
                        GameManager.IncreNumOfAnsweredByOne ();
                        Destroy (pressedBoard);
                    }
                }
            }
        }
	}
}
