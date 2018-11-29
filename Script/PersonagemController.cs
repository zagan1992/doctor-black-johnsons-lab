using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonagemController : MonoBehaviour {

    public float velocidade;
    public Animator personagemAnimator;
    public GameObject mira;
    public GameObject tiro;
    public int bullets;
    private bool podeAtirar;
    public Text bullets_Txt;
    public AudioClip tiroSound;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {

        bullets = 8;
        podeAtirar = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (bullets <= 0)
        {
            podeAtirar = false;
            Invoke("reloadAmmo", 2);
        }

        bullets_Txt.text = bullets.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-velocidade * Time.deltaTime, 0, 0);
            personagemAnimator.SetBool("Up", true);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(velocidade * Time.deltaTime, 0, 0);
            personagemAnimator.SetBool("Down", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
           personagemAnimator.SetBool("Up", false);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            personagemAnimator.SetBool("Down", false);
        }

        if (Input.GetMouseButtonDown(0) && podeAtirar)
        {
            //Atirar aqui
            Instantiate(tiro, mira.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(tiroSound);
            bullets--;
        }


    }

    private void reloadAmmo()
    {
        bullets = 8;
        podeAtirar = true;
        CancelInvoke();
    }
}
