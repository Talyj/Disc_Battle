using UnityEngine;
using Random = UnityEngine.Random;

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
        
        initialVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
        ballVelocityUpCD = 15;
    }

    private void Update()
    {
        ballVelocityUpCD -= Time.deltaTime;
        if (ballVelocityUpCD <= 0)
        {
            minVelocity += 2f;
            ballVelocityUpCD = 15;
        }
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("player"))
        {
            Bounce(collision.contacts[0].normal);
        }

        if (collision.gameObject.CompareTag("smash"))
        {
            minVelocity += 1;
            Bounce(collision.contacts[0].normal);
        }
    }

    public void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}