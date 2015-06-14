using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GameObject player;
	public GUITexture Fader;
	public string Destination;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene(){
		Instantiate (Fader);
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(Destination);
	}
	
	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
