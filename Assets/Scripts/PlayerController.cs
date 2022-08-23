using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int score = 0;
    public int health = 5;
    public Rigidbody rb;
    public Text scoreText;
    public Text healthText;
    public GameObject youWin;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Maze");
        }
    }

      void FixedUpdate()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed);        
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb.AddForce(speed , 0, 0);
        }
    }
    /// <summary>
    /// When gameobject with specific tag is trigger an option is activated
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            SetScoreText();
            //Debug.Log($"Score: {score}");
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            YouWinText(); 
           //Debug.Log($"You win!");
            //SceneManager.LoadScene("Maze");
        }
    }
    /// <summary>
    /// Updates the Score string in game
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = "Score: " + score; 
    }
    /// <summary>
    /// Updates the Health of the player string in game
    /// </summary>
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    void YouWinText()
    {
        
        
            gameObject.GetComponent<Image>().color = Color.green;
            
            youWin.SetActive(true);
        

        

    }
}
