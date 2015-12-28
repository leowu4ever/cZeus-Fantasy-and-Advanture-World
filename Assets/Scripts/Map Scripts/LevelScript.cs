using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
    public int levelId;
    public int levelSceneId;
    public bool isLocked;
    public int stars;
    public GameObject unlockedLevelNode;
    public GameObject lockedLevelNode;
    public string[] dialogs;
    
    public Transform[] ptsToNxtLv;
    
    void Start () {
        if (isLocked) {
            lockedLevelNode.SetActive (true);
        }
         else {
            unlockedLevelNode.SetActive (true);
         }
    }
}
