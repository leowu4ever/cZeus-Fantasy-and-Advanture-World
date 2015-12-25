using UnityEngine;
using System.Collections;

public class CloudMovingScript : MonoBehaviour {

    private Vector3 startPointV3;    
    public GameObject endPoint;
    public float speed;
    
    void Start() {
        startPointV3 = transform.position;
        
    }
	// Update is called once per frame
	void Update () {
	   if (transform.position == startPointV3) {
           LeanTween.move (gameObject, endPoint.transform.position, 1/speed);
       } 
       
       if (transform.position == endPoint.transform.position) {
           LeanTween.move (gameObject, startPointV3, 1/speed);
       }
	}
}
