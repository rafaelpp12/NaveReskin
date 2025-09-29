using System.Collections;
using UnityEngine;

public class NaveCombate : MonoBehaviour
{

    public GameObject spawnTiros;
    public GameObject tiroNave;
    public float inputTiro;
    public int tempoParaAtirar;
    public int Contador;

    public GameObject tiroEspecial;
    public int tempoEspecial;
    public int ContadorEspecial;
    public bool inputEspecial;

    public NaveManager1 Manager;

    public SpriteRenderer sprite;
    public GameObject PontoDeSpawn;
    public bool invencivel;

    public int cadenciaTiro = 3;
    public int cadenciaTiroQuantidade = 3;
    
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
        if (ContadorEspecial >= tempoEspecial && inputEspecial == true)
        {
            StartCoroutine(TiroEspecialCoroutine());
        }

        ContadorEspecial++;
        inputEspecial = Input.GetKeyDown(KeyCode.Q);

    }

    public void Atirar()
    {
        if (Contador >= tempoParaAtirar && inputTiro != 0)
        {
            Instantiate(tiroNave, spawnTiros.transform.position, Quaternion.identity);
            Contador = 0;
        }
    }

    IEnumerator TiroEspecialCoroutine()
    {
        while (cadenciaTiro > 0)
        {
            
            Debug.Log("Tiro especial");
            GameObject tiroEsp = Instantiate(tiroEspecial, spawnTiros.transform.position, Quaternion.identity);
            tiroEsp.GetComponent<tiroEspecial>().player = this.gameObject;

            ContadorEspecial = 0;
            cadenciaTiro--;

            yield return new WaitForSeconds(0.2f); 
        }

        cadenciaTiro = cadenciaTiroQuantidade;
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


