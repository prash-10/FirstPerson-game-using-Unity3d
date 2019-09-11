using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_Death : NetworkBehaviour {

	private Health healthScript;
	//private Image crossHairImage;


	public void Start ()
	{
		healthScript = GetComponent<Health>();
	//	healthScript.EventDie += DisablePlayer;
	}



	public void OnDisable ()
	{
	//	healthScript.EventDie -= DisablePlayer;
	}

	/*public void DisablePlayer ()
	{
		//	GetComponent<contoller>.enabled = false;
		//	GetComponent<Player_Shoot>().enabled = false;
		NetworkView.RPC ("RemoteInvisible", RPCMode.All);
	

//		Network.Destroy (gameObject);
		//gameObject.SetActive(false);
		//Application.LoadLevel ("hud");

		/*if(isLocalPlayer)
		{
	//		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		//	crossHairImage.enabled = false;
		//	GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton.SetActive(true);
			//cam.enabled=true;
			//gunm1.enabled=true;
			//gunm2.enabled=true;
			//canvas.enabled = true;
			//a=GetComponent<Animator> ();
			//a.enabled = true;;
			//	na=GetComponent<NetworkAnimator> ();
			//	na.enabled = tru
			//	na.animator=a;
			GetComponent<contoller> ().enabled = false;
			GetComponent<rotate> ().enabled = false;
			//GetComponent<Health> ().enabled = false;
			GetComponent<rotates> ().enabled = false;
			GetComponent<rotates2> ().enabled = false;
			//aim.enabled = true;
			//hs.enabled = true;
		}
		if (isLocalPlayer) {
			cam.enabled=true;
			gunm1.enabled=true;
			gunm2.enabled=true;
			canvas.enabled = true;
		}
	}



*/
}