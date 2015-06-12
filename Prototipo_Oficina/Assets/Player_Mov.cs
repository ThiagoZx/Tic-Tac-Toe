using UnityEngine;
using System.Collections;

public class Player_Mov : MonoBehaviour {
		
	private Vector2 startPosition;
	private Vector2 finalPosition;
	private float speed;
	private bool isMoving;

	//transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
	// Use this for initialization
	void Start () {
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			if (Input.GetMouseButtonDown (0)) {
				startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
                finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				isMoving = true;
			}
		} else if (isMoving) {
            if (Input.GetMouseButtonDown(0)) {
                finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
			gameObject.transform.position = Vector2.MoveTowards (startPosition, finalPosition, Time.deltaTime * speed);
			startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			isMoving = startPosition == finalPosition? isMoving = false : isMoving = true;
		}

	}
}


//Camera camera = GetComponent<MainCamera>();
//Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));