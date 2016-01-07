using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public GameObject PlayButtonMusic;
	public GameObject SettingButtonMusic;
	public GameObject TutorialButtonMusic;
	public GameObject BackButtonMusic;
	public GameObject BgMusic;
	public GameObject PlayButton;
	public GameObject SoundOff;


	public void stop()
	{
		BgMusic = GameObject.Find("Bg Music");
		SoundOff = GameObject.Find("Sound Off Button");
		if (BgMusic.GetComponent<AudioSource> ().isPlaying)
			BgMusic.GetComponent<AudioSource> ().Stop ();
		else 
			BgMusic.GetComponent<AudioSource> ().Play ();
	
		 
	}

	public void SoundEffect()
	{
		BgMusic = GameObject.Find("Bg Music");
		if(BgMusic.GetComponent<AudioSource> ().isPlaying)
		    this.GetComponent<AudioSource> ().Play ();

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
