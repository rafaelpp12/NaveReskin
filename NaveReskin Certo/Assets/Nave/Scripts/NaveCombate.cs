using System.Collections;
using UnityEngine;

public class NaveCombate : MonoBehaviour
{
    public GameObject tiroNave;
    public float inputTiro;
    public int tempoParaAtirar;
    public int Contador;

    public NaveManager1 Manager;

    public SpriteRenderer sprite;
    public GameObject PontoDeSpawn;
    public bool invencivel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Contador++;
        inputTiro = Input.GetAxis("Jump");
        Atirar();
    }

    public void Atirar()
    {
        if (Contador >= tempoParaAtirar && inputTiro != 0)
        {
            Instantiate(tiroNave, transform.position, Quaternion.identity);
            Contador = 0;
        }
    }

    public void TomarDano()
    {
        VoltarAPoiscao();
        Manager.VidasPlayer--;
        Manager.AlterarVidasTexto();
        if (Manager.VidasPlayer <= 0)
        {
            Manager.GameOver();
        }
        else
        {
            StartCoroutine(VoltarAPoiscao());
        }
    }
    IEnumerator VoltarAPoiscao()
    {
        invencivel = true;
        transform.position = PontoDeSpawn.transform.position;
        sprite.color = new Color(1, 1, 1, 1f);
        yield return new WaitForSeconds(0.5f);

        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);

        sprite.color = new Color(1, 1, 1, 1f);
        yield return new WaitForSeconds(0.5f);

        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);

        sprite.color = new Color(1, 1, 1, 1f);
        yield return new WaitForSeconds(0.5f);

        invencivel = false;

    }


}


