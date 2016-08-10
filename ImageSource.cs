using UnityEngine;
using System.Collections;

// Set the url on this object to cause it to render a texture from a given location as the object's texture
public class ImageSource : MonoBehaviour {

	// The url to access for the image
	public string url;

	private string lastUrl;

	IEnumerator Start() {
		lastUrl = url;
		return LoadTexture (url);
	}

	void Update() {
		// If url has been changed, load it
		if (url != lastUrl)
			LoadTexture (url);
	}
	// Load the texture specified by the current url value, or the url provided
	public IEnumerator LoadTexture (string newUrl) {

		// Set the new url if it's different
		if (url != newUrl)
			url = newUrl;

		lastUrl = url;

		if (url == null)
			yield break;

		// Create a www class to fetch the object
		WWW www = new WWW(url);

		// Defer processing until the www value is returned
		yield return www;

		// Define the renderer object by getting that component
		Renderer renderer = GetComponent<Renderer>();
		if (renderer != null) {
			renderer.material.mainTexture = www.texture;
		} else {
		//	Debug.Log ("No render on ImageSourcetarget: " + gameObject.name.ToString());
		}
	}
}
