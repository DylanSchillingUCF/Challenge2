using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public TMP_Text score;

    public TextMeshProUGUI livesText;

    private int scoreValue = 0;

    public GameObject winTextObject;

    public GameObject deathTextObject;

    public GameObject playerObject;

    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = ("Points: " + scoreValue.ToString());
        lives = 3;
        livesText.text = "Lives: " + lives.ToString();
        deathTextObject.SetActive(false);
        winTextObject.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = ("Points: " + scoreValue.ToString());
            Destroy(collision.collider.gameObject);

            if (scoreValue >=4) {
                winTextObject.SetActive(true);
            }
        }

    }

    void SetLivesRemaining()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            winTextObject.SetActive(false);
            deathTextObject.SetActive(true);
            playerObject.SetActive(false);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }
}
