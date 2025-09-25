using UnityEngine;

public class TiroNave : MonoBehaviour
{
    public Rigidbody2D corpo;
    public int velocidadeY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        corpo.linearVelocity = new Vector2(0, velocidadeY);
    }
}
