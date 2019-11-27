using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenValue : MonoBehaviour
{
    public int chickenValue = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Score.instance.changeScore(chickenValue);
        }
    }

}
