using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private string itemHeld = null;
	private bool hldnItem = false;
	private bool carry = false;

	void Update(){
		if (Input.GetMouseButtonDown (0)) {

			Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.up, 0.0023f);

			if(hit.collider != null)
				switch (hit.transform.gameObject.tag) {
					
				case "Item":
					if(!hldnItem){
						hit.transform.gameObject.GetComponent<ItemBehaviour>().itemCheck();
						itemHeld = hit.transform.gameObject.GetComponent<ItemBehaviour>().itemName;
						hldnItem = true;
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = false;
					} else {
						GameObject.FindGameObjectWithTag("Item").GetComponent<ItemBehaviour>().itemCheck();
						carry = true;
					}
					
					break;

				case "Floor":
					if(GameObject.FindGameObjectWithTag("Item").GetComponent<ItemBehaviour>().followMouse == false){
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
					} else {
						GameObject.FindGameObjectWithTag("Item").GetComponent<ItemBehaviour>().itemCheck();
						hldnItem = false;
						carry = false;
					}

					break;

				case "Door":
					if(!hit.transform.gameObject.GetComponent<DoorBehaviour>().unlocked){
						if(hldnItem && (itemHeld == "Key") && carry){
							hit.transform.gameObject.GetComponent<DoorBehaviour>().unlocked = true;
							Destroy(GameObject.FindGameObjectWithTag("Item"));
							Destroy(GameObject.FindGameObjectWithTag("Lock"));
							carry = false;
						}
						//Criar funçao que muda a imagem da porta para aberta e faz um simpatico som dela abrindo.
					} else {
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
						hldnItem = false;
						carry = false;
					}
						
					break;
				}

		}
	}
}
