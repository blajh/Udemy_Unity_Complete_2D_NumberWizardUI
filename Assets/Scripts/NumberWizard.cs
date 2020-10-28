using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
	[SerializeField]
	private int maxNumber = 1000;
    [SerializeField]
    private int minNumber = 1;
    [SerializeField]
    private TMP_Text guessText;


    private int guessCount = 0;
    private int guess;

    void Start()
    {
        MakeGuess();
    }

    void Update()
    {
        ListenForInput();
    }

    private void MakeGuess() {
        guessCount++;
        CalculateGuess();
    }

	private void CalculateGuess() {
        //account for odd / 2 integer rounding
        //only needed for non-random version
        //if (minNumber == 999 && maxNumber == 1000) { 
        //maxNumber++;
        //}


        //non-random version uses optimised approach
        //guess = (minNumber + maxNumber) / 2;
        guess = Random.Range(minNumber, maxNumber + 1);
        StateGuess();
	}

	private void ListenForInput() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            OnPressHigher();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            OnPressLower();
        }

        else if (Input.GetKeyDown(KeyCode.Return)) {
            Correct();
        }
    }

	public void OnPressHigher() {
        minNumber = guess;
        MakeGuess();
    }

    public void OnPressLower() {
        maxNumber = guess;
        MakeGuess();
    }

	private void Correct() {
        maxNumber = 1000;
        minNumber = 1;
        guessCount = 0;
    }

    private void StateGuess() {
        guessText.text = guess.ToString();
    }
}
