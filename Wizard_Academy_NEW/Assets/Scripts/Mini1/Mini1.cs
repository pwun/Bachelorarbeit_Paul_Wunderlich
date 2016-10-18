using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1 : MonoBehaviour {
    Exercises e;
    UserData data;

    Vector3 left = new Vector3(-1, 0, 0);

    Vector3 spawnBg = new Vector3(1000, 384, 0);
    int Bg_minx = -50;
    float Bg_speed = 20.0f;

    float speed = 120.0f;

    Text Question;
    Text Answer1;
    Text Answer2;
    Text Answer3;
    Text ExerciseCounter;
    Rigidbody2D Answers;
    Rigidbody2D Bg;
    public GameObject Enemy;
    public GameObject Obstacle;
    Rigidbody2D Player;
    Mini1_Player PlayerScript;

    int CorrectCounter;
    int IncorrectCounter;

    int min_x = 0;
    int max_x = 400;
    int spawn_x = 1500;
	int spawn_y = 350;
    int row_gap = 100;
    int player_start_x = -350;
    int Lifes;
    public Sprite hearts_inactive;
    public Sprite hearts_active;
    int xp = 0;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        e = GetComponent<Exercises>();
        e.GetTrainExercises("e", data.class_level, 2, data.level);

        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();
        ExerciseCounter = GameObject.Find("Counter").GetComponent<Text>();

        Answers = GameObject.Find("Answers").GetComponent<Rigidbody2D>();
		Answers.transform.position =  new Vector3(spawn_x, spawn_y, 0);
        Bg = GameObject.Find("Bg").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        PlayerScript = Player.GetComponent<Mini1_Player>();

        CorrectCounter = 0;
        IncorrectCounter = 0;
        Lifes = 3;
    }


    // Update is called once per frame
    void Update()
    {
        if (Answers.transform.position.x < min_x)
        {
            Debug.Log("Nächste Frage bitte!");
            if (!e.NextQuestion())
            {
                EndGame();
            }
            updateUi();
            ResetAnswer();
        }
        if (Bg.transform.position.x < Bg_minx)
        {
            Bg.transform.position = spawnBg;
        }
    }

    public void EnemySpawn()
    {
        int noEnemies = Random.RandomRange(1, 4);
        for(int i = 0; i < noEnemies; i++)
        {
            Debug.Log("Create new Enemy");
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(1000 + i*200, spawn_y - row_gap * spawnRow, 0);
            GameObject e = (GameObject)Instantiate(Enemy, EnemySpawnPos, transform.rotation);
            e.tag = "Enemy";
        }
        if(noEnemies <= 2)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(1025 + noEnemies * 112, spawn_y - row_gap * spawnRow, 0);
            GameObject e = (GameObject)Instantiate(Obstacle, EnemySpawnPos, transform.rotation);
            e.tag = "Obstacle";
        }
        int spawnRow2 = Random.RandomRange(0, 3);
        Vector3 EnemySpawnPos2 = new Vector3(1225 + noEnemies * 117, spawn_y - row_gap * spawnRow2, 0);
        GameObject e2 = (GameObject)Instantiate(Obstacle, EnemySpawnPos2, transform.rotation);
        e2.tag = "Obstacle";

    }

    public void SafeAndQuit()
    {
        data.addXp(xp);
        data.Save("Main");
    }

    public void LoseLife()
    {
        Lifes--;
        if(Lifes > 0)
        {
            PlayerScript.LoseLife();
            StartCoroutine(DeactivateHeart());
        }
        else
        {
            PlayerScript.Kill();
            StartCoroutine(KillHearts());
        }
        
    }

    void ResetAnswer()
    {
        Answers.transform.position = new Vector3(spawn_x, spawn_y, 0);
        Answer1.enabled = true;
        Answer2.enabled = true;
        Answer3.enabled = true;
        Answer1.color = Color.white;
        Answer2.color = Color.white;
        Answer3.color = Color.white;
    }

    public void Begin() {
        e.StartExercise();
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
        updateUi();
        PlayerScript.StartAnimation();
        Answers.velocity = left * speed;
        Bg.velocity = left * Bg_speed;
    }

    void updateUi()
    {
        Question.text = e.current_question;
        Answer1.text = e.current_answer1;
        Answer2.text = e.current_answer2;
        Answer3.text = e.current_answer3;
    }

    public void HitQuestion(int rowNr)
    {
        switch (rowNr)
        {
            case 1:
                CheckAnswer(Answer1.text);
                break;
            case 2:
                CheckAnswer(Answer2.text);
                break;
            case 3:
                CheckAnswer(Answer3.text);
                break;
        }
    }

    void CheckAnswer(string text)
    {
        if(e.nrExercise<e.nrExerciseMax-1) EnemySpawn();
        Debug.Log("Correct answer:" + e.current_answer);
        Debug.Log("Submitted answer:" + text);
        if (e.current_answer.Equals(text))
        {
            Debug.Log("Richtige Antwort!");
            PlayerScript.Attack();
            StartCoroutine(DeactivateAnswer());
        }
        else
        {
            Debug.Log("Falsche Antwort!");
            switch (Lifes)
            {
                case 1:
                    Lifes--;
                    PlayerScript.Kill();
                    StartCoroutine(KillHearts());
                    break;
                default :
                    Lifes--;
                    PlayerScript.LoseLife();
                    StartCoroutine(DeactivateHeart());
                    StartCoroutine(ColorAnswers());
                    break;
            }
        }
        ExerciseCounter.text = e.nrExercise + "/" + e.nrExerciseMax;
    }

    IEnumerator DeactivateHeart()
    {
        string heartName = "Life" + (Lifes+1);
        yield return new WaitForSeconds(1);
        GameObject.Find(heartName).GetComponent<SpriteRenderer>().sprite = hearts_inactive;
    }

    IEnumerator ColorAnswers()
    {
        yield return new WaitForSeconds(1);
        Answer1.color = Color.red;
        Answer2.color = Color.red;
        Answer3.color = Color.red;
    }

    public IEnumerator KillHearts()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Life1").GetComponent<SpriteRenderer>().sprite = hearts_inactive;
        Answer1.color = Color.red;
        Answer2.color = Color.red;
        Answer3.color = Color.red;
        Answers.velocity = Vector2.zero;
        Bg.velocity = Vector2.zero;
        EndGame();
    }

    void EndGame()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        GameObject.Destroy(enemy);
        enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject enemy in enemies)
        GameObject.Destroy(enemy);
        Destroy(Answer1);
        Destroy(Answer2);
        Destroy(Answer3);
        Question.text = "";
        int multiply = Lifes + 1;
        xp = CorrectCounter*(multiply);
        GameObject.Find("RewardText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Antworten richtig beantwortet" + System.Environment.NewLine +
            "und " + (Lifes) + " Leben übrig." + System.Environment.NewLine + "Dafür erhältst du " + xp + "XP";
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().enabled = true;
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = true;
        GameObject.Find("Endscreen").transform.localScale= new Vector3(1, 1, 1);
    }

    IEnumerator DeactivateAnswer()
    {
        yield return new WaitForSeconds(1);
        CorrectCounter++;
        Answer1.enabled = false;
        Answer2.enabled = false;
        Answer3.enabled = false;
    }

}
