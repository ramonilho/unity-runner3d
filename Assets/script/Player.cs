using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Speed
	public float speed;

	// Directions
	float directionX;
	float initialPositionX, finalPositionX;

	// Positions
	public Transform[] positions;
	int currentPosition = 1;

	void Update () {
		// Fire1 - Left Ctrl || Mouse1 || Touch
		if (Input.GetButtonDown ("Fire1")) {

			// Position of first touch
			initialPositionX = Input.mousePosition.x;

		} else if (Input.GetButtonUp ("Fire1")) {
			// Last touch position
			finalPositionX = Input.mousePosition.x;

			// Defines direction
			directionX = finalPositionX - initialPositionX;

			if (directionX > 0 && currentPosition < 2) {
				currentPosition++;
			} else if (directionX < 0 && currentPosition > 0) {
				currentPosition--;
			}
		}

		// Repositioning player
		transform.position = Vector3.Lerp (transform.position, positions[currentPosition].position, speed * Time.deltaTime);

		print (currentPosition);
	}
}
