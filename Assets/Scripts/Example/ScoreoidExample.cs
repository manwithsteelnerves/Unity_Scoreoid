using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreoidExample : MonoBehaviour
{

		// Use this for initialization
		ScoreoidAPIHelper m_scoreoidAPIHelper;
		bool m_scoresReceived;
		ScoreoidScoreEntry[] m_scoreEntries;

		string m_currentScore = "10";
		void Start ()
		{
				m_scoreoidAPIHelper = ScoreoidAPIHelper.GetSharedInstance ();
		}
	
		void OnEnable ()
		{
				m_scoresReceived = false;
		}

		void OnGUI ()
		{
				GUILayout.BeginArea (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.5f));
				if (GUILayout.Button ("Get Scores")) {
						m_scoreoidAPIHelper.GetScores (OnScoresReceived);
				}	
		
				GUILayout.BeginScrollView (Vector3.zero);
				if(m_scoreEntries != null)
				foreach(ScoreoidScoreEntry each in m_scoreEntries) 
				{
						GUILayout.BeginHorizontal ();
						GUILayout.Box (each.player.userName,GUILayout.MaxWidth(Screen.width * 0.25f));
						GUILayout.Box (""+each.score.score,GUILayout.MaxWidth(Screen.width * 0.25f));		
						GUILayout.EndHorizontal ();
				}
				GUILayout.EndScrollView ();

				GUILayout.BeginHorizontal ();
				m_currentScore = GUILayout.TextField(m_currentScore);
				if(GUILayout.Button("Submit Score"))
				{
					m_scoreoidAPIHelper.SubmitScore("TEST111",m_currentScore,OnSubmitScore);
				}

				GUILayout.EndArea ();
		}

		void OnScoresReceived (ScoreoidResponse response)
		{
			m_scoreEntries = response.ParseScores();
			
			foreach(ScoreoidScoreEntry each in m_scoreEntries)
			{
				Debug.Log(each.player.userName + " " + each.score.score);
			}
		}

		void OnSubmitScore(ScoreoidResponse response)
		{
			m_scoreoidAPIHelper.GetScores (OnScoresReceived);
		}
	
}
