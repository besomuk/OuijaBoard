using UnityEngine;
using System.Collections;

/* todo
 * - obraditi slucaj kada je samo jedna rec u pitanju
 * - obraditi slucaj kada je potrebno ubaciti OTHER
 * - posle par pitanja dodati odustajanje od daljeg razgovora
 * */

public class Ouija 
{
	string answer = "NA";    // odgovor 
	string question = "NA";  // pitanje
	string[] words;          // reci iz pitanja
	
	/* tipovi odgovora */

	/** kog danu, u kom danu, koji dan */
	string[] days = {"ponedeljak", "utorak", "sreda", "četrvrtak", "petak", "subota", "nedelja", "sutra", "prekosutra", "dogodine", "juče"};

	/** kod meseca, u kom mesecu, koji mesec */
	string[] months = {"januar", "februar", "mart", "april", "maj", "juni", "juli", "avgust", "septembar",
			           "oktobar", "novembar", "decembar", "proleće", "leto", "jesen", "zima" };

    /** kad, kada */
	string[] times = {"uskoro", "brzo", "vrlo brzo", "sutra", "sledeće nedelje", "sledećeg meseca", "nikad", "kada zamre večnost", 
			          "sledeće godine", "dogodine", "na proleće", "na leto", "na jesen", "u zimu",
			          "u ponoć", "ujutro", "uveče", "popodne", "kada zađe sunce", "kada izađe sunce"};

	/** ko, kome, koga */
	string[] people = {"bliska osoba", "prijatelj", "neprijatelj", "javna ličnost", "niko", "neko poznat", "anonimus", "onaj koga ne zovu",
			           "draga osoba", "poznanik", "partner", "neko iz prošlosti", "silueta", "lažov", "salamander", 
			           "prevarant", "veseljak", "lopov", "umetnik", "fotograf", "snimatelj", "vozač", "đavo", "drekavac",
						"hitler", "nečastivi", "volšebnik", "zduhać", "žena zmaj"};

	/** gde */
	string[] places = {"Srbija", "inostranstvo", "rodni grad", "rodno mesto", "morska obala", "obala reke", "planina", "šuma", "šumski potok", "beograd", "nemacka", "rusija", "nigde", 
			           "javno mesto", "raskrsnica", "tvoja kuća", "javni prevoz", "pored vode", "mračno mesto", "amerika", "španija", "grčka", "japan", "mesec", "mars", "jupiter",
			           "svetlo mesto", "što dalje"};

	/** kako */
	string[] hows = {"teško", "potrudi se", "skupi snagu", "okušaj sreću", "ni ne pokušavaj", "pomuči se", "upri bolje", "moraš se sabrati"};

	/** kakav, kakva, kakvo */
	string[] hows2 = { "lep", "ruzan", "zajeban", "nikakav", "loš", "skršen", "slomljen", "naopak" };

	/** šta */
	string[] whats = {"ništa", "nešto govori iz tebe", "ono što niko ne zna", "ono što svako zna", "ono što je nepoznato",
			          "ono o cemu se ne govori", "ono sto je tajna"};

	/** zasto, zbog cega */
	string[] whys = {"zato", "zbog radi toga", };
			
	/** koliko, kolko, kol'lo */
	string[] how_muchs = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "1_3", "6_6_6", "9_9_9", "7_7_7", "0", "bezbroj"};	

	/** pitanje nije jasno, default switch */
	string[] other = {"ne znam", "ne razumem", "pokušaj kasnije", "ostavi me na miru", "pitanje je teško",
			          "samo ti znaš odgovor", "ne vidim", "mračno je", "idi vidi dal sam u kuhinji", 
			          "vidim maglu"};	

	/** dal, da li, jel, je li */
	string[] yesno = {"da", "sigurno", "definitivno", "ako dozvole zvezde", "ne","nema šanse","nemoguće", "možda","sumnjam","može biti"};
	
	
	
	public Ouija()
	{
		//question = question_i;
	}	
	
	private void prepareWords()
	{
		/* izbaci znake interpunkcije i djubre */
		question = question.ToLower();
		question = question.Replace("!", "");
		question = question.Replace("?", "");
		question = question.Replace(",", "");
		question = question.Replace(".", "");
		question = question.Replace("#", "");
		question = question.Replace("$", "");
	}
	
	public string getAnswer( string _q )
	{
		question = _q;
		question = question + " .";  // dobijam exception za array ako ne dodam bar 2 elementa niza, ovo ispraviti ( u switchu ima words.lengyh - 1 ) zasto ?????
		prepareWords();
		words = question.Split(' ');
		//Random rnd = new Random();
				
		/* probaj da nadjes odgovor na osnovu reci */		
		for (int i=0; i<words.Length; i++)
		{
			switch (words[i])
			{
				case "dan":
				case "dana":
				case "danu":
					answer = days [Random.Range(0, days.Length)];
					i = words.Length-1;                                // zasto ovo??????????
					break;
				case "mesec":
				case "meseca":
				case "mesecu":	
					answer = months[Random.Range(0,months.Length)];
					i = words.Length-1;
					break;
				case "kad":
				case "kada":
					answer = times[Random.Range(0,times.Length)];
					i = words.Length-1;
					break;
				case "ko":
				case "kome":
				case "koga":
					//answer = "Osoba je " + people[Random.Range(0,people.Length)];
				    answer = people[Random.Range(0,people.Length)];
					i = words.Length-1;
					break;
				case "gde":
					answer = places[Random.Range(0,places.Length)];
					i = words.Length-1;
					break;
				case "kako":
					answer = hows[Random.Range(0,hows.Length)];
					i = words.Length-1;
					break;		
				case "sta":
				case "šta":
					answer = whats[Random.Range(0,whats.Length)];
					i = words.Length-1;
					break;
				case "koliko":
				case "kolko":
				case "kol'ko":
					answer = how_muchs[Random.Range(0,how_muchs.Length)];
					i = words.Length-1;
					break;
				case "kakav":
				case "kakva":
				case "kakvo":
					answer = hows2[Random.Range(0,hows2.Length)];
					i = words.Length-1;
					break;
				case "zasto":
				case "zašto":
				case "zbog":
					answer = whys[Random.Range(0,whys.Length)];
					i = words.Length-1;
					break;
				case "jer":
					answer = "ne kaže se jer nego jel";
					i = words.Length-1;
					break;
				default:
					answer = other[Random.Range(0,other.Length)];				
					break;
			}
		}
		
		/* proveri da li ili ne */
		if ( ( words[0].Equals("da") && words[1].Equals("li")    ) ||  			
		     ( words[1].Equals("da") && words[2].Equals("li")    ) ||  
			 ( words[0].Equals("dali") || words[0].Equals("dal") ) ||
			 ( words[1].Equals("dali") || words[1].Equals("dal") ) ||
			 ( words[0].Equals("je") && words[1].Equals("li")    ) || 
			 ( words[1].Equals("je") && words[2].Equals("li")    ) ||
			 ( words[0].Equals("jeli") || words[0].Equals("jel") ) ||
			 ( words[1].Equals("jeli") || words[1].Equals("jel") ) )
			answer = yesno[Random.Range(0,yesno.Length)];
		
		return answer;
	}
}

