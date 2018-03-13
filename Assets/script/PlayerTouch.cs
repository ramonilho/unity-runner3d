using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour {

	public GameObject character;
	public float speed;

	Vector3 newPosition;
	Animation ani;

	void Start()
	{
		newPosition = transform.position;
		ani = character.GetComponent <Animation>();

		// Sets initial animation
		ani.CrossFade ("idle");
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Item") {
			Destroy (c.gameObject);
		}
	}

	void Update()
	{
		if (Input.GetButton ("Fire1")) {
			// Transforms touch on screen in a 3D coord
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				Vector3 lockedPos = new Vector3 (hit.point.x, -0.93f, hit.point.z);

				newPosition = lockedPos;
			}
			transform.position = Vector3.MoveTowards (transform.position, newPosition, speed * Time.deltaTime);
			transform.LookAt (hit.point);

			ani.CrossFade ("run");
		} else {
			ani.CrossFade ("idle");
		}

	}

}
