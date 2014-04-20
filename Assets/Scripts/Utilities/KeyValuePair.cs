using UnityEngine;
using System.Collections;

//Handles only strings
public struct KeyValuePair 
{
	public string key;
	public string value;

	//Constructor
	public KeyValuePair(string key,string value)
	{
		this.key 	= key;
		this.value 	= value;
	}
}
