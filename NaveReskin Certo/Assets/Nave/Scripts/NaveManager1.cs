using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveManager1 : MonoBehaviour
{
    public static NaveManager1 Instance;

    public GameObject panelMenu;
    public GameObject panelGameplay;

    public TMP_Text textoPontuacao;
    public TMP_Text textoVidas;

    public SpawnManager SpawnManager;
    public NaveCombate player;

    public int VidasPlayer;
    public int Pontuacao;

    private void Awake()
    {
        Instance = this;
    }
    public void IniciarJogo()
    {
        panelMenu.SetActive(false);
        panelGameplay.SetActive(true);


        SpawnManager.IniciarSpawn();
        AlterarPontuacao(0);
        AlterarVidasTexto();
    }
    public void AlterarVidasTexto()
    {
        textoVidas.text = VidasPlayer.ToString();
    }
    public void AlterarPontuacao(int pontos)
    {
        Pontuacao += pontos;
        textoPontuacao.text = "Pontos : " + Pontuacao;

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
