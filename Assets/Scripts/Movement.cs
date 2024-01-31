using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 10f; // Original speed set to 10

    public enum MovementType
    {
        AllDirections,
        HorizontalOnly,
        VerticalOnly
    }

    [SerializeField]
    private MovementType movementType = 0;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        switch (movementType)
        {
            case MovementType.HorizontalOnly:
                vertical = 0f;
                break;
            case MovementType.VerticalOnly:
                horizontal = 0f;
                break;
        }

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Drop"))
        {
            // Reduce speed by 5
            AdjustSpeed(-5f);
        }

        // Check if the collision is with a power-up
        if (collision.gameObject.CompareTag("Powerup"))
        {
            // Set speed to 15
            SetSpeed(15f);
            // Destroy the power-up object
            Destroy(collision.gameObject);
        }
    }

    // Method to set speed
    private void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Debug.Log("Speed set to: " + speed);
    }

    // Method to adjust speed
    private void AdjustSpeed(float amount)
    {
        speed += amount;
        // Ensure minimum speed is 5
        if (speed < 5f)
        {
            speed = 5f;
        }

        Debug.Log("Speed adjusted to: " + speed);
    }
}