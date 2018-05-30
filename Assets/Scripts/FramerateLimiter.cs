using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {
	public int targetFrameRate = 60;
	float dt = 0f;
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.targetFrameRate != targetFrameRate){
			Application.targetFrameRate = targetFrameRate;
		}
		dt += (Time.unscaledDeltaTime - dt);
	}


}
