using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager gm;

	void Start () 
	{
		if (gm == null)
			gm = this.GetComponent<GameManager>();
	}

	/* metoda za odredjivanje polozaja slova */
	public Vector2 GetLetterPosition(string ul)
	{
		Vector2 v = new Vector2();

		switch (ul)
		{
		case "a": v.x = -6.17f; v.y = 1; break;
		case "а": v.x = -6.17f; v.y = 1; break;
		case "b": v.x = -5.37f; v.y = 1.14f; break;
		case "б": v.x = -5.37f; v.y = 1.14f; break;
		case "c": v.x = -4.48f; v.y = 1.16f; break;			
		case "ц": v.x = -4.48f; v.y = 1.16f; break;			
		case "d": v.x = -2.27f; v.y = 1.44f; break;
		case "д": v.x = -2.27f; v.y = 1.44f; break;
		case "e": v.x = 1f; v.y = 1.5f; break;
		case "е": v.x = 1f; v.y = 1.5f; break;
		case "f": v.x = 1.73f; v.y = 1.44f; break;
		case "ф": v.x = 1.73f; v.y = 1.44f; break;
		case "g": v.x = 2.54f; v.y = 1.36f; break;
		case "г": v.x = 2.54f; v.y = 1.36f; break;
		case "h": v.x = 3.37f; v.y = 1.3f; break;
		case "х": v.x = 3.37f; v.y = 1.3f; break;
		case "i": v.x = 4.16f; v.y = 1.21f; break;
		case "и": v.x = 4.16f; v.y = 1.21f; break;
		case "j": v.x = 4.73f; v.y = 1.1f; break;
		case "ј": v.x = 4.73f; v.y = 1.1f; break;
		case "k": v.x = 5.48f; v.y = 1.01f; break;
		case "к": v.x = 5.48f; v.y = 1.01f; break;
		case "l": v.x = -6.57f; v.y = -0.99f; break;
		case "л": v.x = -6.57f; v.y = -0.99f; break;
		case "m": v.x = -4.72f; v.y = -0.71f; break;
		case "м": v.x = -4.72f; v.y = -0.71f; break;
		case "n": v.x = -3.65f; v.y = -0.58f; break;
		case "н": v.x = -3.65f; v.y = -0.58f; break;
		case "o": v.x = -1.41f; v.y = -0.42f; break;
		case "о": v.x = -1.41f; v.y = -0.42f; break;
		case "p": v.x = -0.54f; v.y = -0.42f; break;
		case "п": v.x = -0.54f; v.y = -0.42f; break;
		case "r": v.x = 0.31f; v.y = -0.41f; break;
		case "р": v.x = 0.31f; v.y = -0.41f; break;
		case "s": v.x = 1.08f; v.y = -0.47f; break;
		case "с": v.x = 1.08f; v.y = -0.47f; break;
		case "t": v.x = 2.46f; v.y = -0.62f; break;
		case "т": v.x = 2.46f; v.y = -0.62f; break;
		case "u": v.x = 3.31f; v.y = -0.73f; break;
		case "у": v.x = 3.31f; v.y = -0.73f; break;
		case "v": v.x = 4.25f; v.y = -0.82f; break;
		case "в": v.x = 4.25f; v.y = -0.82f; break;
		case "z": v.x = 5.06f; v.y = -1.03f; break;
		case "з": v.x = 5.06f; v.y = -1.03f; break;
		case "č": v.x = -3.71f; v.y = 1.48f; break;
		case "ч": v.x = -3.71f; v.y = 1.48f; break;
		case "ć": v.x = -2.94f; v.y = 1.54f; break;
		case "ћ": v.x = -2.94f; v.y = 1.54f; break;
		case "đ": v.x = 0.08f; v.y = 1.54f; break;
		case "ђ": v.x = 0.08f; v.y = 1.54f; break;
		case "š": v.x = 1.74f; v.y = -0.42f; break;
		case "ш": v.x = 1.74f; v.y = -0.42f; break;
		case "ž": v.x = 5.93f; v.y = -0.91f; break;
		case "ж": v.x = 5.93f; v.y = -0.91f; break;		
		case "љ": v.x = -5.69f; v.y = -0.91f; break;
		case "њ": v.x = -2.55f; v.y = -0.58f; break;
		case "џ": v.x = -0.99f; v.y = 1.47f; break;
		
		case "da": v.x = -6f; v.y = -3.4f; break;
		case "ne": v.x = 6f; v.y = -3.4f; break;

		case "1": v.x = -4.21f; v.y = -2.26f; break;
		case "2": v.x = -3.39f; v.y = -2.26f; break;
		case "3": v.x = -2.51f; v.y = -2.26f; break;
		case "4": v.x = -1.52f; v.y = -2.26f; break;
		case "5": v.x = -0.74f; v.y = -2.26f; break;
		case "6": v.x = 0.22f; v.y = -2.26f; break;
		case "7": v.x = 1.09f; v.y = -2.26f; break;
		case "8": v.x = 2.01f; v.y = -2.26f; break;
		case "9": v.x = 2.89f; v.y = -2.26f; break;
		case "0": v.x = 3.81f; v.y = -2.26f; break;
			
		default: v.x = 0; v.y = 0; break;		
		}	
		return v;
	}
}
