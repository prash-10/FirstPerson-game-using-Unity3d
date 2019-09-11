using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour {
	//	[SyncVar] private int heal=100;

	[SyncVar(hook="OnHealthChanged")] private int health=100;
	//public GameObject obj;
	  Animator anim;
	[SerializeField]private Text htext;
	//private bool shouldDie = false;
	//public bool isDead = false;
//	public delegate void DieDelegate ();
	//public NetworkView nnv;
	NetworkInstanceId viewID ;
//	public event DieDelegate EventDie;
//	Player_Death pd;
	// Use this for initialization
	void Start () {
		Debug.Log ("health running");
	//	nnv = GetComponent<NetworkView> ();
		//htext = GameObject.Find ("Text_t").GetComponent<Text>();
		SetHealthText ();
		viewID = GetComponent<NetworkIdentity> ().netId;;
		//htext.text = "Health "+health.ToString ();

		anim = GetComponent<Animator>();
		//pd=GetComponent<Player_Death>();
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (health);
//		CheckCondition ();
		if (health <= 0) {
			htext.text = "You Died";
			if (!isServer) {
				anim.SetFloat ("dead", 1f);
				StartCoroutine (nowcall ());
			} else 
			{
				anim.SetFloat ("dead", 1f);
			}
			}	

			/*	if (health <= 0) {
			Debug.Log ("ok.Health is zero");

			anim.SetFloat ("dead", 1f);
		}*/

		}
	IEnumerator nowcall()
	{
		yield return new WaitForSeconds(0.9f);
		ClientreqtoDisable (viewID);
		NetworkManager.singleton.StopHost ();
		Application.LoadLevel ("hud");
	}



	void CheckCondition(){
	
	//	if (health <= 0 && !shouldDie && !isDead) {
	//		shouldDie = true;
		
	//	}	
		if (health <= 0 ) {
			Debug.Log ("ok.Health is zero");
			ClientreqtoDisable (viewID);
				Application.LoadLevel ("hud");
		}	
	

}
	void SetHealthText()
	{
		if (isLocalPlayer) {
			htext.text = "Health" + health.ToString ();
		}
	}
	public void DeductHealth(int dmg)
	{
		health -= dmg;
	}
/*	void DisablePlayer(){
		GetComponent<contoller> ().enabled = false;
		nnv.RPC ("RemoteInvisible", RPCMode.All);
		if (isLocalPlayer) {
		
	
	
			GetComponent<rotate> ().enabled = false;
		}
	
	}
	public void invisible()
	{
		if(this.health<=0){
			Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		foreach (Renderer ren in renderers) {
			ren.enabled = false;
		}


		}
		//healthScript.isDead = true;

	}*/
	void OnHealthChanged(int h)
	{
		health = h;
		SetHealthText();
	}
	[Client]
	void ClientreqtoDisable (NetworkInstanceId viewID1)
	{
		

		CmdServerRecievesAndDestroys (viewID1);
			}

	[Command]
	void CmdServerRecievesAndDestroys (NetworkInstanceId P_ID)
{

		GameObject obj = NetworkServer.FindLocalObject (P_ID);
		NetworkServer.Destroy (obj);
}

}