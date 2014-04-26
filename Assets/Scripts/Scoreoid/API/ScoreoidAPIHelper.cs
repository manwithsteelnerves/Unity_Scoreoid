using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void ScoreoidDelegate (ScoreoidResponse response);

public class ScoreoidAPIHelper : MonoBehaviour
{
		static ScoreoidAPIHelper s_sharedInstance = null;

		public static ScoreoidAPIHelper GetSharedInstance()
		{
			if(s_sharedInstance == null)
			{
				GameObject go = new GameObject();
				go.name = "ScoreoidAPIHelper";
				ScoreoidAPIHelper helper = go.AddComponent<ScoreoidAPIHelper>();
				s_sharedInstance = helper;
			}
			return s_sharedInstance;
		}
//For score submission
		public void SubmitScore (string username,int score, ScoreoidDelegate callback = null)
		{
			SubmitScore (username,score.ToString(),callback);	
		}
	
		public void SubmitScore (string username,string score, ScoreoidDelegate callback = null)
		{
				SubmitScore (callback, new KeyValuePair (ScoreoidConstants.SCORE_KEY, score),new KeyValuePair(ScoreoidConstants.USER_NAME_KEY,username));	
		}
	
		public void SubmitScore (ScoreoidDelegate callback, params KeyValuePair[] fields)
		{
				StartRequest (ScoreoidConstants.CREATE_SCORE_URL, callback, fields);	
		}


//For getting the list of scores
		public void GetScores (ScoreoidDelegate callback, params KeyValuePair[] fields)
		{
				StartRequest (ScoreoidConstants.GET_SCORES_URL, callback, fields);
		}

//For every request start a new web request and assign the required callback
		void AddDefaultParameters (ref WWWForm form)
		{
				form.AddField (ScoreoidConstants.API_KEY, ScoreoidSettings.SCOREOID_API_KEY);
				form.AddField (ScoreoidConstants.GAME_ID_KEY, ScoreoidSettings.SCOREOID_GAME_ID);
				form.AddField (ScoreoidConstants.RESPONSE_KEY, ScoreoidSettings.RESPONSE);
		}

		void StartRequest (string url, ScoreoidDelegate callback, KeyValuePair[] fields)
		{
				WWWForm form = new WWWForm ();
				AddDefaultParameters (ref form);

				//If the same keys are there in the fields, it will override the default params
				foreach (KeyValuePair each in fields) {
						form.AddField (each.key, each.value);
				}
		
				Debug.Log ("Form data " + form.data.ToString());
		
				ScoreoidRequestHandler.StartScoreoidRequest (ScoreoidConstants.GET_SCORES_URL, form, callback);
		}
		
		void OnDestroy()
		{
			s_sharedInstance = null;
		}
}
