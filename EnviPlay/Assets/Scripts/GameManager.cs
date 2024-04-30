using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CarteData> selectedQuestions = new ();
    public GameObject prefab;
    public int bestScoreLocation = 0;
    public int bestScoreTransport = 0;
    public int bestScoreRandom = 0;
    public string selectionChoice;
    private void Awake()
    {
        // Conserver ce GameObject entre les scènes
        DontDestroyOnLoad(gameObject);
    }
    public void setBestScore (int score)
    {
        if (selectionChoice == "location" && bestScoreLocation < score)
        {
            bestScoreLocation = score;
        }
        else if (selectionChoice == "transport" && bestScoreTransport < score)
        {
            bestScoreTransport = score;
        }
        else if (selectionChoice == "random"&& bestScoreRandom < score)
        {
            bestScoreRandom = score;
        }
    }
    public int getBestScore ()
    {
        if (selectionChoice == "location")
        {
            return bestScoreLocation;
        }
        else if (selectionChoice == "transport")
        {
            return bestScoreTransport;
        }
        else if (selectionChoice == "random")
        {
            return bestScoreRandom;
        }
        else
        {
            return 0;
        }
    }
}
