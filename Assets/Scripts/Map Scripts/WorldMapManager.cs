using UnityEngine;
using System.Collections;

public class WorldMapManager : MonoBehaviour {
    
    public GameObject[] chapters;
    
	void Start () {
	   InitChapters();
	}
	
	void Update () {
	   if (Input.GetMouseButtonDown (0)) {
            RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
            if (hit.collider != null) {
                GameObject chapterNode = hit.transform.gameObject;
                ChapterScript chapterScript = chapterNode.GetComponent<ChapterScript> ();
                if (!chapterScript.isLocked) {
                    
                    // Show conversation window 
                    //conversationWindow.SetActive (true);
                    //Application.LoadLevel (chapterScript.chapterSceneId);
                }
            }
        }
	}
    
    void InitChapters ()  {
        SetChapterStateTo (chapters[0].name, false);  // the fisrt chapter is always open
        for (int a = 0; a < chapters.Length; a++) {
          chapters[a].GetComponent<ChapterScript> ().isLocked = GetChapterState (chapters[a].name);
        }
    }
    
    bool GetChapterState (string chapterName) {
        if (PlayerPrefs.GetInt (chapterName) == 0) {
            return true;
        } else {
            return false;
        } 
    }
    
    // true - 0 - locked 
    // false - 1 - unlocked
    void SetChapterStateTo (string chapterName, bool lockerState) {
        if (lockerState) {
            PlayerPrefs.SetInt (chapterName, 0);
        } else {
            PlayerPrefs.SetInt (chapterName, 1);
        }
    }
}
