using Unity.VisualScripting;
using UnityEngine;

public class InimigoLados : MonoBehaviour
{
    public Rigidbody2D corpo;
    public int velocidadeX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        corpo.linearVelocity = new Vector2(velocidadeX, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<NaveCombate>().invencivel == false)
            {
                collision.gameObject.GetComponent<NaveCombate>().TomarDano();
            }
            else if (collision.gameObject.GetComponent<NaveCombate>().invencivel == true)
            {
                Destroy(gameObject);
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tiro"))
        {
            NaveManager1.Instance.AlterarPontuacao(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
