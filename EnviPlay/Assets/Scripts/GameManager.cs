using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CarteData> selectedQuestions = new ();
    public GameObject prefab;
    private void Awake()
    {
        // Conserver ce GameObject entre les scènes
        DontDestroyOnLoad(gameObject);
    }
}
