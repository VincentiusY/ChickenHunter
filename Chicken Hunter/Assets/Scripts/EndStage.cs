using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    //  public int nextLevel;
    //  // Start is called before the first frame update
    //  void Start()
    //  {

    //  }

    //  // Update is called once per frame
    //  void Update()
    //  {

    //  }

    //  void OnTriggerEnter2D(Collider2D other)
    //  {
    //if(other.CompareTag("Player"))
    //{
    //          //Debug.Log("You Win");
    //          //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    //          Application.LoadLevel(nextLevel);
    //}
    //  }

    [SerializeField] private string nextStage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextStage);
        }
    }
}
