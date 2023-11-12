using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public float forceMultiplier = 1f; // Adjust this value to control the strength of the bounce

    private void OnCollisionEnter(Collision collision)


    {

        // Calculate the reflected force direction
        Vector3 incomingForce = collision.relativeVelocity;
        Vector3 reflectedForce = Vector3.Reflect(incomingForce, collision.contacts[0].normal).normalized;

        // Apply the reflected force to the ball's Rigidbody
        Rigidbody ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.AddForce(reflectedForce * forceMultiplier, ForceMode.Impulse);
    }


}
