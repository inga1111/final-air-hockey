using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class AIPaddle : MonoBehaviour
{
    public Transform puck; // Reference to the puck object
    public float movementSpeed = 5f; // Adjust this value to control AI responsiveness
    public float hitForce = 10f; // Adjust this value to control the force of the AI's hits
    Rigidbody2D rb;
    

    void Update()
    {
        float puckX = puck.transform.position.x;
        float puckY = puck.transform.position.y;

        // Calculate target position based on puck's X position
        
        
        // Move the paddle towards the target position
        //GetComponent<Rigidbody2D>().AddForce((puck.transform.position
           //                                   - transform.position) * movementSpeed);


        // Check if the puck is close enough to hit (modify values as needed)
       // if (Mathf.Abs(puckY - transform.position.y) < 0.5f && Mathf.Abs(puckX - transform.position.x) < 1f)
       // {
       //     // Hit the puck in the opposite direction (modify for more complex AI)
       //     Vector2 hitDirection = new Vector2(puckX - transform.position.x, 1f) * hitForce;
        //    puck.GetComponent<Rigidbody2D>().AddForce(hitDirection);
       // }
    }
    private void FixedUpdate()
    {
        if (puck.position.x < -0.5 && puck.position.x > -11 && puck.position.y> -5&& puck.position.y<5)
        {
            GetComponent<Rigidbody2D>().AddForce((puck.transform.position - transform.position) * movementSpeed);
        }
    }
    private void Start()
    {
        
    }
  
}
