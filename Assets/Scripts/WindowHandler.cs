using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour
{

	public GameObject inputNumberBar;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.isInputing) {
			ActivateInputNumberBar ();
		} else {
			DeactivateInputNumberBar ();
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
