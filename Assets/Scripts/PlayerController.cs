using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int score = 0;
    public int health = 5;
    public Rigidbody rb;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            Debug.Log($"Score: {score}");
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log($"You win!");
        }
    }
}
