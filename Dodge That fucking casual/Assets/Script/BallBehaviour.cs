using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private float DirectionX;
    private float DirectionY;
    private Vector3 initialVelocity;
    private float minVelocity = 1f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    private float ballVelocityUpCD;
    
    private void OnEnable()
    {
        /*X = Random.Range(-10f, 10f);
        Y = Random.Range(-10f, 10f);
        Debug.Log("X : " + DirectionX);
        Debug.Log("Y : " + DirectionY);
        initialVelocity = new Vector3(X, Y, 0);*/
        
        initialVelocity = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    private void Update()
    {
        ballVelocityUpCD -= Time.deltaTime;
        if (ballVelocityUpCD <= 0)
        {
            ballVelocityUpCD = 15;
            minVelocity += 1;
        }
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}