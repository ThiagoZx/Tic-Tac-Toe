using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private string itemHeld = null;
	private bool hldnItem = false;

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
					}
					
					break;

				case "Floor":
					
					if(!hldnItem){
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
					} else {
						GameObject.FindGameObjectWithTag("Item").GetComponent<ItemBehaviour>().itemCheck();
						hldnItem = false;
					}

					break;

				case "Door":
					if(!hit.transform.gameObject.GetComponent<DoorBehaviour>().unlocked){
						if(hldnItem && (itemHeld == "Key")){
							hit.transform.gameObject.GetComponent<DoorBehaviour>().unlocked = true;
							Destroy(GameObject.FindGameObjectWithTag("Item"));
							Destroy(GameObject.FindGameObjectWithTag("Lock"));
						}
						//Criar funçao que muda a imagem da porta para aberta e faz um simpatico som dela abrindo.
					} else {
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
						hldnItem = false;
					}
						
					break;
				}
		}
	}
}
