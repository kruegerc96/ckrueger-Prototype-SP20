using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private int enemiesLeft;
    private bool allEnemiesDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForEnemies();
        Hud();
    }

    //adds each object tagged as an enemy to an array and keeps track of the size of the array
    //https://answers.unity.com/questions/496609/how-to-keep-count-of-enemies-left.html
    private void CheckForEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        if (enemiesLeft == 0)
        {
            Application.Quit();
        }
    }

    //updates GUI text with number of enemies left
    void Hud()
    {
        text.GetComponent<Text>().text = $"Enemies left: {enemiesLeft}";
    }
}
