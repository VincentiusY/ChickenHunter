using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour {

    //public static PlayerMovement pm;

    public AudioSource[] sounds;
    public AudioSource audio1;
    public AudioSource audio2;

    public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private static int health = 5;
    public static int remainingHealth {
        get {
            return health;
        }
    }

    public Vector3 respawnPoint;

    public GameObject gameOverText, retryButton, menuButton;

    void Start () {

        sounds = GetComponents<AudioSource>();
        audio1 = sounds[0];
        audio2 = sounds[1];

        gameOverText = GameObject.Find("GameOverText");
        retryButton = GameObject.Find("RetryButton");
        menuButton = GameObject.Find("MainMenuButton");

        health = 5;
        gameObject.SetActive(true);
        gameOverText.SetActive(false);
        retryButton.SetActive(false);
        menuButton.SetActive(false);
    }


	
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

        if (health <= 0)
        {
            Debug.Log("GAME OVER");
            gameOverText.SetActive(true);
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            gameObject.SetActive(false);
        }

    }

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chickens"))
        {
            Destroy(other.gameObject);
            //AudioSource audio = GetComponent<AudioSource>();
            audio1.Play();
        }

        if (other.gameObject.CompareTag("FallDetect"))
        {
            transform.position = respawnPoint;
            health -= 1;
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            health -= 1;
            //AudioSource audio = GetComponent<AudioSource>();
            audio2.Play();

        }
    }
}
