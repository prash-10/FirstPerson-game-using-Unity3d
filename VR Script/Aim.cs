using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour {

	public Text txt1;
	public Text txt2;

	float score;
		private LineRenderer l;
		// Use this for initialization
		void Start () {
			l=GetComponent<LineRenderer>();	
		score = 0;

		}

		// Update is called once per frame
		void Update () {
		
		}
		void FixedUpdate()
		{
		RaycastHit hit;
		/*txt1.text = "Score " + score;
		txt2.text = "Score " + score;*/
		if (Physics.Raycast(transform.position, transform.forward, out hit)){
			l.SetPosition(1,new Vector3 (0,0,hit.distance));
			if(GameObject.FindGameObjectWithTag("Game").GetComponent<grannyControls>().hitTarget){
				if (hit.collider.tag == "target") {
					//score += 1f;
					txt1.text = "HIT";
					txt2.text = "HIT";
					hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				} else {
					txt1.text = "MISS";
					txt2.text = "MISS";
				}
			}
			}
		}
}


