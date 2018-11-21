using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {
	
	static public int level;
	static public int maxLevel;
	static public bool gameOver;
	static public int spriteGender;
	static public int tutorialState;
	static public int spriteNum;
	static public int season;
	static public int timerSlices;
	static public float totalTime;
	static public int totalCalories;
	static public int totalWater;
	static public int totalSport;
	static public bool isJumping;
	static public string language;
	static public bool levelCleared;

	static public int pctBreadPasta = 25;
	static public int pctFruitVeggies = 30;
	static public int pctMeatFish = 15;
	static public int pctMilkCheese = 20;
	static public int pctSweetSalty = 10;

	static public int valueSport = 1;
	static public int valueWater = 1;
	static public int valueBreadPasta = 3;
	static public int valueFruitVeggies = 3;
	static public int valueMeatFish = 2;
	static public int valueMilkCheese = 3;
	static public int valueSweetSalty = 1;

	static public int counterBreadPasta, counterBreadPastaMin = 28, counterBreadPastaMax = 35;
	static public int counterFruitVeggies, counterFruitVeggiesValue = 35;
	static public int counterMeatFish, counterMeatFishMin = 8, counterMeatFishMax = 11;
	static public int counterMilkCheese, counterMilkCheeseValue = 21;
	static public int counterSweetSalty, counterSweetSaltyValue = 7;
	static public int counterSportValue = 7;
	static public int counterWaterValue = 6;

	/*
	static public int counterBreadPasta, counterBreadPastaMin = 1, counterBreadPastaMax = 10;
	static public int counterFruitVeggies, counterFruitVeggiesValue = 5;
	static public int counterMeatFish, counterMeatFishMin = 5, counterMeatFishMax = 10;
	static public int counterMilkCheese, counterMilkCheeseValue = 5;
	static public int counterSweetSalty, counterSweetSaltyValue = 3;
	*/

	static public string en_splash_text = "Select the Language (1-2-3 Keys) - Press 'N' to Advance\nPress 'R' at Any Time to Come Back to This Screen";
	static public string es_splash_text = "Selecciona un idioma (Teclas 1-2-3) - Pulsa 'N' para Avanzar\nPulsa 'R' para Volver a la Pantalla Inicial";
	static public string de_splash_text = "Wähle eine Sprache (1-2-3 Tasten) - Drücke 'N', um fortzufahren\nDrücke ‘R’ um jeder Zeit zu diesem Bildschirm zurückzukommen";

	static public string en_pyramid_advanceText = "Press 'N' to Advance";
	static public string es_pyramid_advanceText = "Pulsa 'N' para avanzar";
	static public string de_pyramid_advanceText = "Drücke 'N', um fortzufahren";
	static public string en_pyramid_infoText = "Put the mouse over each food group to get more information about it!";
	static public string es_pyramid_infoText = "Coloca el cursor sobre cada grupo alimenticio para obtener más información!";
	static public string de_pyramid_infoText = "Bewege den Mauszeiger über jede Lebensmittelgruppe um mehr Information zu erhalten";
	static public string en_pyramid_source = "Source: GESUNDHEIT.GV.AT";
	static public string es_pyramid_source = "Fuente: GESUNDHEIT.GV.AT";
	static public string de_pyramid_source = "Quelle: GESUNDHEIT.GV.AT";

	static public string en_tutorial_advanceText = "Press 'N' to Advance\n\nPress 'S' to Skip";
	static public string es_tutorial_advanceText = "Pulsa 'N' para avanzar\n\nPulsa 'S' para saltar";
	static public string de_tutorial_advanceText = "Drücke 'N', um fortzufahren\n\nDrücke ‘S’ um zu springen";

	static public string en_gameStart_controlsText = "Use the -- Arrow Keys -- to move your character Left and Right\n\nUse the -- Spacebar -- to Jump";
	static public string en_gameStart_startText = "1) Select a Character Using the -- Arrow Keys -- of the keyboard\n\n2) Select a Season (Winter/Summer) to Play In\n\n3) Press 'N' to Start Playing!";
	static public string es_gameStart_controlsText = "Utiliza las -- Flechas -- para moverte a Izquierda y Derecha\n\nUsa la -- Barra Espaciadora -- para Saltar";
	static public string es_gameStart_startText = "1) Selecciona un personaje con las -- Flechas -- del teclado\n\n2) Elige una estacion (Invierno/Verano) en la que jugar\n\n3) Pulsa 'N' para comenzar!";
	static public string de_gameStart_controlsText = "Benutze die - Pfeiltasten - um deinen Avatar nach links und rechts zu bewegen\n\nVerwende die - Leertaste - um zu springen";
	static public string de_gameStart_startText = "1) Wähle einen Avatar mit den - Pfeiltasten - der Tastatur\n\n2) Wähle eine Jahreszeit (Sommer/Winter) für das Spiel\n\n3) Drücke 'N', um mit der Wiedergabe zu beginnen!";


	static public string en_summaryHandler_waterGoodMsgText = "You drank enough water during the week!";
	static public string es_summaryHandler_waterGoodMsgText = "Bebiste suficiente agua durante la semana!";
	static public string de_summaryHandler_waterGoodMsgText = "Du hast genug Wasser während der Woche getrunken";
	static public string en_summaryHandler_waterBadMsgText = "You didn't drank enough water during the week!";
	static public string es_summaryHandler_waterBadMsgText = "No bebiste suficiente agua durante la semana!";
	static public string de_summaryHandler_waterBadMsgText = "Du hast nicht genug Wasser während der Woche getrunken";
	static public string en_summaryHandler_sportGoodMsgText = "You exercised enough during the week!";
	static public string es_summaryHandler_sportGoodMsgText = "Hiciste suficiente ejercicio durante la semana!";
	static public string de_summaryHandler_sportGoodMsgText = "Du hast genug Sport während der Woche gemacht";
	static public string en_summaryHandler_sportBadMsgText = "You didn't exercise enough during the week!";
	static public string es_summaryHandler_sportBadMsgText = "No hiciste suficiente ejercicio durante la semana!";
	static public string de_summaryHandler_sportBadMsgText = "Du hast nicht genug Sport während der Woche gemacht";
	static public string en_summaryHandler_successGoodMsgText = "Press -N- to Advance to the Next Week!";
	static public string es_summaryHandler_successGoodMsgText = "Pulsa -N- para avanzar a la siguiente semana!";
	static public string de_summaryHandler_successGoodMsgText = "Drücke -N- um zur nächsten Woche zu gelangen";
	static public string en_summaryHandler_successBadMsgText = "Press -N- to Retry This Week!";
	static public string es_summaryHandler_successBadMsgText = "Pulsa -N- para reintentar esta semana!";
	static public string de_summaryHandler_successBadMsgText = "Drücke -N- um die Woche zu wiederholen";
	static public string en_summaryHandler_gameEndMsgText = "You Beat the Game! Press -N- to Start Again!";
	static public string es_summaryHandler_gameEndMsgText = "Superaste el juego! Pulsa -N- para recomenzar";
	static public string de_summaryHandler_gameEndMsgText = "Du hast das Spiel geschlagen! Drücke -N- um erneut zu beginnen!";
	static public string en_summaryHandler_breadPastaMsgTextGood = "You Ate the Right Amount of Pasta and Bread!";
	static public string es_summaryHandler_breadPastaMsgTextGood = "Comiste el Pan y Pasta necesarios!";
	static public string de_summaryHandler_breadPastaMsgTextGood = "Du hast genug Brot und Teigwaren gegessen";
	static public string en_summaryHandler_breadPastaMsgTextBad = "You Did Not Eat the Right Amount of Pasta and Bread!";
	static public string es_summaryHandler_breadPastaMsgTextBad = "No comiste el Pan y Pasta necesarios!";
	static public string de_summaryHandler_breadPastaMsgTextBad = "Du hast nicht genug Brot und Teigwaren gegessen";
	static public string en_summaryHandler_fruitVeggiesMsgTextGood = "You Ate the Right Amount of Fruit and Veggies!";
	static public string es_summaryHandler_fruitVeggiesMsgTextGood = "Comiste la Fruta y Verduras necesarias!";
	static public string de_summaryHandler_fruitVeggiesMsgTextGood = "Du hast genug Obst und Gemüse gegessen";
	static public string en_summaryHandler_fruitVeggiesMsgTextBad = "You Did Not Eat the Right Amount of Fruit and Veggies!";
	static public string es_summaryHandler_fruitVeggiesMsgTextBad = "No comiste la Fruta y Verduras necesarias!";
	static public string de_summaryHandler_fruitVeggiesMsgTextBad = "Du hast nicht genug Obst und Gemüse gegessen";
	static public string en_summaryHandler_meatFishMsgTextGood = "You Ate the Right Amount of Meat and Fish!";
	static public string es_summaryHandler_meatFishMsgTextGood = "Comiste la Carne y Pescado necesarios!";
	static public string de_summaryHandler_meatFishMsgTextGood = "Du hast genug Fleisch und Fisch gegessen";
	static public string en_summaryHandler_meatFishMsgTextBad = "You Did Not Eat the Right Amount of Meat and Fish!";
	static public string es_summaryHandler_meatFishMsgTextBad = "No comiste la Carne y Pescado necesarios!";
	static public string de_summaryHandler_meatFishMsgTextBad = "Du hast nicht genug Fleisch und Fisch gegessen";
	static public string en_summaryHandler_milkCheeseMsgTextGood = "You Ate the Right Amount of Dairy Products!";
	static public string es_summaryHandler_milkCheeseMsgTextGood = "Comiste los Productos Lacteos necesarios!";
	static public string de_summaryHandler_milkCheeseMsgTextGood = "Du hast genug Milchprodukte gegessen";
	static public string en_summaryHandler_milkCheeseMsgTextBad = "You Did Not Eat the Right Amount of Dairy Products!";
	static public string es_summaryHandler_milkCheeseMsgTextBad = "No comiste los Productos Lacteos necesarios!";
	static public string de_summaryHandler_milkCheeseMsgTextBad = "Du hast nicht genug Milchprodukte gegessen";
	static public string en_summaryHandler_sweetSaltyMsgTextGood = "You Eat the Right Amount of Sweets!";
	static public string es_summaryHandler_sweetSaltyMsgTextGood = "No comiste demasiados Dulces!";
	static public string de_summaryHandler_sweetSaltyMsgTextGood = "Du hast nicht zu viele Süßigkeiten gegessen";
	static public string en_summaryHandler_sweetSaltyMsgTextBad = "You Did Not Ate the Right Amount of Sweets!";
	static public string es_summaryHandler_sweetSaltyMsgTextBad = "Comiste demasiados Dulces!";
	static public string de_summaryHandler_sweetSaltyMsgTextBad = "Du hast zu viele Süßigkeiten gegessen";
	static public string en_summaryHandler_infoMsgText = "Put the mouse over each food group to get more information about it!";
	static public string es_summaryHandler_infoMsgText = "Coloca el cursor sobre cada grupo alimenticio para obtener más información!";
	static public string de_summaryHandler_infoMsgText = "Bewege den Mauszeiger über jede Lebensmittelgruppe um mehr Information zu erhalten";


	static public string en_scene_timeupText = "TIME IS UP!";
	static public string en_scene_checkProgressText = "Press -N- to Check Your Progress";
	static public string en_scene_gameOverText = "Oh no! You Caught an Energy Drink or the Wrong Amount of Food (-N- to Restart)";
	static public string es_scene_timeupText = "TIEMPO!";
	static public string es_scene_checkProgressText = "Pulsa -N- para Comprobar tu Progreso";
	static public string es_scene_gameOverText = "Oh no! Tomaste una Bebida Energética o la Cantidad Incorrecta de Comida(-N- para Reiniciar)";
	static public string de_scene_timeupText = "ZEIT ABGELAUFEN";
	static public string de_scene_checkProgressText = "Drücke -N- um deinen Fortschritt anzuzeigen ";
	static public string de_scene_gameOverText = "Oh nein! Du hast einen Energydrink gefangen oder die falsche Menge an bestimmten Lebensmitteln gegessen! (Drücke -N- um neu zu beginnen)";


	static public string en_scene_scoreText = " Total Calories";
	static public string en_scene_levelText = "Week ";
	static public string en_scene_nextLevelText = "Great! (N to Advance)";
	static public string en_scene_popUpText = " Calories !!!";
	static public string en_scene_TweetObjectText = "Press 'T' to Tweet Your Calories!";
	static public string es_scene_scoreText = " Calorias Totales";
	static public string es_scene_levelText = "Week ";
	static public string es_scene_nextLevelText = "Conseguido (N para avanzar)";
	static public string es_scene_popUpText = " Calorias !!!";
	static public string es_scene_TweetObjectText = "Pulsa 'T' para twitter tus calorias!";
	static public string de_scene_scoreText = " Gesamtkalorien";
	static public string de_scene_levelText = "Week ";
	static public string de_scene_nextLevelText = "Groß! ('N', um fortzufahren)";
	static public string de_scene_popUpText = " Kalorien !!!";
	static public string de_scene_TweetObjectText = "Drücke 'T', um dein kalorien zu Tweet!";

	static public string en_titleBreadPasta = "Bread & Pasta";
	static public string en_titleFruitVeggies = "Fruit & Vegetables";
	static public string en_titleMeatFish = "Meat, Fish & Eggs";
	static public string en_titleMilkCheese = "Dairy Products";
	static public string en_titleSweetSalty = "Sweets and Salties";
	static public string en_titleWater = "Water";
	static public string en_infoBreadPasta = "Every day, you should take 4 servings of cereals, bread, pasta, rice or potatoes (5 servings for active athletes and children). Ideal are whole-grain products such as unsweetened muesli, wholemeal bread and pasta or brown rice. Please note: Not bread, pasta, rice and potatoes are rich in fat and calories, but the often served sauces, spreads, sausages and cheeses. Noodles refined with butter and cream sauce naturally have more calories than those with low-fat vegetable sauce. Fried Potatoes also have a higher fat content than cooked ones.";
	static public string en_infoFruitVeggies = "Ideal are 5 servings of vegetables, legumes and fruits a day - preferably 3 servings of vegetables and / or pulses and 2 servings of fruit. Variety is desired and vegetables or fruits can be served both raw and cooked. Avoid: heavy sauces (eg sauces with whipped cream), fatty salad dressings and extra portions of sugar to the fruit (salad). You should preffer seasonal and regional fruits and vegetables.";
	static public string en_infoMeatFish = "1 to 2 servings of fish a week - ideal is fatty sea fish such as mackerel, salmon, tuna or herring, but also domestic coldwater fish such as char. Maximum 3 portions of low-fat meat or low-fat sausage products - e.g. lean chicken and ham. Red meat (like beef, pork or lamb) and sausages should rather be avoided because of the salt they contain. You can eat up to 3 eggs a week. Note that eggs are often also present in processed form in various foods (for example, in pasta, pastries, pastries).";
	static public string en_infoMilkCheese = "Every day you should have 3 servings of milk and dairy products. Ideal are 2 portions of \"white\" - such as milk, yoghurt, buttermilk, cottage cheese - and 1 serving of \"yellow\" cheese - best in the form of low-fat products.";
	static public string en_infoSweetSalty = "You should rarely enjoy foods high in fat, sugar and salt. A maximum of one serving of sweet or fat snacks should be taken daily. According to the WHO, the current recommendation for maximum salt intake is 5 grams per day. Note the salt in high amounts is contained in e.g. bread, sausage and cheese. Use salt sparingly or replace it with herbs and spices!";
	static public string en_infoWater = "Eat fruits and vegetables, as they also contain liquids. Nevertheless, in any case at least 1.5 liters per day should be consumed in the form of drinks. The best are low-energy drinks such as water, mineral water, unsweetened fruit and herbal teas and diluted fruit and vegetable juices. Coffee and black tea should be drunk in moderation (maximum 3 to 4 cups). Alcoholic beverages are not calculated for fluid intake.";
	static public string es_titleBreadPasta = "Pan & Pasta";
	static public string es_titleFruitVeggies = "Fruta & Verduras";
	static public string es_titleMeatFish = "Carne & Pescado";
	static public string es_titleMilkCheese = "Productos Lacteos";
	static public string es_titleSweetSalty = "Dulces";
	static public string es_titleWater = "Agua";
	static public string es_infoBreadPasta = "Todos los días debes tomar 4 porciones de cereales, pan, pasta, arroz o patatas (5 porciones para atletas activos y niños). Son ideales los productos integrales, como el muesli sin azúcar, el pan integral y la pasta o el arroz integral. Ten en cuenta que el pan, la pasta, el arroz y las patatas no son ricos en grasas y calorías, pero que a menudo se sirven con salsas y otros productos que sí lo son. Los fideos refinados con mantequilla y otras cremas tienen más calorías que los que tienen salsa de vegetales baja en grasa. Las patatas fritas también tienen un mayor contenido de grasa que las cocidas.";
	static public string es_infoFruitVeggies = "Lo ideal son 5 porciones de verduras, legumbres y frutas al día, preferiblemente 3 porciones de verduras y/o legumbres y 2 porciones de frutas. Se desea variedad y se pueden servir verduras o frutas crudas y cocidas. Evita salsas pesadas (por ejemplo, salsas con crema batida), aderezos grasos para ensaladas y porciones adicionales de azúcar a la fruta. Intenta priorizar frutas y verduras de temporada y regionales.";
	static public string es_infoMeatFish = "De 1 a 2 porciones de pescado a la semana: lo ideal es el pescado de mar graso, como la caballa, el salmón, el atún o el arenque, pero también el pescado doméstico de agua dulce. Máximo 3 porciones de carne baja en grasa o salchichas (por ejemplo pollo magro o jamón). La carne roja (como la carne de res, cerdo o cordero) y las salchichas deben evitarse debido a la sal que contienen. Puedes comer hasta 3 huevos a la semana. Ten en cuenta que los huevos a menudo también están presentes en forma procesada en varios alimentos (por ejemplo, en pasta o pasteles).";
	static public string es_infoMilkCheese = "Cada día deberías tomar 3 porciones de productos lácteos. Lo mejor es tomar 2 porciones de productos “blancos” (leche, yogur, queso de cabra,...) y 1 porción de queso \"amarillo\", a ser posible bajo en grasas.";
	static public string es_infoSweetSalty = "Rara vez debes consumir alimentos ricos en grasa, azúcar y sal. Se debe tomar un máximo de una porción de dulces o productos grasos todos los días. Según la OMS, la recomendación actual para la ingesta máxima de sal es de 5 gramos por día. Ten en cuenta que la sal en cantidades altas está contenida en, por ejemplo, el pan, el chorizo o el queso. Usa la sal con moderación o reemplazala con hierbas y especias!";
	static public string es_infoWater = "Come frutas y verduras, ya que también contienen líquidos. En cualquier caso, toma al menos 1,5 litros de bebidas al día. Las mejores son las bebidas de bajo consumo energético, como agua, agua mineral, tés de hierbas y jugos de frutas y vegetales diluidos. El café y el té negro deben tomarse con moderación (máximo de 3 a 4 tazas). Las bebidas alcohólicas no se calculan para la ingesta de líquidos.";
	static public string de_titleBreadPasta = "Brot & Pasta & Reis";
	static public string de_titleFruitVeggies = "Obst & Gemüse";
	static public string de_titleMeatFish = "Fleisch, Fisch & Eier";
	static public string de_titleMilkCheese = "Milch & Milchprodukte";
	static public string de_titleSweetSalty = "Süßes und Salziges";
	static public string de_titleWater = "Wasser";
	static public string de_infoBreadPasta = "Täglich solltest du 4 Portionen Getreide, Brot, Nudeln, Reis oder Erdäpfel (5 Portionen für sportlich Aktive und Kinder) zu dir nehmen. Ideal sind Vollkornprodukte wie ungezuckertes Müsli, Vollkornbrot und -nudeln oder Naturreis. Unbedingt beachten: Auf die Zubereitung kommt es an! Nicht Brot, Nudeln, Reis und Erdäpfel sind fett- und kalorienreich, sondern die oft dazu gereichten Saucen, Aufstriche, Wurst- und Käsesorten. Mit Butter und Rahmsauce verfeinerte Nudeln haben selbstverständlich mehr Kalorien als jene mit fettarmer Gemüsesauce. Erdäpfel in frittierter oder gebratener Form weisen ebenfalls einen höheren Fettanteil auf als gekochte.";
	static public string de_infoFruitVeggies = "Ideal sind 5 Portionen Gemüse, Hülsenfrüchte und Obst am Tag – am besten 3 Portionen Gemüse und/oder Hülsenfrüchte sowie 2 Portionen Obst. Bunte Vielfalt ist erwünscht, sowohl roh als auch gekocht. Vermeiden Sie hingegen: fette Saucen (z.B. Saucen mit Schlagobers), fette Dressings am Salat sowie Extraportionen Zucker zum Obst(-salat). Du solltest saisonales und regionales Obst und Gemüse bevorzugen.";
	static public string de_infoMeatFish = "Iss 1 bis 2 Portionen Fisch in der Woche – ideal ist fetter Seefisch wie Makrele, Lachs, Thunfisch oder Hering, aber auch heimischer Kaltwasserfisch wie z.B. Saibling.\nDu solltest maximal 3 Portionen fettarmes Fleisch oder fettarme Wurstwaren – z.B. mageres Hühnerfleisch und Schinken pro Woche essen. Rotes Fleisch (wie Rind, Schwein oder Lamm) und Wurstwaren sollten eher selten gegessen werden.\nAußerdem kannst du bis zu 3 Eier in der Woche essen. Beachte dabei, dass Eier oft auch in verarbeiteter Form in verschiedenen Lebensmitteln enthalten sind (z.B. in Nudeln, Gebäck, Mehlspeisen).";
	static public string de_infoMilkCheese = "Milch und Milchprodukte enthalten hochwertiges Eiweiß und gelten als Quelle für Kalzium und einige Vitamine (wie Vitamin A, B2 und Vitamin B12). Täglich solltest du 3 Portionen Milch und Milchprodukte essen. Ideal sind 2 Portionen „weiß“ – etwa Milch, Joghurt, Buttermilch, Hüttenkäse – und 1 Portion „gelb“: Käse – am besten in Form von fettarmen Produkten.";
	static public string de_infoSweetSalty = "Du solltest Lebensmittel mit hohem Anteil an Fett, Zucker und Salz selten essen. Maximal 1 Portion sollte an süßen oder fetten Snacks täglich gegessen werden. Die aktuelle Empfehlung für die maximale Salzaufnahme liegt laut WHO bei 5 Gramm pro Tag. Beachte dabei, dass Salz in hohen Mengen z.B. in Brot, Wurst und Käse enthalten ist. Salz solltest du daher sparsam verwenden bzw. durch Kräuter und Gewürze ersetzen!";
	static public string de_infoWater = "Obst und Gemüse essen, denn diese enthalten ebenfalls Flüssigkeit. Dennoch sollten zusätzlich in jedem Fall mindestens 1,5 Liter pro Tag in Form von Getränken konsumiert werden. Am besten sind energiearme Getränke wie Wasser, Mineralwasser, ungezuckerte Früchte- und Kräutertees sowie verdünnte Obst- und Gemüsesäfte. Kaffee und Schwarztee sollten in Maßen getrunken werden (maximal 3 bis 4 Tassen). Alkoholische Getränke werden nicht zur Flüssigkeitsaufnahme gerechnet.";

	static public string en_titlePyramid = "Food Pyramid";
	static public string en_infoPyramid = "The Nutrition Pyramid will help you to see what a healthy diet should look like in the best case. It provides information on the type and quantity of food and drink that should be consumed. It is structured according to a block principle. The seven levels of the pyramid show how often different food groups should be eaten.";
	static public string es_titlePyramid = "Pirámide Nutricional";
	static public string es_infoPyramid = "La Pirámide Nutricional te ayudará a ver qué aspectos debería tener una dieta saludable, proporcionando información sobre el tipo y la cantidad de alimentos y bebidas que deben consumirse. La pirámide está estructurada en base a una serie de bloques alimenticios. Los siete niveles de la pirámide muestran con qué frecuencia se deben consumir los alimentos correspondientes a cada grupo.";
	static public string de_titlePyramid = "Ernährungspyramide";
	static public string de_infoPyramid = "Die Ernärhungspyramide hilft dir zu sehen, wie eine gesunde Ernährung im optimalen Fall aussehen sollte. Sie gibt Auskunft über die Art und Menge der Nahrungsmittel und Getränke, die aufgenommen werden sollten. Sie ist nach einem Bausteinprinzip aufgebaut. Anhand der sieben Stufen der Pyramide kann abgelesen werden, wie häufig verschiedene Lebensmittelgruppen gegessen werden sollten.";

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

	// Use this for initialization
	void Start () {
		maxLevel = 4;
		levelCleared = false;
		gameOver = false;
		season = 0;
		level = 1;
		tutorialState = 0;
		spriteGender = 0;
		spriteNum = 0;
		timerSlices = 7;
		totalTime = 0f;
		totalCalories = 0;
		totalWater = 0;
		totalSport = 0;
		valueSport = 1;
		valueWater = 1;
		isJumping = false;
		language = "en";

		// Initial counters - Zero to Value - model
		counterBreadPasta = 0;
		counterFruitVeggies = 0;
		counterMeatFish = 0;
		counterMilkCheese = 0;
		counterSweetSalty = 0;
		// Initial counters - Value to zero - model
//		counterBreadPasta = (counterBreadPastaMax-counterBreadPastaMin);
//		counterFruitVeggies = counterFruitVeggiesValue;
//		counterMeatFish = (counterMeatFishMax-counterMeatFishMin);
//		counterMilkCheese = counterMilkCheeseValue;
//		counterSweetSalty = counterSweetSaltyValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
