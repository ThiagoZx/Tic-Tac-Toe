using UnityEngine;
using System.Collections;

public class Player_Mov : MonoBehaviour {
	
	private Vector2 startPosition;
	private Vector2 finalPosition;
	private float speed = 3;
	private bool isMoving;
	private bool okMove;
	
	
	void Start(){
		gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
		if(PlayerPrefs.HasKey(Application.loadedLevelName + "x")){
			float positionX = PlayerPrefs.GetFloat (Application.loadedLevelName + "x");
			float positionY = PlayerPrefs.GetFloat (Application.loadedLevelName + "y");
			gameObject.transform.position = new Vector2(positionX, positionY);
		}
	}
	
	void playerMov(){
		if (Input.GetMouseButtonDown (0)) {
			if (!isMoving) {
				startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				isMoving = true;
			}

			finalPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y + renderer.bounds.size.y / 2);
			
		} else if (isMoving) {
			gameObject.transform.position = Vector2.MoveTowards (startPosition, finalPosition, Time.deltaTime * speed);
			startPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			isMoving = startPosition == finalPosition? isMoving = false : isMoving = true;
		}
	}
	
	void Update () {
		playerMov ();
		SavePosition ();
	}
	
	void OnDisable(){
		isMoving = false;
	}
	
	void SavePosition(){
		PlayerPrefs.SetFloat(Application.loadedLevelName + "x", gameObject.transform.position.x);
		PlayerPrefs.SetFloat(Application.loadedLevelName + "y", gameObject.transform.position.y);
	}
	
	void OnApplicationQuit(){
		PlayerPrefs.DeleteAll ();
	}
}