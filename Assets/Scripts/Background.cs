using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    
    public GameObject olimp;
    public GameObject cloudLeft;
    public GameObject cloudRight;
    
    private bool movingClouds;
  
    private Vector3 olimpStartV3 = new Vector3 (-1.0f, -11.0f, 0f);
    private Vector3 olimpEndV3 = new Vector3 (-1.0f, -1.0f, 0f);
    private Vector3 cloudLeftStartV3 = new Vector3 (-8.5f, 5.5f, 0f);
    private Vector3 cloudLeftEndV3 = new Vector3 (-4.3f, 5.5f, 0f);
    private Vector3 cloudRightStartV3 = new Vector3 (9.0f, 4.4f, 0f);
    private Vector3 cloudRightEndV3 = new Vector3 (3.65f, 4.4f, 0f);
    
    
	// Use this for initialization
	void Start () {
	   olimp.transform.position = olimpStartV3;
       cloudLeft.transform.position = cloudLeftStartV3;
       cloudRight.transform.position = cloudRightStartV3;
       LeanTween.move (olimp, olimpEndV3, 3.0f).setEase (LeanTweenType.easeInOutExpo);  
	}
    
    void Update () {
      if (!LeanTween.isTweening (olimp)) {
          if (cloudLeft.transform.position == cloudLeftStartV3) {
              LeanTween.move (cloudLeft, cloudLeftEndV3, 1.2f);
          }
          if (cloudLeft.transform.position == cloudLeftEndV3) {
              LeanTween.move (cloudLeft, cloudLeftStartV3, 1.5f);
          }
          
          if (cloudRight.transform.position == cloudRightStartV3) {
              LeanTween.move (cloudRight, cloudRightEndV3, 1.3f);
          }
          if (cloudRight.transform.position == cloudRightEndV3) {
              LeanTween.move (cloudRight, cloudRightStartV3, 1.4f);
          }
      } 
    }
}
