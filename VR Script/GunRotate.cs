using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour {

	public GameObject cam;
	//public GameObject g;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x,cam.transform.rotation.eulerAngles.y , 0);
	}
}
