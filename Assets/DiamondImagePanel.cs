using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class DiamondImagePanel : MonoBehaviour {

	private GameObject next;
	private GameObject previous;

	private static int uiImageIndex;
	private Image uiImage;

	public List<Sprite> contentImage;
	public Sprite NoSprite;

	// Use this for initialization
	void Start () {

		uiImage = this.gameObject.transform.Find("Image").gameObject.GetComponent<Image>();

		next = this.gameObject.transform.Find("Next").gameObject;
		
		previous = this.gameObject.transform.Find("Previous").gameObject;
		
		if(contentImage.Count > 0){
		
			uiImageIndex = 0;
			
			uiImage.overrideSprite = contentImage[0];
		}
		else{
		
			uiImage.sprite = NoSprite;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(uiImageIndex == contentImage.Count - 1){
			
			next.SetActive(false);
		}else{
			
			next.SetActive(true);
		}
			
		if(uiImageIndex == 0){
		
			previous.SetActive(false);
		}else{
			
			previous.SetActive(true);
		}

	}

	public void nextImage() {
		
		uiImageIndex++;
		uiImage.overrideSprite = contentImage[uiImageIndex];
	}

	public void previousImage() {
		
		uiImageIndex--;
		uiImage.overrideSprite = contentImage[uiImageIndex];
	}

}
