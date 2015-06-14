using UnityEngine;
using System.Collections;

public class Player_Mov : MonoBehaviour {
		
	private Vector2 startPosition;
	private Vector2 finalPosition;
	private float speed;
	private bool isMoving;
	
	// Use this for initialization
	void Start () {
		speed = 3;
	}

	void goToMouse(){
		if (Input.GetMouseButtonDown (0)) {
			if (!isMoving) {
				startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				isMoving = true;
			}

			finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
		} else if (isMoving) {
			gameObject.transform.position = Vector2.MoveTowards (startPosition, finalPosition, Time.deltaTime * speed);
			startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			isMoving = startPosition == finalPosition? isMoving = false : isMoving = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		goToMouse ();
	}
}