using UnityEngine;
using System.Collections;
using SimpleJSON;

public struct ScoreoidPlayer {
	
	public string userName;
	public ScoreoidPlayer(JSONNode p)
	{
		userName = p["username"].ToString();
	}
}
