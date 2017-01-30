using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    Text Question;
    Text Task;
    Text Result;
    InputField AnswerInput;
    Text Timer;

    public AudioSource Audio_Endscreen;

    Button SubmitButton;
    Button NextButton;

    int CorrectCounter;
    int IncorrectCounter;
    public int eNr;
    public bool animRunning = false;
    int bossHearts = 20;
    int playerHearts = 10;

    GameObject player;
    GameObject boss;
    GameObject bg;

    string bossName ="BOSS";
    string locationName = "NEUER ORT";
    string itemName = "NEUES ITEM";

    float time = 1200.00f;

    public bool rightAnswer = true;

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject boss4;


    bool running = false;

    Entry[] e1 = new Entry[0];
    Entry[] e2 = new Entry[0];
    Entry[] e = new Entry[0];

    void Start()
    {
        player = GameObject.Find("Player");
        Timer = (Text)GameObject.Find("Timer").GetComponent<Text>();
        SaveLoad.Load();
        chooseBg();
        switch (Game.current.hero.Level)
        {
            case 3:
                bossName = "Forstos der Sprößling";
                locationName = "die Sümpfe von Thales";
                itemName = "die Robe des Waldmönchs";
                boss = Instantiate(boss1, new Vector3(960, -282, 90), new Quaternion(0, 0, 0,0));
                break;
            case 6:
                bossName = "Swampus der Hinterlistige";
                locationName = "die Gipfel von Euklid";
                itemName = "das Kettenhemd des Kriegers";
                boss = Instantiate(boss2, new Vector3(960, -282, 90), new Quaternion(0, 0, 0, 0));
                break;
            case 9:
                bossName = "Freezos der Kaltblütige";
                locationName = "den Aschekamm";
                itemName = "die Plattenrüstung des Ritters";
                boss = Instantiate(boss3, new Vector3(960, -282, 90), new Quaternion(0, 0, 0, 0));
                break;
            case 12:
                bossName = "Magmar der Weltenfresser";
                locationName = "alle Regionen";
                itemName = "das verzierte Kettenhemd eines Helden";
                boss = Instantiate(boss4, new Vector3(960, -282, 90), new Quaternion(0, 0, 0, 0));
                break;
            default:
                bossName = "Forstos der Sprößling";
                locationName = "die Sümpfe von Thales";
                itemName = "nichts";
                boss = Instantiate(boss1, new Vector3(960, -282, 90), new Quaternion(0, 0, 0, 0));
                break;
        }
        GameObject.Find("Title").GetComponent<Text>().text = bossName;
        EnglishGenerator EnglishGen = new EnglishGenerator();
        MathGenerator MathGen = new MathGenerator();
        CorrectCounter = 0;
        IncorrectCounter = 0;
        GameObject.Find("Name_Display").GetComponent<Text>().text = Game.current.hero.Name;
        e1 = EnglishGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 3);
        e2 = MathGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 3);
        while (e1.Length < 2 || e2.Length < 2)
        {
            //Wait
        }
        List<Entry> ePuffer = new List<Entry>();
        ePuffer.AddRange(e1);
        ePuffer.AddRange(e2);
        e = shuffle(ePuffer.ToArray());
        Debug.Log("Done! " + e.Length + " Entries received");
        eNr = 0;
        initUi();
    }

    void chooseBg() {
        switch (Game.current.hero.Level)
        {
            case 4:
            case 5:
            case 6:
                GameObject.Find("background").SetActive(false);
                GameObject.Find("background3").SetActive(false);
                GameObject.Find("background4").SetActive(false);
                GameObject.Find("background2").SetActive(true);
                bg = GameObject.Find("background2");
                break;
            case 7:
            case 8:
            case 9:
                GameObject.Find("background").SetActive(false);
                GameObject.Find("background2").SetActive(false);
                GameObject.Find("background4").SetActive(false);
                GameObject.Find("background3").SetActive(true);
                bg = GameObject.Find("background3");
                break;
            case 10:
            case 11:
            case 12:
                GameObject.Find("background").SetActive(false);
                GameObject.Find("background2").SetActive(false);
                GameObject.Find("background3").SetActive(false);
                GameObject.Find("background4").SetActive(true);
                bg = GameObject.Find("background4");
                break;
            default:
                GameObject.Find("background2").SetActive(false);
                GameObject.Find("background3").SetActive(false);
                GameObject.Find("background4").SetActive(false);
                GameObject.Find("background").SetActive(true);
                bg = GameObject.Find("background");
                break;
        }
        bg.GetComponent<scroll>().speed = 0;
    }

    private Entry[] shuffle(Entry[] arr) {
        //Knuth shuffle algorithm
        for (int i = 0; i < arr.Length; i++)
        {
            Entry tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
        return arr;
    }

    void initUi()
    {
        Question = GameObject.Find("Question").GetComponent<Text>();
        Task = GameObject.Find("Task").GetComponent<Text>();
        Result = GameObject.Find("Result").GetComponent<Text>();
        AnswerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        SubmitButton = GameObject.Find("Submit_Question").GetComponent<Button>();
        SubmitButton.onClick.AddListener(() => {
            AnswerQuestion();
        });
        NextButton = GameObject.Find("Next_Question").GetComponent<Button>();
        NextButton.onClick.AddListener(() => {
            NextQuestion();
        });
        AnswerInput.Select();
        Log.LogEntry("Boss start");
        refreshUi();
    }
    void refreshUi()
    {
        time -= Time.deltaTime;
        int min = (int)(time / 60);
        Timer.text = min+":"+(int)(time-min*60) + "Min";
        if (time <= 0) {
            PlayerDie();
        }
        Question.text = e[eNr].question;
        Task.text = e[eNr].task;
    }
    void Update()
    {
        if (running) { refreshUi(); }
        if (time < 180f) { Timer.color = Color.yellow; }
        if (time < 60f) { Timer.color = Color.red; }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (running)
            {
                if (SubmitButton.enabled) { AnswerQuestion(); }
                else { NextQuestion(); }
            }
            else {
                if (CorrectCounter > 0 || IncorrectCounter > 0) { }
                else { Begin(); }
            }
        }
    }
    public void AnswerQuestion()
    {
        GameObject.Find("QuestionPanel").transform.localScale = new Vector3(0, 0, 0);
        animRunning = true;
        player.GetComponent<Boss_Player>().StartWalking();
        //Leerzeichen weg, , durch .
        string r1 = AnswerInput.text;
        string r2 = e[eNr].answer;

        r1 = r1.Replace(" ", "");
        r1 = r1.Replace(',', '.');
        r1 = r1.Replace("+", "");
        r1 = r1.Replace("*", "");
        if (r1.StartsWith("1x")) { r1 = r1.Replace("1x", "x"); }
        r2 = r2.Replace(" ", "");
        r2 = r2.Replace(',', '.');
        r2 = r2.Replace("+", "");
        r2 = r2.Replace("*", "");
        if (r2.StartsWith("1x")) { r2 = r2.Replace("1x", "x"); }
        if (r1.Equals(r2))
        {
            Result.text = "Richtig!";
            rightAnswer = true;
            CorrectCounter++;
        }
        else
        {
            rightAnswer = false;
            Result.text = "Falsch! Richtige Antwort: " + e[eNr].answer;
            IncorrectCounter++;
        }
        //switch button
        NextButton.enabled = true;
        SubmitButton.enabled = false;
        SubmitButton.transform.localScale = new Vector3(0, 0, 0);
        refreshUi();
        //WICHTIG!!!!!
        //minimize UI
        //Play animation
        //maximize ui
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
    public void BossHurt() {
        if (bossHearts - CorrectCounter > 0) {
            GameObject.Find("BossLife" + (bossHearts - CorrectCounter +1)).SetActive(false);
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetTrigger("Hurt");
            boss.GetComponent<BossEnemy>().Audio_Hurt.Play();
        }
        else {
            GameObject.Find("BossLife" + (bossHearts - CorrectCounter + 1)).SetActive(false);
            BossDie(); }
    }
    public void PlayerHurt() {
        if (playerHearts - IncorrectCounter > 0)
        {
            GameObject.Find("Life" + (playerHearts - IncorrectCounter +1)).SetActive(false);
        }
        else {
            GameObject.Find("Life" + (playerHearts - IncorrectCounter + 1)).SetActive(false);
            PlayerDie(); }
    }
    void BossDie() {
        //Play Die Animation
        boss.GetComponent<BossEnemy>().Audio_Die.Play();
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetBool("Idle", false);
        Close();
    }
    void PlayerDie() {
        //Play Die Animation
        Close();
    }
    public void NextQuestion()
    {
        if (!animRunning) {
            SubmitButton.enabled = true;
            NextButton.enabled = false;
            Result.text = "";
            AnswerInput.text = "";
            AnswerInput.Select();
            if (eNr + 1 >= e.Length)
            {
                //End of Test
                if (CorrectCounter + IncorrectCounter != e.Length)
                {
                    Debug.Log("Error giving XP: RightAnswers:" + CorrectCounter + " + WrongAnswers:" + IncorrectCounter + " don't add up to NrAnswers:" + e.Length);
                }
                else
                {
                    Close();
                }
            }
            else
            {
                eNr++;
                refreshUi();
            }
            SubmitButton.transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
    void Close()
    {
        Audio_Endscreen.Play();
        running = false;
        Destroy(GameObject.Find("QuestionPanel"));
        GameObject.Find("Endscreen").transform.localScale = new Vector3(1, 1, 1);
        if (playerHearts - IncorrectCounter > 0 && bossHearts - CorrectCounter <= 0) {
            GameObject.Find("RewardText").GetComponent<Text>().text = "Du hast "+bossName+" besiegt und kannst nun in "+ locationName + System.Environment.NewLine +
            "Als Belohnung bekommst du "+itemName;
            Game.current.hero.LevelUp();
        }
        else {
            GameObject.Find("RewardText").GetComponent<Text>().text = bossName+" hat dich besiegt! Übe weiter im Trainingsmodus, oder versuche es gleich nochmal. Du bekommst keine Erfahrung, bis "+bossName+" besiegt ist.";
        }

        SaveLoad.Save();
        int answer = -1;
        answer = Log.LogEntry("Boss at Lvl " + Game.current.hero.Level + " " + CorrectCounter + "/" + e.Length + " richtig");
        while (answer < 0)
        { //Wait
        }
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().onClick.AddListener(() => { Save(); });
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = true;
    }
    void Save()
    {
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = false;
        SceneManager.LoadScene("Main");
    }

    public void Begin()
    {
        Destroy(GameObject.Find("Start"));
        time = time += Time.deltaTime;
        running = true;
        Debug.Log("Game is running");
    }
}
