using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager {
	
	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
	}
	
	public void JoinGame()
	{
		SetIPAddress();
		SetPort();
		NetworkManager.singleton.StartClient();
	}
	
	void SetIPAddress()
	{
		string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
		NetworkManager.singleton.networkAddress ="192.168.43.1";
	}
	
	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}
	void OnLevelWasLoaded (int level)
	{
		if(level == 2)
		{
			//SetupMenuSceneButtons();
			StartCoroutine(SetupMenuSceneButtons());
		}
		
		
	}
	
	IEnumerator SetupMenuSceneButtons()
	{
		yield return new WaitForSeconds(0.3f);
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);
		
		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
	}
	
	
}