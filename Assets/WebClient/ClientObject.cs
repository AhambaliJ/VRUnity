using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class ClientObject : MonoBehaviour {

	string LoginUrl = "jsonplaceholder.typicode.com/posts/1";
    private WWW www;

	private delegate void TextDelegate(string text);
	
    // Use this for initialization
    void  Start () {
		StartCoroutine(Get());
	}
	
	IEnumerator Get(){

		// LoginUrl += "FromCurrency=MYR&ToCurrency=JPY";
		UnityWebRequest www = UnityWebRequest.Get(LoginUrl);
		yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
	}

	// Update is called once per frame
	void Update () {
	}


}