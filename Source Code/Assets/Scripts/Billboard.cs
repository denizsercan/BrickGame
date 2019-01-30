using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	Camera theCam;
	// Use this for initialization
	void Start () {
		theCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (theCam == null)
			return;
		transform.LookAt (transform.position + theCam.transform.forward, theCam.transform.up);
	}
}
