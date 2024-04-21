using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class DeplacementCartes : MonoBehaviour
{
    public GameObject carte1;
    public GameObject carte2;
    public GameObject carte3;
    public GameObject cartePrefab;
    public float vitesseDeplacement = 500f; // Vitesse de déplacement des cartes
    public float distanceDeplacement = 550f; // Distance de déplacement égale à la largeur d'une carte

    private bool deplacementEnCours = false;

    private float positionInitialeX;


    void Start()
    {
        Debug.Log("Position initiale de la carte 1 : " + carte1.transform.position);
        positionInitialeX = carte1.transform.position.x;
    }

    void Update()
    {
        if (deplacementEnCours)
        {
            DeplacerCartes();
        }
    }

    public void DeplacerCartes()
    {
        float deplacement = vitesseDeplacement * Time.deltaTime;

        // Déplacer les cartes vers la gauche
        carte1.transform.Translate(Vector3.left * deplacement);
        carte2.transform.Translate(Vector3.left * deplacement);
        carte3.transform.Translate(Vector3.left * deplacement);

        // Vérifier si la distance de déplacement a été atteinte
        if (positionInitialeX - carte1.transform.position.x >= distanceDeplacement)
        {
            // Réinitialiser la position des cartes
            deplacementEnCours = false;
            positionInitialeX = carte1.transform.position.x;
            GameObject test = Instantiate(cartePrefab, new Vector3(0,0,0), Quaternion.identity);
        }
    }

    public void DemarrerDeplacement()
    {
        deplacementEnCours = true;
    }

}
