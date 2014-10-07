using UnityEngine;
using System.Collections;
using System.IO;

public class Test001_DataRet : MonoBehaviour {
	IEnumerator Start () {
		Debug.Log ("start function started");
		//datatest();

		string evedatatest = "http://api.eve-central.com/api/marketstat";
		
		WWWForm form = new WWWForm();
		
		form.AddField( "typeid", 34 );
		
		form.AddField( "usesystem", 30000142 );
		
		WWW download = new WWW( evedatatest, form );
		
		Debug.Log("Starting Download");
		yield return download;
		Debug.Log("download complete");
		if(!string.IsNullOrEmpty(download.error)) {
			//	print( "Error downloading: " + download.error );
			Debug.Log ("Error downloading" + download.error);
			return false;
		} else {
			// show the highscores
			Debug.Log(download.text);	
		}



		Debug.Log ("start function ended");

		using (StreamWriter sw = new StreamWriter("TestFile.txt")) 
		{

			sw.Write("Data from eveCentral is: ");
			sw.WriteLine(download.text);
		}

	}
//	IEnumerator datatest()
//	{
//		Debug.Log ("datatest function started");
//		string evedatatest = "http://api.eve-central.com/api/marketstat";
//
//		WWWForm form = new WWWForm();
//
//		form.AddField( "typeid", 34 );
//
//		form.AddField( "usesystem", 30000142 );
//
//		WWW download = new WWW( evedatatest, form );
//
//		Debug.Log("Starting Download");
//		yield return download;
//		Debug.Log("download complete");
//		Debug.Log(download.text);
//		if(!string.IsNullOrEmpty(download.error)) {
//		//	print( "Error downloading: " + download.error );
//			Debug.Log ("Error downloading" + download.error);
//			return false;
//		} else {
//			// show the highscores
//			Debug.Log(download.text);	
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//	
//	}

}
