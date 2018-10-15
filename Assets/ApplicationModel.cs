using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {
	
	static public int level;
	static public bool gameOver;
	static public int spriteGender;
	static public int tutorialState;
	static public int spriteNum;
	static public int timerSlices;
	static public float totalTime;
	static public int totalCalories;
	static public int totalWater;
	static public int totalSport;
	static public bool isJumping;
	static public string language;


	static public string en_tutorial_advanceText = "Press 'N' to Advance";
	static public string es_tutorial_advanceText = "Pulsa 'N' para avanzar";
	static public string de_tutorial_advanceText = "Drücke 'N', um fortzufahren";

	static public string en_gameStart_controlsText = "Use the -- Arrow Keys -- to move your character Left and Right\n\nUse the -- Spacebar -- to Jump";
	static public string en_gameStart_startText = "1) Select a Character Using the -- Arrow Keys -- of the keyboard\n\n2) Press 'N' to Start Playing!";
	static public string es_gameStart_controlsText = "Utiliza las -- Flechas -- para moverte a Izquierda y Derecha\n\nUsa la -- Barra Espaciadora -- para Saltar";
	static public string es_gameStart_startText = "1) Selecciona un personaje con las -- Flechas -- del teclado\n\n2) Pulsa 'N' para comenzar!";
	static public string de_gameStart_controlsText = "Benutze die - Pfeiltasten - um deinen Avatar nach links und rechts zu bewegen\n\nVerwende die - Leertaste - um zu springen";
	static public string de_gameStart_startText = "1) Wähle einen Avatar mit den - Pfeiltasten - der Tastatur\n\n2) Drücke 'N', um mit der Wiedergabe zu beginnen!";

	static public string en_scoreHandler_congratsObjectText = "You Beat the Game Consuming...";
	static public string en_scoreHandler_congratsCaloriesObjectText = "Calories!";
	static public string en_scoreHandler_shareTwitterObjectText = "Press 'T' to Tweet Your Score!";
	static public string es_scoreHandler_congratsObjectText = "Superaste el juego consumiendo...";
	static public string es_scoreHandler_congratsCaloriesObjectText = "Calorias!";
	static public string es_scoreHandler_shareTwitterObjectText = "Pulsa 'T' para twittear tu resultado!";
	static public string de_scoreHandler_congratsObjectText = "Du hast das Spiel geschlagen, indem du ... konsumiert hast";
	static public string de_scoreHandler_congratsCaloriesObjectText = "kalorien !";
	static public string de_scoreHandler_shareTwitterObjectText = "Drücke 'T', um dein Ergebnis zu Tweet!";
	static public string en_scoreHandler_twitterText1 = "I've just beaten the game consuming ";
	static public string en_scoreHandler_twitterText2 = " calories !!! #VeggieGame #ExploreAT!";
	static public string es_scoreHandler_twitterText1 = "He finalizado el juego consumiendo ";
	static public string es_scoreHandler_twitterText2 = " calorias !!! #VeggieGame #ExploreAT!";
	static public string de_scoreHandler_twitterText1 = "Du hast das Spiel geschlagen, indem du ... konsumiert hast ";
	static public string de_scoreHandler_twitterText2 = " kalorien !!! #VeggieGame #ExploreAT!";

	static public string en_scene_scoreText = " Total Calories";
	static public string en_scene_gameOverText = "Game Over (R to Restart)";
	static public string en_scene_levelText = "Level ";
	static public string en_scene_nextLevelText = "Great! (N to Advance)";
	static public string en_scene_popUpText = " Calories !!!";
	static public string en_scene_TweetObjectText = "Press 'T' to Tweet Your Calories!";
	static public string es_scene_scoreText = " Calorias Totales";
	static public string es_scene_gameOverText = "Game Over (R para reiniciar)";
	static public string es_scene_levelText = "Nivel ";
	static public string es_scene_nextLevelText = "Conseguido (N para avanzar)";
	static public string es_scene_popUpText = " Calorias !!!";
	static public string es_scene_TweetObjectText = "Pulsa 'T' para twitter tus calorias!";
	static public string de_scene_scoreText = " Gesamtkalorien";
	static public string de_scene_gameOverText = "Game Over (R zum Neustart)\n";
	static public string de_scene_levelText = "Niveau ";
	static public string de_scene_nextLevelText = "Groß! ('N', um fortzufahren)";
	static public string de_scene_popUpText = " Kalorien !!!";
	static public string de_scene_TweetObjectText = "Drücke 'T', um dein kalorien zu Tweet!";


	// Use this for initialization
	void Start () {
		gameOver = false;
		level = 1;
		tutorialState = 0;
		spriteGender = 0;
		spriteNum = 0;
		timerSlices = 7;
		totalTime = 0f;
		totalCalories = 0;
		totalWater = 0;
		totalSport = 0;
		isJumping = false;
		language = "en";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
