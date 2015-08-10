using UnityEngine;
using System.Collections;

public class InteractionBehaviour : MonoBehaviour {
	
	public Texture2D cursor;
	
	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonUp (0)) {
			print("Ahooy");
		}
	}

	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

}
