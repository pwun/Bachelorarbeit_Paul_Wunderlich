using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1 : MonoBehaviour {
    Exercises e;

    Vector3 left = new Vector3(-1, 0, 0);

    Vector3 spawnBg = new Vector3(320, 0, 0);
    int Bg_minx = -360;
    float Bg_speed = 20.0f;

    float speed = 120.0f;

    Text Question;
    Text Answer1;
    Text Answer2;
    Text Answer3;
    Text[] AnswerList;
    Text ExerciseCounter;
    Rigidbody2D Answers;
    Rigidbody2D Bg;
    public GameObject Enemy;
    public GameObject Obstacle;
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

    // Use this for initialization
    void Start () {
        e = GetComponent<Exercises>();
        e.GetTrainExercises("e", Game.current.hero.ClassLevel, 2, Game.current.hero.Level);

        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();
        AnswerList = new  Text[] {Answer1, Answer2, Answer3};
        ExerciseCounter = GameObject.Find("Counter").GetComponent<Text>();

        Answers = GameObject.Find("Answers").GetComponent<Rigidbody2D>();
		//Answers.transform.position =  new Vector3(spawn_x, spawn_y, 0);
        Bg = GameObject.Find("Bg").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        PlayerScript = Player.GetComponent<Mini1_Player>();

        CorrectCounter = 0;
        IncorrectCounter = 0;
        Lifes = 3;
    }

    void Update()
    {
        if (Bg.transform.position.x < Bg_minx) Bg.transform.position = spawnBg;
        if (Answers.transform.position.x < -680) ResetAnswer();
    }

    public void EnemySpawn()
    {
        int noEnemies = Random.RandomRange(1, 4);
        for(int i = 0; i < noEnemies; i++)
        {
            Debug.Log("Create new Enemy");
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x+ 250 + i*200, spawn_y - row_gap * spawnRow, 0);
            GameObject e = (GameObject)Instantiate(Enemy, EnemySpawnPos, transform.rotation);
            e.tag = "Enemy";
        }
        if(noEnemies <= 2)
        {
            int spawnRow = Random.RandomRange(0, 3);
            Vector3 EnemySpawnPos = new Vector3(spawn_x+400 + noEnemies * 172, spawn_y - 20 - row_gap * spawnRow, 0);
            GameObject e = (GameObject)Instantiate(Obstacle, EnemySpawnPos, transform.rotation);
            e.tag = "Obstacle";
        }
        int spawnRow2 = Random.RandomRange(0, 3);
        Vector3 EnemySpawnPos2 = new Vector3(spawn_x+100 + noEnemies * 167, spawn_y - 20 - row_gap * spawnRow2, 0);
        GameObject e2 = (GameObject)Instantiate(Obstacle, EnemySpawnPos2, transform.rotation);
        e2.tag = "Obstacle";

    }

    public void SafeAndQuit()
    {
        Game.current.hero.AddXp(xp);
        SaveLoad.Save();
        SceneManager.LoadScene("Main");
    }

    //spawn_x answer_y
    void ResetAnswer()
    {
        Debug.Log("AnswerY:" + Answers.transform.position.y);
        Answers.transform.position = new Vector3(spawn_x, answer_y, 0);
        Answer1.enabled = true;
        Answer2.enabled = true;
        Answer3.enabled = true;
        Answer1.color = Color.white;
        Answer2.color = Color.white;
        Answer3.color = Color.white;
        if (e.nrExercise < e.nrExerciseMax - 1) EnemySpawn();
        updateUi();
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

    void EndGame()
    {
        Answers.velocity = Vector2.zero;
        Bg.velocity = Vector2.zero;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        Answer1.text= Answer2.text = Answer3.text = Question.text = "";
        int multiply = Lifes + 1;
        xp = CorrectCounter * (multiply);
        GameObject.Find("RewardText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Antworten richtig beantwortet" + System.Environment.NewLine +
            "und " + (Lifes) + " Leben übrig." + System.Environment.NewLine + "Dafür erhältst du " + xp + "XP";
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().enabled = true;
        GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = true;
		GameObject.Find("SaveAndQuitButton").GetComponent<Button>().onClick.AddListener(() => { GameObject.Find("SaveAndQuitButton").GetComponent<Button>().interactable = false; });
        GameObject.Find("Endscreen").transform.localScale = new Vector3(1, 1, 1);
    }

    void updateUi()
    {
        Question.text = e.current_question;
        Answer1.text = e.current_answer1;
        Answer2.text = e.current_answer2;
        Answer3.text = e.current_answer3;
        ExerciseCounter.text = e.nrExercise + "/" + e.nrExerciseMax;
    }

    public void Answer(int rowNr)
    {
        CheckAnswer(AnswerList[rowNr-1].text);
        if (!e.NextQuestion()) EndGame();
    }

    void CheckAnswer(string text)
    {
        if (e.current_answer.Equals(text)) CorrectAnswer();
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
