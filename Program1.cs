using UnityEngine;

public class Program1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float rotateSpeed = 50f; // Speed of rotation
    public float scaleSpeed = 0.5f; // Speed of scaling

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleScaling();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // Left (-1) / Right (+1)
        float moveZ = Input.GetAxis("Vertical");   // Forward (+1) / Backward (-1)

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Q)) // Rotate Left
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E)) // Rotate Right
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void HandleScaling()
    {
        if (Input.GetKey(KeyCode.R)) // Increase Scale
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.V)) // Decrease Scale
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
    }
}