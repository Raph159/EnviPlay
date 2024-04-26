using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class DeplacementCartes : MonoBehaviour
{
    public GameObject carte1;
    public GameObject carte2;
    public GameObject carte3;
    public GameObject cartePrefab;
    public GameObject parentObject;
    public float vitesseDeplacement = 500f; // Vitesse de déplacement des cartes
    public float distanceDeplacement = 0f; // Distance de déplacement égale à la largeur d'une carte

    private bool deplacementEnCours = false;

    private float positionInitialeX;
    private Vector3 positionInit3;


    void Start()
    {
        Debug.Log("Position initiale de la carte 1 : " + carte1.transform.position);
        positionInitialeX = carte1.transform.position.x;
        positionInit3 = carte3.transform.position;
        distanceDeplacement = (Screen.width)/2;
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

            Transform parentTransform = parentObject.transform;

            int insertionIndex = parentTransform.childCount - 1; // l'index de l'avant-dernier enfant
            insertionIndex = Mathf.Clamp(insertionIndex, 0, parentTransform.childCount); // assurez-vous que l'index est valide
            insertionIndex = Mathf.Max(0, insertionIndex); // assurez-vous que l'index est positif
            insertionIndex -= 1; // déplacez-vous à l'avant-dernière place

            GameObject test = Instantiate(cartePrefab, positionInit3, Quaternion.identity,parentObject.transform);

            test.transform.SetSiblingIndex(insertionIndex);

            GameObject temp = carte1;

            carte1 = carte2;

            positionInitialeX = carte1.transform.position.x;

            carte2 = carte3;
            
            carte3 = test;

            Destroy(temp);
        }
    }

    public void DemarrerDeplacement()
    {
        deplacementEnCours = true;
    }

}
