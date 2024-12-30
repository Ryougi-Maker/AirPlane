using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{

    public static gameover _instance;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void endGame()
    {
        this.gameObject.SetActive(true);
        GameObject.Find("finalScore").GetComponent<Text>().text = gameManager._instance.score.ToString();
        GameObject.Find("showScore").GetComponent<Text>().text = "";
        GameObject.Find("gameManager").SetActive(false);
        int zuiGaoFen = PlayerPrefs.GetInt("zgf", 0);
        if (zuiGaoFen < gameManager._instance.score)
        {
            zuiGaoFen = gameManager._instance.score;
            PlayerPrefs.SetInt("zgf",zuiGaoFen);
        }
        GameObject.Find("highestScore").GetComponent<Text>().text = zuiGaoFen.ToString();
    }
}
