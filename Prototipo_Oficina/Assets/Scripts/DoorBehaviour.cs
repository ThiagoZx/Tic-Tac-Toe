using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GUITexture Fader;
	public string Destination;
	private bool canChangeScene = false;
	private bool isWorking = false;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		isWorking = false;
		if (Input.GetMouseButtonDown (0))
			canChangeScene = true;
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && canChangeScene)
			StartCoroutine(ChangeScene());
	}

	IEnumerator ChangeScene(){
		yield return new WaitForSeconds(.23f);
		Instantiate (Fader);
		yield return new WaitForSeconds(.5f);
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		Application.LoadLevel(Destination);
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && isWorking)
			canChangeScene = false;
	}
	
	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		isWorking = true;
	}
}
