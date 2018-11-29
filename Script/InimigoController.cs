using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour {
    public float velocidade;

    public bool walk;

    public Animator enemyAnimator;
    public GameController gameController;
    private Collider _collider;

	// Use this for initialization
	void Start () {

        walk = true;
        transform.Rotate(0, -90, 0);
        gameController = FindObjectOfType<GameController>();
        velocidade += gameController.nivel;
        if(velocidade > 20)
        {
            velocidade = 20;
        }
        _collider = GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (walk)
        {
            transform.Translate(0, 0, velocidade * Time.deltaTime);
        }

	}

    public void enemyDie()
    {
        enemyAnimator.SetBool("isDead", true);
        walk = false;
        Destroy(gameObject, 4);
        gameController.qtdInimigos++;
        gameController.deadEnemys++;
        Debug.Log("" + gameController.deadEnemys);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyDie();
            Destroy(collision.gameObject);
            _collider.enabled = false;
            
        }

        if (collision.gameObject.CompareTag("EndWalk"))
        {
            gameController.endGame();
        }
    }
}
