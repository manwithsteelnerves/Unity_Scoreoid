using UnityEngine;
using System.Collections;

public class ScoreoidResponse
{
	string m_data;
	ScoreoidPlayer	 m_playerData;
	ScoreoidScore 	 m_scoreData;

	public ScoreoidResponse(string responseData)
	{
		//Parse the json string here and deserialize into required classes [ScoreoidPlayer,ScoreoidScore]
	}
	
	public ScoreoidPlayer GetPlayer()
	{
		ScoreoidPlayer player;
		return player;
	}

}
