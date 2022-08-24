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
    public GameObject wlbar;
    public Text WinLoseText;
   
    
    // Start is called before the first frame update
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            wlbar.SetActive(true);
            wlbar.GetComponent<Image>().color = Color.red;
            WinLoseText.GetComponent<Text>().color = Color.white;
            WinLoseText.text = "Game Over!";
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
            //SceneManager.LoadScene("Maze");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");

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
            SetScoreText();
            //Debug.Log($"Score: {score}");
        }

        if (other.gameObject.CompareTag("Trap"))
        {
    
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            winLoseBar();
            StartCoroutine(LoadScene(3));
           //Debug.Log($"You win!");
           //SceneManager.LoadScene("Maze");
        }
    }
    /// <summary>
    /// Updates the Score string in game
    /// </summary>
    void SetScoreText()
    {
        score++;
        scoreText.text = "Score: " + score; 
    }
    /// <summary>
    /// Updates the Health of the player string in game
    /// </summary>
    void SetHealthText()
    {
        health--;
        healthText.text = "Health: " + health;
    }
    /// <summary>
    /// Activates win bar
    /// </summary>
    void winLoseBar()
    {
        wlbar.SetActive(true);
        wlbar.GetComponent<Image>().color = Color.green;
        WinLoseText.GetComponent<Text>().color = Color.black;
        WinLoseText.text = "You Win!";
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Maze");
    }
}