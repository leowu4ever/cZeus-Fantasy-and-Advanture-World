using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public GameObject PlayButtonMusic;
	public GameObject SettingButtonMusic;
	public GameObject TutorialButtonMusic;
	public GameObject BackButtonMusic;
	public GameObject BgMusic;


	public void stop()
	{
		BgMusic = GameObject.Find("BgMusic");
		if(BgMusic.GetComponent<AudioSource>().isPlaying)
		    BgMusic.GetComponent<AudioSource>().Stop();
		else
			BgMusic.GetComponent<AudioSource>().Play();

	}

	public void SettingButtonPressed(){
		
		SettingButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(SettingButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}
	public void TutorialButtonPressed(){
		
		TutorialButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(TutorialButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}
	public void BackButtonPressed(){
		
		BackButtonMusic.GetComponent<AudioSource> ().Play ();
		Debug.Log(TutorialButtonMusic.GetComponent<AudioSource> ().isPlaying);
	}

}
