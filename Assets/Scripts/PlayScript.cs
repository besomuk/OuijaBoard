using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID
	using UnityEngine.Advertisements;
#endif


public class PlayScript : MonoBehaviour 
{

	public GameObject cursor;
	public GameObject startPosition;
	public GameObject shareIcon;

	public Button askButton;
	public InputField inputQuestion;
	public Text txtAnswer;

	public float movementTime  = 1.0f; // vreme za potez
	public float yesNoWaitTime = 3.0f; // ako smo kao odgovor dobili da ili ne, ovo je vreme cekanja na jednom od njih

	private string answerString = "srdjan";
	private string question;
	private int counter = 0;

	private Ouija spirits;

	private int counterAds = 0; // counter za adds

	public AudioSource as1, as2;

	void Start () 
	{
		if( Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsPlayer )
		{
			shareIcon.SetActive( false );
		}

		askButton.onClick.AddListener( AskSpirits );
		spirits = new Ouija();


		MoveCursorToStartPosition( 0 );

		//print( spirits.getAnswer("da li ovo") );
		//prst = cursor.gameObject.GetComponent<CursorScript>().prst;
		//print( prst );
		#if UNITY_ANDROID
			Advertisement.Initialize("1714216");
		#endif
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	}		

	void AskSpirits ()
	{
		question = inputQuestion.text;              // uzmi pitanje u privatnu promenljivu

		if ( question != "" )
		{
			counterAds++;
			question = question.ToLower();              // osiguraj se da su mala slova
			answerString = spirits.getAnswer(question); // uzmi odgovor
			//answerString = question;                    // debug odgovor
			txtAnswer.text = "";                        // izbrisi tekst, ako ga ima
			askButton.enabled = false;                  // iskljuci dugme da ne petljaju dok traje animacija
			shareIcon.SetActive( false );               // dok traje animacija, skloni share dugme

			if( answerString == "da" || answerString == "ne" )
			{
				ShowYesNo( answerString );
			}
			else
			{
				FindNextLetter();                           // zapocni ispis odgovora
			}
		}
	}		

	/** trazenje pozicije slova i animacija do slova **/
	void FindNextLetter ()
	{
		string letter = answerString[counter].ToString(); // uzmi jedno slovo

		iTween.MoveTo ( cursor, iTween.Hash (
			"x", GameManager.gm.GetLetterPosition ( letter ).x,
			"y", GameManager.gm.GetLetterPosition ( letter ).y,
			"time", movementTime,
			"oncomplete", "MoveComplete",
			"oncompleteparams", letter,
			"oncompletetarget", gameObject ));		

	}

	/** naslo smo jedno slovo, sta dalje? **/
	void MoveComplete ( string letter )
	{
		//as2.Play();
		if( counter == answerString.Length - 1 ) // kraj
		{			
			txtAnswer.text += letter.ToUpper(); // ne zaboravi poslednje slovo !
			MoveCursorToStartPosition( 0 );
			counter = 0;
		}
		else
		{
			if ( letter != "_")
				txtAnswer.text += letter.ToUpper();  // dodaj slovo u text box
			counter++;
			FindNextLetter();
		}
	}

	/** specijalan slucaj, da ili ne **/
	void ShowYesNo ( string _answer )
	{
		iTween.MoveTo ( cursor, iTween.Hash (
			"x", GameManager.gm.GetLetterPosition ( _answer ).x,
			"y", GameManager.gm.GetLetterPosition ( _answer) .y,
			"time", movementTime,
			"oncomplete", "MoveCursorToStartPosition",
			"oncompleteparams", yesNoWaitTime,
			"oncompletetarget", gameObject ));				
	}

	/*
	void YesNoMoveComplete ( string letter )
	{
		iTween.MoveTo ( cursor, iTween.Hash (
			"x", startPosition.transform.position.x,
			"y", startPosition.transform.position.y,
			"time", movementTime,
		    "delay", 3,
			"oncomplete", "YesNoMoveComplete"));				
	}
	*/

	void MoveCursorToStartPosition ( float delay )
	{
		//cursor.transform.position = startPosition.transform.position;
		iTween.MoveTo ( cursor, iTween.Hash (
			"x", startPosition.transform.position.x,
			"y", startPosition.transform.position.y,
			"time", movementTime,
			"delay", delay,
			"oncomplete", "QuestionDone",
			"oncompletetarget", gameObject ));	

		if( counterAds == 3 )
		{
			ShowAds();
		}
	}

	/** pitanje je gotovo **/ 
	void QuestionDone ()
	{
		askButton.enabled = true;     // ukljuci dugme
		if( Application.platform == RuntimePlatform.Android )
		{
			shareIcon.SetActive( true );
		}
	}

	void ShowAds()
	{
		counterAds = 0;
		#if UNITY_ANDROID
			Advertisement.Show();
		#endif
	}
}
