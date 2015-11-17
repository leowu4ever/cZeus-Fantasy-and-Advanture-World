using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{
	/*
	 * It shoots a laser and determine which board is selected
	 * 
	 * Can only one board gets selected each time 
	 * 
	 * Also need to store the reference of selected board
	 */

	void Update ()
	{ 	
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				Debug.Log (hit.transform.name + " : " + hit.transform.gameObject.GetComponent<ContentScript> ().content);
				Debug.Log (hit.transform.parent.name);
				if (!hit.transform.parent.gameObject.GetComponent<BoardScript> ().isPressed) {
					hit.transform.parent.gameObject.GetComponent<BoardScript> ().switchToPressedBoardBg ();
				} else {
					hit.transform.parent.gameObject.GetComponent<BoardScript> ().switchToNormalBoardBg ();
				}
			} 
		}
	}
}
