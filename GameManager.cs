using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public void Start()
    {
        newInstruction();
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            //Gauche
            if (Input.GetKey(KeyCode.LeftArrow) && isAlive)
            {
                checkRespond(0);
            }

            //Haut
            if (Input.GetKey(KeyCode.UpArrow) && isAlive)
            {
                checkRespond(1);
            }

            //Droite
            if (Input.GetKey(KeyCode.RightArrow) && isAlive)
            {
                checkRespond(2);
            }

            //Bas
            if (Input.GetKey(KeyCode.DownArrow) && isAlive)
            {
                checkRespond(3);
            }

            //Espac
            if(Input.GetKey(KeyCode.Space) && !isAlive)
            {
                SceneManager.LoadScene(0);
            }
        }

        //Animation du timer qui descent
        if(isTimerLaunched)
        {
            time += Time.deltaTime;
            timerBar.value = 1-time/timeLimit;
        }

        //Si le timer a atteint la limite
        if (time >= timeLimit) gameOver();

    }

    //Verifier si on as bien répondu
    private void checkRespond(int idClicked)
    {
        bool founded = false;
        for (int i = 0; i < currentQuestion.getCorrectSide().Length; i++)
        {
            if (idClicked == currentQuestion.getCorrectSide()[i]) founded = true;
        }

        //Si la reponse été correcte
        if (founded)
        {
            win();
        }else
        {
            gameOver();
        }
    }

    //Charger une nouvelle question
    private void newInstruction()
    {
        //Si on as atteint la fin du tutoriel
        if (currentQuestionId == tqdb.getSize() - 1) isInTutorialMode = false;

        //Trouver un nouveau numero et charger la question
        int last = currentQuestionId;
        if (isInTutorialMode)
        {
            currentQuestionId++;
            currentQuestion = tqdb.getQuestionById(currentQuestionId);
        }
        else
        {
            while (currentQuestionId == last) currentQuestionId = Random.Range(0, qdb.getSize());
            currentQuestion = qdb.getQuestionById(currentQuestionId);
        }

        //Afficher la question
        instructionText.text = currentQuestion.getQuestionText();

        //Mettre les couleurs sur les buzzers
        for(int i = 0; i < buzzers.Length; i++)
        {
            buzzers[i].gameObject.GetComponent<Image>().color = currentQuestion.getColorById(i);
        }

    }


    //Quand on a bien repondu
    private void win()
    {
        winAnimation();
        newInstruction();
        time = 0f;
    }

    //Quand on as mal repondu
    private void gameOver()
    {
        isAlive = false;
        isTimerLaunched = false;
        StartCoroutine(gameOverAnimation());
    }


    //Animation de GameOver
    IEnumerator gameOverAnimation()
    {
        instructionText.text = "Perdu !!";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < GameObjectsFalling.Length; i++)
        {
            GameObjectsFalling[i].GetComponent<Rigidbody2D>().isKinematic = false;
        }
        yield return new WaitForSeconds(2f);
        gameOverPanel.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        highScorePanel.GetComponent<Animator>().enabled = true;

    }
    
    //Animation de Victoire
    private void winAnimation()
    {
        for(int i = 0; i < particulSystemsWin.Length;i++)
        {
            particulSystemsWin[i].Emit(500);
        }
    } 

    public Text instructionText;
    public GameObject gameOverPanel;
    public GameObject highScorePanel;
    public Slider timerBar;
    public GameObject[] GameObjectsFalling;
    public ParticleSystem[] particulSystemsWin;

    public GameObject[] buzzers;
    private int currentQuestionId = -1;
    private bool isAlive = true;
    private bool isTimerLaunched = true;
    private bool isInTutorialMode = true;
    private float timeLimit = 10f;
    private float time = 0f;
    private int currentScore = 0;
    private Question currentQuestion;
    QuestionDataBase qdb = new QuestionDataBase();
    TutorialQuestionDataBase tqdb = new TutorialQuestionDataBase();
}