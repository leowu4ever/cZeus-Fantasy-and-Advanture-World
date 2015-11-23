using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public GameObject PlayButtonMusic;

	public void PlayButtonPressed(){

		PlayButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(PlayButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}

}
