using Unity.VisualScripting;
using UnityEngine;

public class NaveMovimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidadeX;
    public float velocidadeY;
    public float velocidadeS;
    private float inputX;
    private float inputY;
    private bool inputS;

    public GameObject BoosterPlayer;
    public Animator PlayerAnimator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        inputS = Input.GetKey(KeyCode.LeftShift);

        if (inputX == 0 && inputY == 0)
        {
            BoosterPlayer.SetActive(false);
            PlayerAnimator.SetInteger("player", 0);
        }
        else
        {
            BoosterPlayer.SetActive(true);
            if (inputX == -1)
            {
                PlayerAnimator.SetInteger("player", -1);
            }
            else if (inputX == 1)
            {
                PlayerAnimator.SetInteger("player", 1);
            }
            else
            {
                PlayerAnimator.SetInteger("player", 0);
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (inputX * velocidadeX, inputY * velocidadeY);

        if (inputS == true)
        {
            rb.linearVelocity = new Vector2(inputX * velocidadeS, inputY * velocidadeY);
        }

    }
}
