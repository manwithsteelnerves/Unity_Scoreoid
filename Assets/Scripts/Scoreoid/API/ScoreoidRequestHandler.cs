using UnityEngine;
using System.Collections;

public class ScoreoidRequestHandler : MonoBehaviour
{
	ScoreoidDelegate m_callback;
	string m_url;
	WWWForm m_formData;

//This is to start a request
	public static void StartScoreoidRequest(string url , WWWForm form , ScoreoidDelegate callback)
	{
		GameObject go = new GameObject();
		go.name = "ScoreoidRequestHandler" + url;
		ScoreoidRequestHandler handler = go.AddComponent<ScoreoidRequestHandler>() as ScoreoidRequestHandler;

		handler.m_url = url;
		handler.m_formData = form;
		handler.m_callback = callback;
		handler.StartRequest();
	}

	
	void StartRequest()
	{
		WWW www = new WWW(m_url, m_formData);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		Debug.Log("www...");
		/* Check for errors */
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			//Get the Scoreoid Response from text
			if(m_callback != null)
			{
				ScoreoidResponse response = new ScoreoidResponse(www.text);
				m_callback(response);
			}

		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	
}
