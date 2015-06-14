using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GameObject player;
	public GUITexture Fader;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonDown (0)) {
			//Application.LoadLevel(gameObject.name);
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene(){
		Instantiate (Fader);
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(gameObject.name);
	}
	
	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
