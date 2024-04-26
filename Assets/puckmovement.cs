using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI; // This line is needed to use UI elements

public class MoveObject : MonoBehaviour
{
    public float moveSpeed = 5f; // This variable defines the speed of the object's movement
    public Button moveButton; // Optional: Keep the button reference for future use
    Rigidbody2D rb;
    public Transform center;
    Boundary PuckBoundary;
    Collider2D playerCollider;
    private Vector2 startingPosition;
    private static bool WasGoal { get; }
    public ScoreScript ScoreScriptInstance;
    void Update() // This function is called every frame
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Check for space key press
        {
            PuckMove();
        }
    }

    void PuckMove()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * moveSpeed;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       


        if (collider.gameObject.CompareTag("AiGoal"))
        {
            ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
            StartCoroutine(ResetPuck(false));

            transform.position = center.position;
            rb.velocity = Vector3.zero;

        }
        if(collider.gameObject.CompareTag("PlayerGoal"))
            {
            ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
            StartCoroutine(ResetPuck(true));

            transform.position = center.position;
            rb.velocity = Vector3.zero;

            }
    }
    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
       
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }
}
