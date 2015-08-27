using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

	public Texture2D cursor;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonDown (0)) {
			//Implementar ele virar filho de algum filho do inventario que tenha a tag "EmptySlot", e ter as mesmas posiçoes do mesmo. Isso fara ele ir ao inventario ok ok? Xou.
			print("Ahooy");
		}
	}

}
