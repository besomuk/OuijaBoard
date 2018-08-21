using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShotScript : MonoBehaviour 
{
	private bool isProcessing = false;
	public float startX;
	public float startY;
	public int valueX;
	public int valueY;

	void OnMouseDown ()
	{
		takeScreenShotAndShare();
	}

	void takeScreenShotAndShare()
	{
		StartCoroutine(takeScreenshotAndSave());
	}

	private IEnumerator takeScreenshotAndSave()
	{
		string path = "";
		yield return new WaitForEndOfFrame();

		Texture2D screenImage = new Texture2D(Screen.width, Screen.height);

		//Get Image from screen
		screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		screenImage.Apply();

		//Convert to png
		byte[] imageBytes = screenImage.EncodeToPNG();

		int rnd = Random.Range( 100, 999 );
		string file_name = "/ouija_" + rnd.ToString() + ".jpg";

		System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/OuijaScreenShot");
		path = Application.persistentDataPath + "/OuijaScreenShot" + file_name;
		System.IO.File.WriteAllBytes(path, imageBytes);

		StartCoroutine(shareScreenshot(path));
	}

	private IEnumerator shareScreenshot(string destination)
	{
		string ShareSubject = "Picture Share"; // naslov
		string shareLink = "Pogledaj ovde: " + "\nhttp://www.google.com"; // link
		string textToShare = "Text To share...\n";

		//Debug.Log(destination);


		if (!Application.isEditor)
		{

			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);

			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), textToShare + shareLink);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), ShareSubject);
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);
		}
		yield return null;
	}
}
