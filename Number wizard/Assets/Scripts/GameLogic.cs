using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField][Range (0,1)] private float colorSwitch;
    [ColorUsage(true, true)] [SerializeField] private Color idle, idleLight, idleTrail;
    [ColorUsage(true, true)] [SerializeField] private Color rage, rageLight, rageTrail;
    [SerializeField] private Material mat, asteroids, stars;
    [SerializeField] private Vector3 location;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject mage;
    [SerializeField] private Button guessButton;
    [SerializeField] private float rageSwitch, idleSwitch;
    [SerializeField] private int minNum;
    [SerializeField] private int maxNum;
    [SerializeField] private int minRange;
    [SerializeField] private int maxRange;
    [SerializeField] private bool gameIsWon;
    public InputField userInput;
    public Text gameLabel;
    public Text numDisplay;
    public int randomNum = 10;
    [SerializeField] private bool rageMode;
    [SerializeField] private Light[] lights;



    // Start is called before the first frame update
    void Start()
    {
        ResetGame();

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.FindGameObjectWithTag("mage");
        //ransform.position = location;
        if (rageMode)
        {
            colorSwitch += rageSwitch * Time.deltaTime;

        }
        else
        {
            colorSwitch -= (rageSwitch / idleSwitch) * Time.deltaTime;

        }
        colorSwitch = Mathf.Clamp(colorSwitch, 0, 1);
        mat.SetColor("_Emission_Color", Color.Lerp(idle, rage, colorSwitch));
        stars.SetColor("_EmissionColor", Color.Lerp(idle, rage, colorSwitch));
        asteroids.SetColor("_EmissionColor", Color.Lerp(idleTrail, rageTrail, colorSwitch));
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = Color.Lerp(idleLight, rageLight, colorSwitch);
        }
    }

    public void OnButtonClick()
    {
        string userInputValue = userInput.text;
        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);

            if (answer == randomNum)
            {
                Rage();
                gameLabel.text = "correct!";
                //Debug.Log("CORRECT!");
                ResetGame();       

            }
            else if (answer > randomNum)
            {
                gameLabel.text = "Try Lower";
                //Debug.Log("Try Lower");
            }
            else
            {
                gameLabel.text = "Try Higher";
                //Debug.Log("Try Higher");
            }
        }
        else
        {
            gameLabel.text = "Enter a number";
            //Debug.Log("Enter a number");
        }

        
    }
    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        //Debug.Log("min is " + min);
        //Debug.Log("max is " + max);
        return random; 
    }

    private void ResetGame()
    {
        mage.transform.position = location;
        maxNum = Random.Range(minRange, maxRange);
        randomNum = GetRandomNumber(minNum, maxNum);
        numDisplay.text = minNum + "-" + (maxNum-1);

        if (gameIsWon)
        {
            userInput.text = "";
            gameLabel.text = "You Won, Guess a number between " + minNum + " and " + (maxNum - 1);
        }
        else
        {
            userInput.text = "";
            gameLabel.text = "Guess a number between " + minNum + " and " + (maxNum - 1);
            gameIsWon = true;
        }
    }
    private void Rage()
    {
        rageMode = true;
        Anim.SetTrigger("correct");
        /*for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = Color.Lerp(lights[i].color, rageLight, colorSwitch);
        }*/
        //mat.SetColor("_Emission_Color", rage);
    }
    public void Ragent()
    {
        rageMode = false;
       /* for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = Color.Lerp(rageLight, idleLight, colorSwitch);
        }*/
        
        //Anim.SetTrigger("correct");
        //mat.SetColor("_Emission_Color", rage);
    }
}
