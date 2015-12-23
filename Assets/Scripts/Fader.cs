﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1; // fade in = 1 or out = -1

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade (int direction) {
		fadeDir = direction;
		return fadeSpeed;
	}

	void OnLevelWasLoaded () {
		BeginFade (-1);
	}
}
