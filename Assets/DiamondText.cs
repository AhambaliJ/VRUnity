namespace GoogleVR.GVRDemo {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class DiamondText : MonoBehaviour {

		public Animator anim;
		private bool displaying;
		public GameObject canvas;

		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
		}
		
		// Update is called once per frame
		void Update () {
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			displaying = anim.GetBool("display");

			if(displaying && !anim.IsInTransition(0)){
				canvas.SetActive(true);
			}else{
				canvas.SetActive(false);
			}
		}

		public void Display() {
			anim.SetBool("display",true);
		}

		public void Fold() {
			anim.SetBool("display",false);
		}

	}
}