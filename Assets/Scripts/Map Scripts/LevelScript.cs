using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
    public int levelId;
    public int levelSceneId;
    public bool isLocked;
    public int stars;
    public GameObject unlockedNode;
    public GameObject lockedNode;
    public string[] dialogs;
    
    void Start () {
        if (isLocked) {
            lockedNode.SetActive (true);
        }
         else {
            unlockedNode.SetActive (true);
         }
    }
}
