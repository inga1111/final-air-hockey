using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Camera mainCamera; // Reference to the main camera
    private Vector3 mouseOffset; // Stores the offset between the mouse click and object position
    private bool isDragging; // Flag to track if the object is currently being dragged
    public Vector2 minPosition; // determine the minimum positions of x and y 
    public Vector2 maxPosition; // deteremine maximunm positions of x and y
    private Rigidbody2D rb;
    public Vector2 puckForce;

    void Start()
    {
        mainCamera = Camera.main; // Get reference to the main camera
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right;
    }

    void OnMouseDown() // Function called when the mouse is pressed down on the object
    {
        isDragging = true;

        // Calculate the offset between the mouse click position and the object's position
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset = transform.position - mousePosition;
    }

    void OnMouseUp() // Function called when the mouse is released
    {
        isDragging = false;
    }

    void Update() // Function called every frame
    {
        if (isDragging)
        {
            // Get the current mouse position in world space
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
            mousePosition.x = Mathf.Clamp(mousePosition.x, minPosition.x, maxPosition.x);
            mousePosition.y = Mathf.Clamp(mousePosition.y, minPosition.y , maxPosition.y); 


            // Update the object's position based on the mouse offset
            transform.position = mousePosition;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            print("collision");
            collision.rigidbody.AddForce(Vector2.left * puckForce, ForceMode2D.Impulse);
        }
    }
}
