using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarHandler : MonoBehaviour {

    public GameObject[] stars;
    public Sprite starOn;
    
    private int numOfHighlightedStar;
	// Use this for initialization
	void Start () {
     
        switch (GameManager.errorCount) 
        {
            case 0 : numOfHighlightedStar = 5;
            break;
            case 1 : numOfHighlightedStar = 5;
            break;
            case 2 : numOfHighlightedStar = 4;
            break;
            case 3 : numOfHighlightedStar = 3;
            break;
            case 4 : numOfHighlightedStar = 2;
            break;
            case 5 : numOfHighlightedStar = 1;
            break;
        }
	   for (int a = 0; a < numOfHighlightedStar; a++) {
           stars[a].GetComponent<Image>().sprite = starOn;
       }
	}
}
