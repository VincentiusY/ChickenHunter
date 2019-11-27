using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed;
    public float distance;
    //public int moveDirection;
    private bool rightDirection = true;
    public Transform groundDetection;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * EnemySpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(rightDirection == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rightDirection = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rightDirection = true;
            }
        }

        /*
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection, 0) * EnemySpeed;
        if(groundInfo.distance < 0.7f)
        {
            if(moveDirection > 0)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = -1;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
 }
