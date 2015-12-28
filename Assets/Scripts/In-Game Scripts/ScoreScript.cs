using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text> ().text = ScoreCalculator.GetScoreFor (GameManager.errorCount, int.Parse(GameManager.puzzleLv)).ToString();
	}
}
