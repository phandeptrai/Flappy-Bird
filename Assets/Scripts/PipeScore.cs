using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.instance.updateScore();
        }
    }
}
