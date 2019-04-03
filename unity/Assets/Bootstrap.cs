using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour {

	public GameObject timeline;

	// Use this for initialization
	IEnumerator Start () {
		Application.targetFrameRate = 24;
		timeline.SetActive(false);
		yield return null;
		yield return null;
		timeline.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
