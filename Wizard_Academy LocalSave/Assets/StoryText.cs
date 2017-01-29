using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    public string StoryMode;

	// Use this for initialization
	void Start () {
        GameObject.Find("Button_Dismiss").GetComponent<Button>().onClick.AddListener(() => { Destroy(GameObject.Find("StoryPanel")); });
        string title = "";
        string text = "";

        switch (StoryMode) {
            case "mini":
                title = "Die Gaußschen Wälder";
                text = "In Riedenberg geht das Gerücht um, dass sich großes Unheil über die weniger dicht besiedelten Gebiete des Landes gelegt hat und schreckliche Wesen, die viele nur noch aus alten Erzählungen kennen, erneut auf Erden wandeln. Erkunde die umliegenden Gaußschen Wälder  und versuche dem Ganzen auf den Grund zu gehen. ";
                if (Game.current.hero.Level > 3) {
                    title = "Die Sümpfe von Thales";
                    text = "Nachdem du Forstos besiegen konntest und weiter voranschreitest, kommt es dir so vor als würde die Luft immer schwerer und aus dem satten Grün der Wälder wird zunehmend schlammiger, verdorbener Boden. Nebelschwaden umziehen die abgestorbenen Überreste einst imposanter Bäume und durch die nach Schwefel stinkende Luft schneiden die markerschütternden Schreie von…GOBLINS?!";
                }
                if (Game.current.hero.Level > 6)
                {
                    title = "Die Gipfel von Euklid";
                    text = "Zusammen mit Swampus gehört nun auch die stickige Luft der Vergangenheit an und am aufklarenden Horizont zeichnen sich die Gipfel von Euklid ab. Trotz Schnee, Eis und Kälte kannst du am Himmel vogelartige Wesen erkennen. Je näher du dem ganzen Spektakel kommst, desto klarer wird, dass du die Größe der Kreaturen falsch eingeschätzt hast und auch ihre Umrisse weichen deutlich von denen eines Vogels ab. Sie sehen eher aus wie Wasserspeier? Doch kann das überhaupt sein? Oder hat dich das Höhenfieber gepackt?";
                }
                if (Game.current.hero.Level > 9)
                {
                    title = "Der Aschenkamm";
                    text = "Nachdem du auch dem letzten großen Übel siegreich gegenübergetreten bist, nutzt dieses seine letzten Momente um dich in ihren großen Plan einzuweihen. Die kleinen Brüder wurden vorgeschickt um ihm genug Zeit zu verschaffen Magmar den Weltenfresser zu beschwören. In den letzten Zügen der Beschwörung seist du dann erschienen und so war es nicht mehr möglich Magmar schlüpfen zu lassen. Doch das wäre nun nicht mehr von Bedeutung, denn sobald das Ei in einem der sengenden Vulkane des Aschenkamms versenkt werden würde, wäre das Ende sowieso gekommen. Du begibst dich nun also schleunigst auf den Weg zum Aschenkamm um dies zu verhindern.";
                }

                break;
            case "boss":
                title = "Forstos der Sprößling";
                text = "Die Gerüchte waren also mehr als nur das Hirngespinst einiger redseliger Bürger. Nachdem du dich durch Horden von Gerippen kämpfen musstest, stehst du nun dem Waldmagier Forstos gegenüber. Du weißt nicht, was dir mehr Sorgen bereitet. Der Anblick des dunklen Erzmagiers selbst oder die Tatsache, dass dieser wahrscheinlich noch das geringste Problem von all denen sein wird, die dir noch bevorstehen. Forstos ist der jüngste von drei Brüdern, die sich allesamt den dunklen Künsten verschrieben haben und bereits vor mehreren Jahrhunderten als die drei großen Übel in die Geschichtsbücher eingingen.";
                if (Game.current.hero.Level > 3)
                {
                    title = "Swampus der Hinterlistige";
                    text = "Nur einer kann für die Rückkehr der Goblinstämme in die Sümpfe von Thales verantwortlich sein. Der mittlere Bruder des dunklen Erzmagier-Trios: Swampus der Hinterlistige. Es ist eher untypisch, für ihn alleine in Erscheinung zu treten. Normalerweise begleitet er seine Brüder oder die Truppen seiner Goblinstämme und greift nur aus dem Verborgenen die Ahnungslosen an, die es wagen ihre Rückendeckung zu vernachlässigen. Doch trotzdem stehst du ihm nun von Angesicht zu Angesicht gegenüber und eine kalte Brise, die dir ins Gesicht schlägt ist der Bote von dem, der da noch kommen mag.";
                }
                if (Game.current.hero.Level > 6)
                {
                    title = "Freezos der Kaltblütige";
                    text = "Die geflügelten Wesen strahlten eine unheimliche Kälte aus und schimmerten wie Gletschereis. Ihr Nest schien in einem fantastisch anmutenden Gestrüpp aus Eissäulen versteckt zu sein. Hier hausten sie zusammen mit ihrem Meister: Freezos der Kaltblütige. Er ist der mächtigste der drei großen Übel und war schon seit der Zeit ihrer Ausbildung in den dunklen Künsten immer der Kopf hinter all ihren Schandtaten. Als er dich bemerkt, weist er eine seiner Kreaturen an hastig mit einem großen Ei den Bau zu verlassen und schwebt zu dir herüber.";
                }
                if (Game.current.hero.Level > 9)
                {
                    title = "Magmar der Weltenfresser";
                    text = "Erschöpft und geschwächt von deiner langen Reise musst du nun am Fuße des größten Vulkans des Aschenkamms auch noch hilflos mit ansehen, wie der Diener von Freezos das Ei in das kochende Gestein wirft.  Eine riesige Stichflamme schießt zusammen mit einer Schockwelle aus dem Krater und kurz darauf erhebt sich - so tief grummelnd, dass der Grund davon erbebt – Magmar der Weltenfresser. Das Schicksal von Riedenberg liegt nun in deinen Händen.";
                }

                break;
            default:
                break;
        }

        GameObject.Find("StoryTitle").GetComponent<Text>().text = title;
        GameObject.Find("StoryText").GetComponent<Text>().text = text;
    }

}
