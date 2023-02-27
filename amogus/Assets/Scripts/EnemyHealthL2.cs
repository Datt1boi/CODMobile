using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class EnemyHealthL2 : MonoBehaviour
{
    
    public int health = 10;
    public TextMeshProUGUI EnemyhealthText;
    // Update is called once per frame
    void Update()
    {
        EnemyhealthText.text = "NICK: " + health;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if (otherTag == "PlayerBullet")
        {
            health--;
            if (health <= 0)
            {
                SceneManager.LoadScene("L3pre");
            }
          
        }
 
    }
 
}
