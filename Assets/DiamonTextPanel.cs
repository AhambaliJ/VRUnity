using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DiamonTextPanel : MonoBehaviour {


	private Text uiText;
	private GameObject next;
	private GameObject previous;
	private static int uiTextIndex;
	public List<string> contentText;

	void Start() {
		uiText = this.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
		
		next = this.gameObject.transform.Find("Next").gameObject;
		
		previous = this.gameObject.transform.Find("Previous").gameObject;
		
		if(contentText.Count > 0){
		
			uiTextIndex = 0;
			uiText.text = contentText[0];
		
		}else{
		
			uiText.text = "Please set your text";
		}
	}

	void Update() {

		if(uiText.text == contentText[contentText.Count - 1]){
		
			next.SetActive(false);
		}else{
		
			next.SetActive(true);
		}
		
		if(uiText.text == contentText[0]){
		
			previous.SetActive(false);
		}else{
		
			previous.SetActive(true);
		}
	}

	public void nextText() {
		
		uiTextIndex++;
		uiText.text = contentText[uiTextIndex];
	}

	public void previousText() {
		
		uiTextIndex--;
		uiText.text = contentText[uiTextIndex];
	}

}
