﻿using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GUITexture Fader;
	public string Destination;
	private bool canChangeScene = false;
	private bool isWorking = false;
	public bool DoorClick = false;
	private bool keepWalking = false;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		isWorking = false;
		if (Input.GetMouseButtonDown (0)) {
			canChangeScene = true;
			DoorClick = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player" && canChangeScene) {
			StartCoroutine (ChangeScene ());
			col.GetComponent<Player_Mov>().enabled = false;
			col.transform.position = Vector2.MoveTowards (col.transform.position, transform.position, Time.deltaTime * 3);
			DoorClick = false;
			keepWalking = true;
		} else if(keepWalking){
			col.GetComponent<Player_Mov>().enabled = false;
			col.transform.position = Vector2.MoveTowards (col.transform.position, transform.position, Time.deltaTime * 3);
		}
	}

	IEnumerator ChangeScene(){
		yield return new WaitForSeconds(.23f);
		Instantiate (Fader);
		yield return new WaitForSeconds(.5f);
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		PlayerPrefs.SetFloat(Application.loadedLevelName + "x", gameObject.transform.position.x);
		PlayerPrefs.SetFloat(Application.loadedLevelName + "y", gameObject.transform.position.y);
		Application.LoadLevel(Destination);
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && isWorking) {
			canChangeScene = false;
		}	
	}

	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		isWorking = true;
	}
}
