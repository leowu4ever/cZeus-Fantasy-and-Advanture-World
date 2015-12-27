using UnityEngine;
using System.Collections;

public class ChapterScript : MonoBehaviour {
    public int chapterId;
    public int chapterSceneId;
    public bool isLocked;
    
    public GameObject unlockedChapterNode;
    public GameObject lockedChapterNode;
    
    void Start () {
        if (isLocked) {
            lockedChapterNode.SetActive (true);
        }   else {
            unlockedChapterNode.SetActive (true);
        }
    }
}