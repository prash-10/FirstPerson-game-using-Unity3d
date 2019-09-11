using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunc : MonoBehaviour {

	public Transform mover;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - mover.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround (mover.position, mover.transform.up, 100 * Time.deltaTime);
		transform.position = mover.transform.position + offset;
	}
}
