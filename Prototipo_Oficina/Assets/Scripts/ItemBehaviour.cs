using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GameObject Inventory;
	private bool atInv = false;
	private bool followMouse = false;
	public string itemName;

	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseEnter(){
		if(atInv)
			GameObject.FindGameObjectWithTag ("Inventory").GetComponent<InventoryBehaviour>().onItem = true;
	}
	
	void OnMouseExit(){
		if(atInv)
			GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryBehaviour>().onItem = false;
	}

	public void itemCheck(){
		if (!atInv) {
			toInv (gameObject);
			atInv = true;
			followMouse = false;
			gameObject.collider2D.enabled = true;
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
		if (followMouse) {
			gameObject.transform.position = new Vector2 (finalPosition.x, finalPosition.y);
			gameObject.collider2D.enabled = false;
			atInv = false;
		}
	}
}
