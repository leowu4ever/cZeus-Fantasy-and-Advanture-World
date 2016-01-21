using UnityEngine;
using System.Collections;

public class MainSceneElementController : MonoBehaviour {
    
    public GameObject title;
    public GameObject playButton;
    private Vector3 titleStartV3 = new Vector3 (0.0f, 12.0f, 0.0f);
    private Vector3 titleEndV3 = new Vector3 (0.0f, 4.0f, 0.0f);
    	
    void Start () {
        title.transform.position = titleStartV3;
        LeanTween.move (title, titleEndV3, 1.0f).setEase (LeanTweenType.easeOutExpo).setDelay (1.0f);
        
        playButton.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
        LeanTween.scale (playButton, new Vector3 (1.0f, 1.0f, 1.0f), 1f).setDelay (2.0f).setEase (LeanTweenType.easeOutElastic);
    }
    
    void Update () {
        if (Random.Range (1, 250) > 247 && !LeanTween.isTweening (title)){
            Debug.Log ("do");
            LeanTween.scale (playButton, new Vector3 (1.15f, 1.15f, 1.15f), 0.2f);
            LeanTween.scale (playButton, new Vector3 (1f, 1f, 1f), 0.2f).setDelay (0.2f);
            LeanTween.scale (playButton, new Vector3 (1.15f, 1.15f, 1.15f), 0.2f).setDelay (0.4f);;
            LeanTween.scale (playButton, new Vector3 (1f, 1f, 1f), 0.2f).setDelay (0.6f);
        }
    }
}
