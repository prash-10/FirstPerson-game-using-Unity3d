using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Shoot :NetworkBehaviour  {
	int x=0;
	Vector3 v=new Vector3(-90,0,0);
	Quaternion q = new Quaternion (0,-90,90,0);

	[SerializeField] private AudioSource soundsource;
	[SerializeField] private GameObject explosion;
	private int damage_head=100,damage_chest=7,damage_hand=3,damage_leg=5,damage_foot=2,damage;
	private float range = 200;
	[SerializeField] private Transform gunTransform;
	private RaycastHit hit;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		CheckIfShooting ();

	}
	void CheckIfShooting()
	{
		if (!isLocalPlayer)
			return;

		//fire ();
	}

	public void fire(){
		if(Physics.Raycast(gunTransform.transform.TransformPoint(0f,0f,0.5f),gunTransform.forward,out hit,range))
		{
			Debug.Log (hit.collider.tag);
			//Debug.Log (hit.transform.root.name);
			if (hit.collider.tag == "head") {
				damage = damage_head;
			}else if (hit.collider.tag == "leg") {
				damage = damage_leg;
			}else if (hit.collider.tag == "hand") {
				damage = damage_hand;
			}else if (hit.collider.tag == "chest") {
				damage = damage_chest;
			}else if (hit.collider.tag == "foot") {
				damage = damage_foot;
			}

			if (hit.transform.tag == "Player") {
				string uidentity = hit.transform.root.name;
				CmdTellServerWhoWasShot (uidentity, damage);
			}

		}
		soundsource.Play ();
		//StartCoroutine (exp ());

	}
	/*IEnumerator exp()
	{GameObject g=
		Instantiate (explosion, dir.position, dir.rotation);
		 yield return new WaitForSeconds (0.2f);
		DestroyImmediate (g);
	}*/





	[Command]
	void CmdTellServerWhoWasShot (string id, int dmg)
	{
		GameObject go=GameObject.Find(id);
		go.GetComponent<Health> ().DeductHealth(dmg);
	}
}
