using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1 : MonoBehaviour {

    Exercises e;
    UserData data;

    Text Question;
    Text Answer1;
    Text Answer2;
    Text Answer3;
    Rigidbody2D Answers;
    Rigidbody2D Bg;

    Vector3 left;
    float speed = 120.0f;
    float slow = 15.0f;

    Rigidbody2D Player;
    Mini1_Player PlayerScript;
    float player_x;
    float answers_x;


    int CorrectCounter;
    int IncorrectCounter;

    int min_x = 0;
    int max_x = 400;
    int spawn_x = 1500;
	int spawn_y = 350;
    int player_start_x = -350;
    int Lifes;
    public Sprite hearts_inactive;
    public Sprite hearts_active;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        e = GetComponent<Exercises>();
        e.GetTrainExercises("e", data.getClass(), 2, data.getLevel());

        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();

        Answers = GameObject.Find("Answers").GetComponent<Rigidbody2D>();
		Answers.transform.position =  new Vector3(spawn_x, spawn_y, 0);
        Bg = GameObject.Find("Bg").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        PlayerScript = Player.GetComponent<Mini1_Player>();

        CorrectCounter = 0;
        IncorrectCounter = 0;
        Lifes = 3;
        left = new Vector3(-1, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(Answers.transform.position.x < min_x)
        {
            Debug.Log("Nächste Frage bitte!");
			e.NextQuestion ();
			updateUi ();
            ResetAnswer();
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
        Answers.velocity = left * speed;
        Bg.velocity = left * slow;
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
        Debug.Log("Correct answer:" + e.current_answer);
        Debug.Log("Submitted answer:" + text);
        if (e.current_answer.Equals(text))
        {
            Debug.Log("Richtige Antwort!");
            PlayerScript.Attack();
			CorrectCounter++;
            Answer1.enabled = false;
            Answer2.enabled = false;
            Answer3.enabled = false;
        }
        else
        {
            Debug.Log("Falsche Antwort!");
            Answer1.color = Color.red;
            Answer2.color = Color.red;
            Answer3.color = Color.red;
            switch (Lifes)
            {
                case 1:
                    PlayerScript.Kill();
                    GameObject.Find("Life1").GetComponent<SpriteRenderer>().sprite = hearts_inactive;
                    Answers.velocity = Vector2.zero;
                    Bg.velocity = Vector2.zero;
                    //Pause Game, Game Over
                    break;
                case 2:
                    Lifes--;
                    PlayerScript.LoseLife();
                    GameObject.Find("Life2").GetComponent<SpriteRenderer>().sprite = hearts_inactive;
                    break;
                case 3:
                    Lifes--;
                    PlayerScript.LoseLife();
                    GameObject.Find("Life3").GetComponent<SpriteRenderer>().sprite = hearts_inactive;
                    break;
            }
        }
    }

    /*
        // Require the rocket to be a rigidbody.
        // This way we the user can not assign a prefab without rigidbody
        public Rigidbody rocket;
        public float speed = 10f;

        void FireRocket () {
            Rigidbody rocketClone = (Rigidbody) Instantiate(rocket, transform.position, transform.rotation);
            rocketClone.velocity = transform.forward * speed;
    
            // You can also acccess other components / scripts of the clone
            rocketClone.GetComponent<MyRocketScript>().DoSomething();
        }

        // Calls the fire method when holding down ctrl or mouse
        void Update () {
            if (Input.GetButtonDown("Fire1")) {
                FireRocket();
            }
        }

     */
}
