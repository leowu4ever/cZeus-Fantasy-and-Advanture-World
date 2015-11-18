using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour {

    public GameObject InputNumberBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.isInputing)
        {
            ActivateInputNumberBar();
        }
        else
        {
            DeactivateInputNumberBar();
        }
    }


   void ActivateInputNumberBar ()
   {
        InputNumberBar.SetActive(true);
   }
   void DeactivateInputNumberBar ()
   {
        InputNumberBar.SetActive(false);
   }
}
