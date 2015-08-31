using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private string itemHeld = null;

	void Update(){
		if (Input.GetMouseButtonDown (0)) {

			Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.up, 0.0023f);

			if(hit.collider != null)
				switch (hit.transform.gameObject.tag) {
					
				case "Item":
					hit.transform.gameObject.GetComponent<ItemBehaviour>().itemCheck();
					itemHeld = hit.transform.gameObject.GetComponent<ItemBehaviour>().itemName;
					GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = false;
					break;

				case "Floor":
					GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
					break;

				case "Door":
					if(!hit.transform.gameObject.GetComponent<DoorBehaviour>().DoorOpen){
						hit.transform.gameObject.GetComponent<DoorBehaviour>().DoorOpen = true;
						//Criar funçao que muda a imagem da porta para aberta e faz um simpatico som dela abrindo.
					} else {
						GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
					}
						
					break;
				}
		}
	}
}
