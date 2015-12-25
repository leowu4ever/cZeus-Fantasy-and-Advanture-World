using UnityEngine;
using System.Collections;

public class LevelMapManager : MonoBehaviour {
    
    public GameObject[] levels;
    
	void Start () {

	   InitLevels();
	}
	
	void Update () {
	   if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
				if (hit.collider != null) {
                       GameObject levelNode = hit.transform.gameObject;
                       Debug.Log (levelNode.name);
                }
       }
	}
    
    void InitLevels ()  {
        SetLevelLockerStateTo (levels[0].name, false);  // the fisrt chapter is always open
        for (int a = 0; a < levels.Length; a++) {
          levels[a].GetComponent<LevelScript> ().isLocked = GetLevelLockerState (levels[a].name);
        }
    }
    
    bool GetLevelLockerState (string levelName) {
        if (PlayerPrefs.GetInt (levelName) == 0) {
            return true;
        } else {
            return false;
        } 
    }
    
    // true - 0 - locked 
    // false - 1 - unlocked
    void SetLevelLockerStateTo (string levelName, bool lockerState) {
        if (lockerState) {
            PlayerPrefs.SetInt (levelName, 0);
        } else {
            PlayerPrefs.SetInt (levelName, 1);
        }
    }
}
