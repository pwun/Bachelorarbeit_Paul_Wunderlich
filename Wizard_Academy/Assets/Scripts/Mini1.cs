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

    Vector3 left;
    float speed = 80.0f;

    Rigidbody2D Player;
    float player_x;
    float answers_x;


    int CorrectCounter;
    int IncorrectCounter;

    int min_x = -300;
    int max_x = 400;
    int spawn_x = 400;
    int player_start_x = -350;

    // Use this for initialization
    void Start () {

        
        left = new Vector3(-1, 0, 0);

        data = GameObject.Find("User_Data").GetComponent<UserData>();
        e = GetComponent<Exercises>();
        e.GetTrainExercises("e", data.getClass(), 2, data.getLevel());

        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();
        Answers = GameObject.Find("Answers").GetComponent<Rigidbody2D>();

        CorrectCounter = 0;
        IncorrectCounter = 0;

        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        //player_x = Player.transform.position.x;
        //answers_x = Answers.transform.position.x;
        //Player.transform.position.Set(-350, Player.transform.position.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(Answers.transform.position.x < min_x)
        {
            Debug.Log("Nächste Frage bitte!");
            Answers.transform.position.Set(spawn_x, 0, 0);
        }
    }

    public void Begin() {
        e.StartExercise();
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
        updateUi();
        Answers.velocity = left * speed;
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
        }
        else
        {
            Debug.Log("Falsche Antwort!");
            Player.GetComponent<Mini1_Player>().Kill();
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
