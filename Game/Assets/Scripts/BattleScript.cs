using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup battleScene;

    [SerializeField]
    private Text task;
    [SerializeField]
    private Text[] answers = new Text[4];

    [SerializeField]
    private Sprite[] enemyPicturesArray = new Sprite[6];
    [SerializeField]
    private Image enemyPicture;

    int correctKeyAnswer = 0;



    //ДЛЯ ПЕСНИ
    [SerializeField]
    AudioSource newSong;
    [SerializeField]
    AudioSource oldSong;

    private bool isEndBattle = false;

    public void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            enemy[i].GetComponent<GameObject>();
        }

        task.GetComponent<Text>();
        answers[0].GetComponent<Text>();
        answers[1].GetComponent<Text>();
        answers[2].GetComponent<Text>();
        answers[3].GetComponent<Text>();

        teleport.GetComponent<GameObject>();

        sentenceText.GetComponent<Text>();
        //nameText.GetComponent<Text>();
        dialogBar.GetComponent<CanvasGroup>();

        helperToDissap.GetComponent<GameObject>();
        dialog2Object.GetComponent<GameObject>();

        TheEnd.GetComponent<GameObject>();

        closeDialog3.GetComponent<GameObject>();

        newSong.GetComponent<AudioSource>();
        oldSong.GetComponent<AudioSource>();
    }

    public void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenCloseBattleScene();
            GenerateTask(0);
            SetEnemyImage(1);
        }
        */
        if ((Input.GetKeyDown(KeyCode.Alpha1) && battleScene.alpha == 1) ||
            (Input.GetKeyDown(KeyCode.Alpha2) && battleScene.alpha == 1) ||
            (Input.GetKeyDown(KeyCode.Alpha3) && battleScene.alpha == 1) ||
            (Input.GetKeyDown(KeyCode.Alpha4) && battleScene.alpha == 1))
        {
            if ((correctKeyAnswer == 1 && Input.GetKeyDown(KeyCode.Alpha1)) ||
                (correctKeyAnswer == 2 && Input.GetKeyDown(KeyCode.Alpha2)) ||
                (correctKeyAnswer == 3 && Input.GetKeyDown(KeyCode.Alpha3)) ||
                (correctKeyAnswer == 4 && Input.GetKeyDown(KeyCode.Alpha4)))
            {
                //Debug.Log("WIN");
                OpenCloseBattleScene();

                //enemy[NumberOfEnemy].GetComponent<GameObject>();
                enemy[NumberOfEnemy].transform.Translate(Vector2.left * 100);
                ShowWinLog();
                //ChangeMissionText(NumberOfEnemy + 1);
                //С ЗАДАНИЕМ ПОПОЗЖЕ РАЗБЕРУСЬ
                Invoke("ShowWinLog", 1.5f);
                if (!isEndBattle)
                {
                    ChangeMissionText(numberOfMissionText);
                    numberOfMissionText++;
                }
                else
                {
                    ChangeMissionText(8);
                }
                //ChangeMissionText(2);
            }
            else
            {
                //Debug.Log("Lose");
                OpenCloseBattleScene();
                HealthSystem.health -= 1;
                ShowHideLoseLog();
                Invoke("ShowHideLoseLog", 1.5f);
            }
        }
        if(isCloseDialog1 == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentences();
            }
        }
        if(isCloseDialog2 == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentencesForDialog2();
            }
        }
        if(isCloseDialog3 == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentencesForDialog3();
            }
        }
    }

    public void GenerateTask(int difficult)
    {
        /*
        task.GetComponent<Text>();
        answers[0].GetComponent<Text>();
        answers[1].GetComponent<Text>();
        answers[2].GetComponent<Text>();
        answers[3].GetComponent<Text>();
        */

        int firstOperand = 0;
        int secondOperand = 0;
        int operation = 0;

        int correctAnswer = 0;



        switch (difficult)
        {
            case 0:
                {
                    firstOperand = (int)Random.Range(1, 5);
                    secondOperand = (int)Random.Range(1, 5);
                    operation = (int)Random.Range(0, 4);
                    break;
                }
            case 1:
                {
                    firstOperand = (int)Random.Range(1, 10);
                    secondOperand = (int)Random.Range(1, 10);
                    operation = (int)Random.Range(0, 4);
                    break;
                }
            case 2:
                {
                    firstOperand = (int)Random.Range(10, 16);
                    secondOperand = (int)Random.Range(2, 4);
                    operation = (int)Random.Range(0, 4);
                    break;
                }
            case 3:
                {
                    firstOperand = (int)Random.Range(20, 52);
                    secondOperand = (int)Random.Range(2, 3);
                    operation = (int)Random.Range(1, 4);
                    break;
                }
            case 4:
                {
                    firstOperand = (int)Random.Range(5, 20);
                    secondOperand = (int)Random.Range(3, 6);
                    operation = (int)Random.Range(2, 4);
                    break;
                }
            case 5:
                {
                    firstOperand = (int)Random.Range(117, 218);
                    secondOperand = (int)Random.Range(2, 4);
                    operation = (int)Random.Range(2, 4);
                    break;
                }
        }

        switch (operation)
        {
            case 0:
                {
                    task.text = firstOperand.ToString() + " + " + secondOperand.ToString() + " = ?";
                    correctAnswer = firstOperand + secondOperand;
                    break;
                }
            case 1:
                {
                    task.text = firstOperand.ToString() + " - " + secondOperand.ToString() + " = ?";
                    correctAnswer = firstOperand - secondOperand;
                    break;
                }
            case 2:
                {
                    task.text = firstOperand.ToString() + " * " + secondOperand.ToString() + " = ?";
                    correctAnswer = firstOperand * secondOperand;
                    break;
                }
            case 3:
                {
                    int tempOperand = firstOperand * secondOperand;
                    task.text = tempOperand.ToString() + " / " + secondOperand.ToString() + " = ?";
                    correctAnswer = tempOperand / secondOperand;
                    break;
                }
        }

        switch ((int)Random.Range(0, 4))
        {
            case 0:
                {
                    answers[0].text = "1) " + correctAnswer.ToString();
                    answers[1].text = "2) " + (correctAnswer + 2).ToString();
                    answers[2].text = "3) " + (correctAnswer - 1).ToString();
                    answers[3].text = "4) " + (correctAnswer - 5).ToString();
                    correctKeyAnswer = 1;
                    break;
                }
            case 1:
                {
                    answers[0].text = "1) " + (correctAnswer - 3).ToString();
                    answers[1].text = "2) " + correctAnswer.ToString();
                    answers[2].text = "3) " + (correctAnswer + 1).ToString();
                    answers[3].text = "4) " + (correctAnswer + 2).ToString();
                    correctKeyAnswer = 2;
                    break;
                }
            case 2:
                {
                    answers[0].text = "1) " + (correctAnswer - 4).ToString();
                    answers[1].text = "2) " + (correctAnswer + 2).ToString();
                    answers[2].text = "3) " + correctAnswer.ToString();
                    answers[3].text = "4) " + (correctAnswer - 2).ToString();
                    correctKeyAnswer = 3;
                    break;
                }
            case 3:
                {
                    answers[0].text = "1) " + (correctAnswer - 5).ToString();
                    answers[1].text = "2) " + (correctAnswer - 3).ToString();
                    answers[2].text = "3) " + (correctAnswer + 7).ToString();
                    answers[3].text = "4) " + correctAnswer.ToString();
                    correctKeyAnswer = 4;
                    break;
                }
        }

    }

    public void OpenCloseBattleScene()
    {
        battleScene.alpha = battleScene.alpha == 0 ? 1 : 0;
        battleScene.blocksRaycasts = battleScene.blocksRaycasts == false ? true : false;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void SetEnemyImage(int numberOfImage)
    {
        enemyPicture.GetComponent<Image>().sprite = enemyPicturesArray[numberOfImage];
    }

    public void ButtonAnswerOne()
    {
        if (correctKeyAnswer == 1)
        {
            //Debug.Log("Win");
            OpenCloseBattleScene();
            ShowWinLog();
            //enemy[NumberOfEnemy].GetComponent<GameObject>();
            enemy[NumberOfEnemy].transform.Translate(Vector2.left * 100);
            Invoke("ShowWinLog", 1.5f);
        }
        else
        {
            //Debug.Log("Lose");
            OpenCloseBattleScene();
            HealthSystem.health -= 1;
            ShowHideLoseLog();
            Invoke("ShowHideLoseLog", 1.5f);
        }
    }

    public void ButtonAnswerTwo()
    {
        if (correctKeyAnswer == 2)
        {
            //Debug.Log("Win");
            OpenCloseBattleScene();
            ShowWinLog();
            //enemy[NumberOfEnemy].GetComponent<GameObject>();
            enemy[NumberOfEnemy].transform.Translate(Vector2.left * 100);
            Invoke("ShowWinLog", 1.5f);
        }
        else
        {
            //Debug.Log("Lose");
            OpenCloseBattleScene();
            HealthSystem.health -= 1;
            ShowHideLoseLog();
            Invoke("ShowHideLoseLog", 1.5f);
        }
    }

    public void ButtonAnswerThree()
    {
        if (correctKeyAnswer == 3)
        {
            //Debug.Log("Win");
            OpenCloseBattleScene();
            ShowWinLog();
            //enemy[NumberOfEnemy].GetComponent<GameObject>();
            enemy[NumberOfEnemy].transform.Translate(Vector2.left * 100);
            Invoke("ShowWinLog", 1.5f);
        }
        else
        {
            //Debug.Log("Lose");
            OpenCloseBattleScene();
            HealthSystem.health -= 1;
            ShowHideLoseLog();
            Invoke("ShowHideLoseLog", 1.5f);
        }
    }

    public void ButtonAnswerFour()
    {
        if (correctKeyAnswer == 4)
        {
            //Debug.Log("Win");
            OpenCloseBattleScene();
            ShowWinLog();
            //enemy[NumberOfEnemy].GetComponent<GameObject>();
            enemy[NumberOfEnemy].transform.Translate(Vector2.left * 100);
            Invoke("ShowWinLog", 1.5f);
        }
        else
        {
            //Debug.Log("Lose");
            OpenCloseBattleScene();
            HealthSystem.health -= 1;
            ShowHideLoseLog();
            Invoke("ShowHideLoseLog", 1.5f);
        }
    }

    [SerializeField]
    private CanvasGroup winLog;
    [SerializeField]
    private CanvasGroup loseLog;
    public void ShowWinLog()
    {
        winLog.alpha = winLog.alpha == 0 ? 1 : 0;
        winLog.blocksRaycasts = winLog.blocksRaycasts == false ? true : false;
    }

    public void ShowHideLoseLog()
    {
        loseLog.alpha = loseLog.alpha == 0 ? 1 : 0;
        loseLog.blocksRaycasts = loseLog.blocksRaycasts == false ? true : false;
    }

    [SerializeField] private Text missionText;
    public void ChangeMissionText(int numberOfText)
    {
        missionText.GetComponent<Text>();

        switch (numberOfText)
        {
            case 1:
                {
                    missionText.text = "Defeat 0 / 4 cursed numbers";
                    break;
                }
            case 2:
                {
                    missionText.text = "Defeat 1 / 4 cursed numbers";
                    break;
                }
            case 3:
                {
                    missionText.text = "Defeat 2 / 4 cursed numbers";
                    break;
                }
            case 4:
                {
                    missionText.text = "Defeat 3 / 4 cursed numbers";
                    break;
                }
            case 5:
                {
                    missionText.text = "Back to Adam";
                    break;
                }
            case 6:
                {
                    missionText.text = "Enter the kingdom";
                    break;
                }
            case 7:
                {
                    missionText.text = "Defeat the Traitor";
                    break;
                }
            case 8:
                {
                    missionText.text = "Return to the village";
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            OpenCloseBattleScene();
            GenerateTask(0);
            SetEnemyImage(0);
            NumberOfEnemy = 0;
            Destroy(helperToDissap);
        }
        if (other.tag == "HelperDialog1")
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            NextSentences();
            isCloseDialog1 = true;
        }
        if(other.tag == "Enemy2")
        {
            OpenCloseBattleScene();
            GenerateTask(1);
            SetEnemyImage(1);
            NumberOfEnemy = 1;

        }
        if (other.tag == "Enemy3")
        {
            OpenCloseBattleScene();
            GenerateTask(2);
            SetEnemyImage(2);
            NumberOfEnemy = 2;

        }
        if (other.tag == "Enemy4")
        {
            teleport.tag = "Teleport";
            OpenCloseBattleScene();
            GenerateTask(3);
            SetEnemyImage(3);
            NumberOfEnemy = 3;

            
            dialog2Object.tag = "Dialog2";
        }
        if(other.tag == "Enemy5")
        {
            OpenCloseBattleScene();
            GenerateTask(4);
            SetEnemyImage(4);
            NumberOfEnemy = 4;
            closeDialog3.tag = "DoNothing";
            
        }
        if (other.tag == "Enemy6")
        {
            OpenCloseBattleScene();
            GenerateTask(5);
            SetEnemyImage(5);
            NumberOfEnemy = 5;
            ChangeMissionText(8);
            TheEnd.tag = "End";
            isEndBattle = true;
        }
        if(other.tag == "Dialog2")
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            isCloseDialog2 = true;
            NextSentencesForDialog2();


            //ЗДЕСЬ ПЕСНЯ БУДЕТ
            oldSong.Stop();
            newSong.Play();


        }
        if (other.tag == "Dialog3")
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            isCloseDialog3 = true;
            NextSentencesForDialog3();
            

        }
        if(other.tag == "End")
        {
            SceneManager.LoadScene(2);
        }
    }

    [SerializeField]
    private GameObject[] enemy = new GameObject[6];
    private int NumberOfEnemy = 0;

    [SerializeField]
    private GameObject teleport;
    bool isTP = false;
    private void OnTriggerExit2D(Collider2D other)
    {
        /*
        if (other.tag == "Enemy")
        {
            Debug.Log("You are win");
        }
        if(other.tag == "HelperDialog1")
        {
            
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            isCloseDialog1 = false;
            
        } */

        if(other.tag == "Dialog2")
        {

        }
    }

    //[SerializeField] public Text nameText;
    [SerializeField] public Text sentenceText;
    [SerializeField] public CanvasGroup dialogBar;


    public string[] sentencesForDialog1 =
    {
        "Adam: Finally, the great knight came to us",
        "Adam: Cursed numbers, you should destroy them.",
        "Knight: Holy numbers was cursed?",
        "Adam: Yes, and you should to hurry up.",
        "Adam: They scared all the inhabitants",
        "Adam: And soon they will find a way to the kingdom",
        "Adam: Destroy 4 numbers around our kingdom, good luck, the great knight."
    };



    private string[] sentencesForDialog2 =
    {
        "Knight: Where is he?",
        "Knight: Maybe i should check the kingdom.",
        "Knight: I hope I can find him."
    };

    private string[] sentencesForDialog3 =
    {
        "Adam: HOW! How did you alive????!!! I think my cursed numbers will kill you",
        "Knight: By the holy light! Do you done all of this?",
        "Adam: Meh... Those numbers are useless. Will have to do everything yourself.",
        "Adam: With the help of the magic of darkness I could not only curse the numbers",
        "Adam: But also invoke a dark copy of YOU!",
        "Adam: Now i destroy you once and forever."
    };

    int numberOfSentence3 = 0;
    bool isCloseDialog3 = false;

    public void NextSentencesForDialog3()
    {
        try
        {
            sentenceText.text = sentencesForDialog3[numberOfSentence3];
            numberOfSentence3++;
        }
        catch
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            numberOfSentence3 = 0;
            isCloseDialog3 = false;
            ChangeMissionText(7);
        }
    }

    int numberOfSentence2 = 0;
    bool isCloseDialog2 = false;
    [SerializeField] private GameObject dialog2Object;
    public void NextSentencesForDialog2()
    {
        try
        {
            sentenceText.text = sentencesForDialog2[numberOfSentence2];
            numberOfSentence2++;
        }
        catch
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            numberOfSentence2 = 0;
            isCloseDialog2 = false;
            ChangeMissionText(6);
        }
    }
    

    //public string[] nameForDialog1 = { "Adam:", "Adam:", "Knight:", "Adam:", "Adam:", "Adam:", "Adam:" };

    public int numberOfSentence = 0;
    public bool isCloseDialog1 = false;
    public void NextSentences()
    {
        try
        {
            sentenceText.text = sentencesForDialog1[numberOfSentence];
            numberOfSentence++;
        }
        catch
        {
            dialogBar.alpha = dialogBar.alpha == 0 ? 1 : 0;
            dialogBar.blocksRaycasts = dialogBar.blocksRaycasts == false ? true : false;
            numberOfSentence = 0;
            isCloseDialog1 = false;
            ChangeMissionText(1);
        }
    }

    private int numberOfMissionText = 2;

    [SerializeField]
    private GameObject helperToDissap;

    [SerializeField]
    private GameObject TheEnd;

    [SerializeField]
    private GameObject closeDialog3;
}
