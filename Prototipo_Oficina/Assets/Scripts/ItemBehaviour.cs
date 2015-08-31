using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GameObject Inventory;
	private bool atInv = false;
	private bool followMouse = false;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}

	public void itemCheck(){
		if (!atInv) {
			toInv (gameObject);
			atInv = true;
		} else {
			followMouse = true;
		}
	}

	public void toInv(GameObject item){
		GameObject empty = GameObject.FindGameObjectWithTag ("EmptySlot");
		item.transform.position = new Vector3 (empty.transform.position.x, empty.transform.position.y, item.transform.position.z);
		item.transform.parent = empty.transform;
	}


	public void Update(){
		Vector2 finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (followMouse)
			gameObject.transform.position = new Vector2 (finalPosition.x, finalPosition.y);
	}
}
