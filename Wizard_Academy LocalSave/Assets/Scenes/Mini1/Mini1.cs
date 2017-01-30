using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1 : MonoBehaviour
{
    public int dropRarity = 30;//1/30

    Vector3 left = new Vector3(-1, 0, 0);

    Vector3 spawnBg = new Vector3(320, 0, 0);
    int Bg_minx = -360;
    float Bg_speed = 20.0f;

    float speed = 120.0f;

    public AudioSource Audio_Endscreen;

    Text Task;
    Text Question;
    Text Answer1;
    Text Answer2;
    Text Answer3;
    Text[] AnswerList;
    Text ExerciseCounter;
    Rigidbody2D Answers;
    Rigidbody2D Bg;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Obstacle;
    public GameObject Loot;
    Rigidbody2D Player;
    Mini1_Player PlayerScript;

    int CorrectCounter;
    int IncorrectCounter;

    int answer_y = -120;
    int spawn_x = 1500;
    int spawn_y = -70;
    int row_gap = 190;
    int Lifes;
    public Sprite hearts_inactive;
    public Sprite hearts_active;
    int xp = 0;

    Entry[] e = new Entry[0];
    EnglishGenerator EnglishGen;
    MathGenerator MathGen;
    int eNr;
    bool ready = false;

    GameObject bg;

    // Use this for initialization
    void Start()
    {
        SaveLoad.Load();
        switch (Game.current.hero.Level) {
            case 1:
            case 2:
            case 3:
                GameObject.Find("background2").SetActive(false);
                GameObject.Find("background3").SetActive(false);
                GameObject.Find("background4").SetActive(false);
                GameObject.Find("background").SetActive(true);
                bg = GameObject.Find("background");
                break;
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
            default://over lvl 12 -> random bg
                switch (Random.Range(0, 4)) {
                    case 0:
                        GameObject.Find("background2").SetActive(false);
                        GameObject.Find("background3").SetActive(false);
                        GameObject.Find("background4").SetActive(false);
                        GameObject.Find("background").SetActive(true);
                        bg = GameObject.Find("background");
                        break;
                        break;
                    case 1:
                        GameObject.Find("background").SetActive(false);
                        GameObject.Find("background3").SetActive(false);
                        GameObject.Find("background4").SetActive(false);
                        GameObject.Find("background2").SetActive(true);
                        bg = GameObject.Find("background2");
                        break;
                        break;
                    case 2:
                        GameObject.Find("background").SetActive(false);
                        GameObject.Find("background2").SetActive(false);
                        GameObject.Find("background4").SetActive(false);
                        GameObject.Find("background3").SetActive(true);
                        bg = GameObject.Find("background3");
                        break;
                    case 3:
                        GameObject.Find("background").SetActive(false);
                        GameObject.Find("background2").SetActive(false);
                        GameObject.Find("background3").SetActive(false);
                        GameObject.Find("background4").SetActive(true);
                        bg = GameObject.Find("background4");
                        break;
                }
                break;
                
        }
        bg.GetComponent<scroll>().speed = 0;
        Task = GameObject.Find("Task").GetComponent<Text>();
        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();
        AnswerList = new Text[] { Answer1, Answer2, Answer3 };
        ExerciseCounter = GameObject.Find("Counter").GetComponent<Text>();
        Answers = GameObject.Find("Answers").GetComponent<Rigidbody2D>();
        //Answers.transform.position =  new Vector3(spawn_x, spawn_y, 0);
        //Bg = GameObject.Find("Bg").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        PlayerScript = Player.GetComponent<Mini1_Player>();

        EnglishGen = new EnglishGenerator();
        MathGen = new MathGenerator();
        if (Game.current.hero.Subject.Equals("e"))
        {
            e = EnglishGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 2);
        }
        else
        {
            e = MathGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 2);
        }

        CorrectCounter = 0;
        IncorrectCounter = 0;
        while (e.Length <= 2) {
            //Wait
            Debug.Log("Loading...");
        }
        Debug.Log("Done! Loaded "+e.Length+" questions");
        ready = true;
        Log.LogEntry("Mini1 start");
        eNr = 0;
        Lifes = 3;
    }

    void Update()
    {
        //if (Bg.transform.position.x < Bg_minx) Bg.transform.position = spawnBg;
        if (Answers.transform.position.x < -680) ResetAnswer();
    }

    public void EnemySpawn() {
        if (Game.current.hero.Level > 3) {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level-1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy2, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 4)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy2, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 5)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy2, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 6)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy3, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 7)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy3, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 8)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy3, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 9)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy4, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 10)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy4, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        if (Game.current.hero.Level > 11)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + (Game.current.hero.Level - 1) * Random.Range(200, 400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy4, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        for (int i = 0; i < eNr+2; i++) {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 250 + i * Random.Range(200,400), spawn_y - row_gap * spawnRow, 0);
            GameObject enemy = (GameObject)Instantiate(Enemy, EnemySpawnPos, transform.rotation);
            enemy.tag = "Enemy";
        }
        for (int i = 0; i < Random.Range(1, 3);i++) {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 100 + (i+1)* Random.Range(200,600), spawn_y - 20 - row_gap * spawnRow, 0);
            GameObject obstacle = (GameObject)Instantiate(Obstacle, EnemySpawnPos, transform.rotation);
            obstacle.tag = "Obstacle";
        }
        DropLoot();
    }

    private void DropLoot() {
        if (Random.Range(0, dropRarity) == 0) {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x + 100 + Random.Range(300, 600), spawn_y - 20 - row_gap * spawnRow, 0);
            GameObject obstacle = (GameObject)Instantiate(Loot, EnemySpawnPos, transform.rotation);
            obstacle.tag = "Loot";
        }
    }

    public void SafeAndQuit()
    {
        Game.current.hero.AddXp(xp);
        if (Lifes == 3) { Game.current.hero.AddAchievement(0); }
        SaveLoad.Save();
        SceneManager.LoadScene("Main");
    }

    //spawn_x answer_y
    void ResetAnswer()
    {
        Answers.transform.position = new Vector3(spawn_x, answer_y, 0);
        Answer1.enabled = true;
        Answer2.enabled = true;
        Answer3.enabled = true;
        Answer1.color = Color.white;
        Answer2.color = Color.white;
        Answer3.color = Color.white;
        eNr++;
        if (eNr < e.Length - 1) EnemySpawn();
        updateUi();
    }

    public void Begin()
    {
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
        updateUi();
        PlayerScript.StartAnimation();
        Answers.velocity = left * speed;
        bg.GetComponent<scroll>().speed = 0.02f;
    }

    void EndGame()
    {
        Audio_Endscreen.Play();
        Destroy(Task);
        Answers.velocity = Vector2.zero;
        //Bg.velocity = Vector2.zero;
        bg.GetComponent<scroll>().speed = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        enemies = GameObject.FindGameObjectsWithTag("Loot");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        Answer1.text = Answer2.text = Answer3.text = Question.text = "";
        int multiply = Lifes + 1;
        xp = (CorrectCounter*(Game.current.hero.Level*2)) * (multiply);
        GameObject.Find("RewardText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Antworten richtig beantwortet" + System.Environment.NewLine +
            "und " + (Lifes) + " Leben übrig." + System.Environment.NewLine + "Dafür erhältst du " + xp + "XP";
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().enabled = true;
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = true;
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().onClick.AddListener(() => { GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = false; });
        GameObject.Find("Endscreen").transform.localScale = new Vector3(1, 1, 1);
        int answer = -1;
        answer = Log.LogEntry("Mini " + xp + "xp, " + CorrectCounter + "/" + e.Length + " richtig, Leben: "+Lifes);
        while (answer < 0)
        { //Wait
        }
    }

    void updateUi()
    {
        if (ready)
        {
            Task.text = e[eNr].task;
            Question.text = e[eNr].question;
            Answer1.text = e[eNr].answerPos[0];
            Answer2.text = e[eNr].answerPos[1];
            Answer3.text = e[eNr].answerPos[2];
            ExerciseCounter.text = (eNr) + "/" + e.Length;
        }
    }

    public void Answer(int rowNr)
    {
        CheckAnswer(AnswerList[rowNr - 1].text);
        if (eNr + 1 >= e.Length) EndGame();
    }

    void CheckAnswer(string text)
    {
        if (e[eNr].answer.Equals(text)) CorrectAnswer();
        else { Hurt(); StartCoroutine(ColorAnswers()); }
    }

    void CorrectAnswer()
    {
        Debug.Log("Richtige Antwort!");
        PlayerScript.Attack();
        CorrectCounter++;
        StartCoroutine(DeactivateAnswer());
    }

    public void Hurt()
    {
        Lifes--;
        if (Lifes > 0) PlayerScript.LoseLife();
        else
        {
            PlayerScript.Kill();
            EndGame();
        }
        StartCoroutine(LoseHeart(Lifes + 1));
    }

    IEnumerator LoseHeart(int nr)
    {
        string heartName = "Life" + nr;
        yield return new WaitForSeconds(0.5f);
        GameObject.Find(heartName).GetComponent<SpriteRenderer>().sprite = hearts_inactive;
    }

    IEnumerator ColorAnswers()
    {
        yield return new WaitForSeconds(0.5f);
        Answer1.color = Color.red;
        Answer2.color = Color.red;
        Answer3.color = Color.red;
    }

    IEnumerator DeactivateAnswer()
    {
        yield return new WaitForSeconds(0.5f);
        Answer1.enabled = false;
        Answer2.enabled = false;
        Answer3.enabled = false;
    }
}
