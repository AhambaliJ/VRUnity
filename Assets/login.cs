using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {

	private GameObject usernameInput;
	private GameObject passwordInput;

	private string username;
	private string password;

	// Use this for initialization
	void Start () {

		usernameInput = this.gameObject.transform.Find("Username Input").gameObject;
		passwordInput = this.gameObject.transform.Find("Password Input").gameObject;

		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void getUsername() {
		username = usernameInput.GetComponent<InputField>().text;
	
	}

	public void getPassword() {
		password = passwordInput.GetComponent<InputField>().text;
		
	}

	public void LoginButton() {

		if(username == "izzati"){
			if(password == "zack"){
				SceneManager.LoadScene("VR");
			}
		}

	}

}
