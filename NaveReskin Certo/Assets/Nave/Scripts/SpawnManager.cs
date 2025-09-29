    using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

public class SpawnManager : MonoBehaviour
{   

    public NaveManager1 NaveManager1;
    public GameObject Player;
    public GameObject inimigo;
    public GameObject InimigoLados;
    public int tempoSpawn;
    public int tempoSpawnLados;
    public int temporizador;
    public int temporizadorLados;
    public bool podeSpawnar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSpawnar == false)
        {
            return;

        }
        else
        {
            for (int i = 0; i < 30; i++)
            {
                {
                    Spawnar();

                    SpawnarLados();
                }

            }
            temporizador++;
            temporizadorLados++;

        }
    }
    public void IniciarSpawn()
    {
        podeSpawnar = true;
    }


    public void Spawnar()
    {
        if (temporizador >= tempoSpawn)
        {
            Instantiate(inimigo, new Vector2(Random.Range(-8, 8), 5), Quaternion.identity);
            
            
            temporizador = 0;
        }

    }
    public void SpawnarLados()
    {
        if (temporizadorLados >= tempoSpawnLados)
        {
            Debug.Log("To chamando isso aqui");
            Instantiate(InimigoLados, new Vector2(9.42f, Random.Range(4.51f, -4.51f)), Quaternion.identity);
            
            temporizadorLados = 0;
        }

    }

    public void Renascer()
    {
        Instantiate(Player, new Vector2(Random.Range(-8, 8), 1), Quaternion.identity);

    }


}
