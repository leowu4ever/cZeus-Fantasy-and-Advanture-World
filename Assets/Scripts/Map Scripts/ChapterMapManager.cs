using UnityEngine;
using System.Collections;

public class ChapterMapManager : MonoBehaviour {

    public GameObject[] levels;
    public GameObject camera;
    public GameObject hero;
    public GameObject levelWindow;
    
    public static bool isFocused;
    
    private int latestLevel;
    private int curLevel;
    
    
	void Start () {
	   InitLevels ();
       InitHero ();
	}
	
	void Update () {
	   if (Input.GetMouseButtonDown (0)) {
            RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
            if (hit.collider != null) {
                GameObject levelNode = hit.transform.gameObject;
                LevelScript levelScript = levelNode.GetComponent<LevelScript> ();
                if (!levelScript.isLocked) {
                    
                   hero.transform.position = levelNode.transform.position;    
                   camera.transform.position = new Vector3 (levelNode.transform.position.x, levelNode.transform.position.y, camera.transform.position.z);  
                 
                   levelWindow.transform.position = levelNode.transform.position;
                   levelWindow.SetActive (true);
                
                   isFocused = true;
                }
            }
        }
	}
    
    void InitHero () {
        hero.transform.position = levels[curLevel].transform.position;    
        camera.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, camera.transform.position.z);
    }
    
    void InitLevels ()  {
        SetLevelStateTo (levels[0].name, false);  // the fisrt level is always open
        for (int a = 0; a < levels.Length; a++) {
          levels[a].GetComponent<LevelScript> ().isLocked = GetLevelStateFor (levels[a].name);
          levels[a].GetComponent<LevelScript> ().levelId = a + 1;
        }
        curLevel = latestLevel;
    }
 
    bool GetLevelStateFor (string levelName) {
        if (PlayerPrefs.GetInt (levelName) == 0) {
            return true;
        } else {
            return false;
        } 
    }
    // true - 0 - locked 
    // false - 1 - unlocked
    void SetLevelStateTo (string levelName, bool lockerState) {
        if (lockerState) {
            PlayerPrefs.SetInt (levelName, 0);
        } else {
            PlayerPrefs.SetInt (levelName, 1);
        }
    }
}
