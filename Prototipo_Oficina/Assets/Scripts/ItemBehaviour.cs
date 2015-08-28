using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GameObject Inventory;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonDown (0)) {
			//Lembrar de fazer isso modular ao interagir um objeto com outro. Pensei em usar um raycast para isso
			changePlace(gameObject);
		}
	}

	public void changePlace(GameObject item){
		GameObject empty = GameObject.FindGameObjectWithTag ("EmptySlot");
		item.transform.position = new Vector3 (empty.transform.position.x, empty.transform.position.y, item.transform.position.z);
		item.transform.parent = empty.transform;
	}

}
