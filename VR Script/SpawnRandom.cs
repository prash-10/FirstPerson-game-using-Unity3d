using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour {

	public GameObject spawnObj;
	private GameObject target;

	private float minX=-30;
	private float maxX=30;
	private float minY=1;
	private float maxY=10;
	private float minZ=-30;
	private float maxZ=30;

	private bool is3D = true;

	void SpawnObject()
	{
		float x = Random.Range (minX, maxX);
		float y = Random.Range (minY, maxY);
		float z = Random.Range (minZ, maxZ);
		if (is3D) {
			target = Instantiate (spawnObj, new Vector3 (x, y, z), Quaternion.identity);
			target.AddComponent (typeof(Hit));
			Destroy (target, 20);
		}

	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Begin ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Begin()
	{
		SpawnObject ();
		yield return new WaitForSeconds(1);
		StartCoroutine (Begin ());
	}

}
