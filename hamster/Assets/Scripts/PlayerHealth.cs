using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + health;
    }
     private void OnCollisionEnter2D(Collision2D collision)
     {
             string otherTag = collision.gameObject.tag;
        if(otherTag == "Damage")
        {
            health--; 
            if(health <= 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                 SceneManager.LoadScene(scene.name);
            }
        }
    }
}
