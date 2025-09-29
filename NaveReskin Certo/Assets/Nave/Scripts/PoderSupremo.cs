using UnityEngine;

public class PoderSupremo : MonoBehaviour
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

    private void OnTrigger1Enter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

            foreach (GameObject inimigo in inimigos)
            {
                Destroy(inimigo);
            }
        }
    }
}


