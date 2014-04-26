using UnityEngine;
using System.Collections;
using SimpleJSON;

public struct ScoreoidScoreEntry
{
	public ScoreoidPlayer player;
	public ScoreoidScore score;

	public ScoreoidScoreEntry(JSONNode p , JSONNode s)
	{
		player =  new ScoreoidPlayer(p);
		score  =  new ScoreoidScore(s); 
	}
}