using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPadCollider : MonoBehaviour {

	public UnityEvent ChairSwivel;
	public UnityEvent onWatakoyo;


	public void  OnTriggerStay(Collider col) {

		if(col.gameObject.CompareTag("Player")){
			if(GlobalVariable.chairSwivel == false) {
				if(ChairSwivel != null) {
					ChairSwivel.Invoke();
					GlobalVariable.chairSwivel = true;
				}
			}
		}

	}

	public void OnTriggerEnter() {
		
	}


}
