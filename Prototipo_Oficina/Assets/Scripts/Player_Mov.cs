using UnityEngine;
using System.Collections;

public class Player_Mov : MonoBehaviour {
		
	private Vector2 startPosition;
	private Vector2 finalPosition;
	private float speed = 3;
	private bool isMoving;

	void Start(){
		if(PlayerPrefs.HasKey(Application.loadedLevelName + "x")){
			float positionX = PlayerPrefs.GetFloat (Application.loadedLevelName + "x");
			float positionY = PlayerPrefs.GetFloat (Application.loadedLevelName + "y");
			gameObject.transform.position = new Vector2(positionX, positionY);
		}
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

	void Update () {
		goToMouse ();
		SavePosition ();
	}

	void SavePosition(){
		PlayerPrefs.SetFloat(Application.loadedLevelName + "x", gameObject.transform.position.x);
		PlayerPrefs.SetFloat(Application.loadedLevelName + "y", gameObject.transform.position.y);
	}

	void OnApplicationQuit(){
		PlayerPrefs.DeleteAll ();
	}
}