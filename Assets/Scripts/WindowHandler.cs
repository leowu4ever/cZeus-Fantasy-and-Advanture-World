using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour
{

	public GameObject inputNumberBar;

	// Update is called once per frame
	void Update ()
	{
		if (GameManager.isInputing) {
			ActivateInputNumberBar ();
			Debug.Log ("isInputing");
		} else {
			DeactivateInputNumberBar ();
			Debug.Log (" not isInputing");

		}
	}

	void ActivateInputNumberBar ()
	{
		inputNumberBar.SetActive (true);

	}
	void DeactivateInputNumberBar ()
	{
		inputNumberBar.SetActive (false);
	}
}
