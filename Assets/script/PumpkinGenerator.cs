using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices.ComTypes;

public class PumpkinGenerator : MonoBehaviour {

	public float leftLimit, rightLimit, frontLimit, backLimit;
	public float frequency;
	public GameObject pumpkinPrefab;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (Random.Range(0.5f, frequency));

		Vector3 position = new Vector3();
		position.x = Random.Range (leftLimit, rightLimit);
		position.y = transform.position.y;
		position.z = Random.Range (frontLimit, backLimit);

		Instantiate (pumpkinPrefab, position, transform.rotation);

		StartCoroutine (Start ());

	}

}
