using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class ScoreoidResponse
{
	JSONNode m_jsonNode;

	public ScoreoidResponse(string responseData)
	{
		LoadData(responseData);
	}
	

	//This class can be used to convert to required info
	public ScoreoidScoreEntry[] ParseScores()
	{
		ScoreoidScoreEntry[] entries = new ScoreoidScoreEntry[m_jsonNode.Count];
		
		int i = 0;
		foreach(JSONNode eachNode in m_jsonNode.AsArray)
		{
			entries[i] = new ScoreoidScoreEntry(eachNode["Player"],eachNode["Score"]);
			i++;
		}
		
		return entries;
	}

	void LoadData(string responseData)
	{
		m_jsonNode = JSONNode.Parse(responseData);
	}
}
