using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Image))]
public class DiamondTextImagePanel : MonoBehaviour {

	private GameObject next;
	private GameObject previous;
	private GameObject text;
	private GameObject image;

	private Text uiText;
	private Image uiImage;

	private static int uiImageIndex;
	private static int uiTextIndex;
	private static int textOrImageIndex;
	private static bool isTextFirst;
	private static bool isImageFirst;
	

	public List<bool> textOrImage;
	public List<string> contentText;
	public List<Sprite> contentImage;
	
	// Use this for initialization
	void Start () {
		text = this.gameObject.transform.Find("Text").gameObject;
		uiText = this.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();

		image = this.gameObject.transform.Find("Image").gameObject;
		uiImage = this.gameObject.transform.Find("Image").gameObject.GetComponent<Image>();
		
		next = this.gameObject.transform.Find("Next").gameObject;
		
		previous = this.gameObject.transform.Find("Previous").gameObject;

		textOrImageIndex = 0;
		uiImageIndex = 0;
		uiTextIndex = 0;
		isTextFirst = true;
		isImageFirst = true;

		if(textOrImage.Count != 0 ) {
			if(textOrImage[0] == true){
				if(contentText.Count != 0){
					
					text.SetActive(true);
					uiText.text = contentText[uiTextIndex];
					isTextFirst = false;
				}else{

					text.SetActive(true);
					uiText.text = "Please set a text to this panel";
				}
			}else{
				if(contentImage.Count != 0){
					
					image.SetActive(true);
					uiImage.overrideSprite = contentImage[uiImageIndex];
					isImageFirst = false;
				}else{

					text.SetActive(true);
					uiText.text = "Please set an image to this panel";
				}
			}
		}else {

			text.SetActive(true);
			uiText.text = "Please set an image or a text to this panel";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(textOrImageIndex == textOrImage.Count - 1){
			
			next.SetActive(false);
		}else{
			
			next.SetActive(true);
		}
			
		if(textOrImageIndex == 0){
		
			previous.SetActive(false);
		}else{
			
			previous.SetActive(true);
		}
	}

	public void nextItem() {
		
		textOrImageIndex++;

		if(textOrImage[textOrImageIndex] == true){

			if(isTextFirst == true){
				isTextFirst = false;
			}else{
				uiTextIndex++;
			}
			uiText.text = contentText[uiTextIndex];					
			text.SetActive(true);
			image.SetActive(false);
		}else{

			if(isImageFirst == true){
				isImageFirst = false;
			}else{
				uiImageIndex++;
			}
			uiImage.overrideSprite = contentImage[uiImageIndex];
			image.SetActive(true);
			text.SetActive(false);
		}
	}

	public void previousItem() {
		
		textOrImageIndex--;
		
		if(textOrImage[textOrImageIndex] == true){

			if(uiTextIndex != 0){
				uiTextIndex--;
			}
			if(uiTextIndex == 0){
				isTextFirst = true;
			}
			uiText.text = contentText[uiTextIndex];					
			text.SetActive(true);
			image.SetActive(false);
		}else{

			if(uiImageIndex != 0){
				uiImageIndex--;
			}
			if(uiImageIndex == 0){
				isImageFirst = true;
			}
			uiImage.overrideSprite = contentImage[uiImageIndex];
			image.SetActive(true);
			text.SetActive(false);
		}
	}

}
