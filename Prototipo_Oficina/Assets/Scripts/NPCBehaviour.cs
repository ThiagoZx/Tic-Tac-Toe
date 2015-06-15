using UnityEngine;
using System.Collections;

public class NPCBehaviour : MonoBehaviour {

	public Texture2D cursor;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}
	
	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
