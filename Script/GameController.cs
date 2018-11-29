using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject [] spawnPoint;
    public GameObject enemy;
    private float time;
    public float spawnTime;
    public int qtdInimigos;
    public int nivel;

    public GameObject CanvasEndGame;

    public int subirDeNivel;

    public int deadEnemys;

    public Text HighScore_TXT;
      
    private int highScore;

	// Use this for initialization
	void Start () {
        spawnTime = 5;
        qtdInimigos = 0;
        subirDeNivel = 5;
        int i = Random.Range(0, 3);
        instanciarInimigos(i);
        nivel = 1;
        deadEnemys = 0;
        highScore = PlayerPrefs.GetInt("Record", 0);

        HighScore_TXT.text = "HIGH SCORE: " + highScore.ToString();

        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time > spawnTime)
        {
            int i = Random.Range(0, 3);
            instanciarInimigos(i);
            time = 0;
        }

        if (qtdInimigos > subirDeNivel)
        {
            if (spawnTime > 0.5) { 
                spawnTime -= 0.5f;                
                }

            qtdInimigos = 0;
            nivel++;
            
        }

	}

    public void endGame()
    {        
        Time.timeScale = 0;
        CanvasEndGame.SetActive(true);

        if(deadEnemys > highScore)
        PlayerPrefs.SetInt("Record", deadEnemys);

    }

    void instanciarInimigos(int i)
    {        
        Instantiate(enemy, spawnPoint[i].transform.position, Quaternion.identity);
    }
}
