using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grannyControls : MonoBehaviour {

	//public Animator anim;
	public GameObject cam;
	public AudioSource audioS1;
	public AudioSource audioS2;
	public AudioClip audioC1;
	public AudioClip audioC2;

	public bool hitTarget;

	private bool tr;

	private float speed = 5f;
	//private float rotationSpeed = 100f;

	void Start () {
		//anim = GetComponent<Animator> ();
		//anim.SetBool ("isWalking", false);
		tr = false;
		hitTarget = false;
	}
	

	void Update () {
		//print (cam.transform.rotation);
		if (Input.GetAxis ("Fire2") != 0) {
			Application.Quit ();
		}
		if (Input.GetAxis ("Fire1") != 0) {
			hitTarget = true;
			audioS1.clip = audioC1;
			audioS1.Play ();
		} else {
			hitTarget = false;
		}
		Aplay (tr);

		float t = Input.GetAxis("Horizontal") * speed;
		float translation = Input.GetAxis ("Vertical") * speed;
		transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);

		//float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		//float rotation = cam.GetComponent<GameObject>().transform.localRotation;
		t *= Time.deltaTime;
		translation *= Time.deltaTime;
		//rotation *= Time.deltaTime;
		transform.Translate (t, 0, translation);

		//transform.Rotate (0, rotation, 0);

		if (translation == 0) {
			tr = true;
			//anim.SetBool ("isWalking", true);
		} else {
			tr = false;
		}
	}
	void Aplay(bool t)
	{
		if (t) {
			audioS2.clip = audioC2;
			audioS2.Play ();
		}
	}
}
