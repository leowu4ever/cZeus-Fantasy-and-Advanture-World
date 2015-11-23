using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public GameObject PlayButtonMusic;
	public GameObject SettingButtonMusic;
	public GameObject TutorialButtonMusic;

	public void PlayButtonPressed(){

		PlayButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(PlayButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}
	public void SettingButtonPressed(){
		
		SettingButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(SettingButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}
	public void TutorialButtonPressed(){
		
		TutorialButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(TutorialButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}

}
