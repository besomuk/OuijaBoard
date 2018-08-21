using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour 
{
	public bool prst;

	// Use this for initialization
	void Start () 
	{
		//prst = true;
	}

	public bool getPrstStatus ()
	{
		return prst;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnMouseOver ()
	{
		prst = true;
	}

	void OnMouseExit ()
	{
		prst = false;
	}
}
