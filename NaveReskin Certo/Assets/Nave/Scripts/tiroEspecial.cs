using UnityEngine;

public class tiroEspecial : MonoBehaviour
{
    public GameObject player;
    
    
    public float radius;
    

    public int velocidade;
    public int aumentoRaio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) { return; }

        transform.RotateAround(player.transform.position, Vector3.forward , velocidade * Time.deltaTime);

        Vector3 dir = (transform.position - player.transform.position).normalized;
        transform.position += dir * aumentoRaio * Time.deltaTime;

    }

    private void FixedUpdate()
    {
     



    }
}
