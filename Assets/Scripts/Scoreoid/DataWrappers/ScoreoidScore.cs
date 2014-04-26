using UnityEngine;
using System.Collections;
using SimpleJSON;

public struct ScoreoidScore
{
	//Have the attributes here
	public int score;
	public ScoreoidScore(JSONNode s)
	{
		score =  s["score"].AsInt;
	}
	
}
