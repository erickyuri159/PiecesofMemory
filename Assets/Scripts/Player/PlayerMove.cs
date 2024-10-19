using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D Playerbody2D;
    static PlayerMove instance;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    
    float horizontal;
    float vertical;
    bool lookingLeft;
    
    private Vector2 direcaoPlayer;
    
    public float moveSpeed; // Velocidade de movimento do personagem

    private void Start()
    {
        Playerbody2D = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lookingLeft = false;
        instance = this;
        
    }

    void Update()
    {
       // direcaoPlayer.x = Input.GetAxisRaw("Horizontal");
        //direcaoPlayer.y = Input.GetAxisRaw("Vertical");

        Time.timeScale = 1;
        if (!PauseMenu.isPaused)
        {
    


                direcaoPlayer = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                animator.SetFloat("horizontal", direcaoPlayer.x);
                animator.SetFloat("vertical", direcaoPlayer.y);
                animator.SetFloat("velocidade", direcaoPlayer.sqrMagnitude);
            

            if (direcaoPlayer != Vector2.zero)
            {
                animator.SetFloat("horizontal", direcaoPlayer.x);
                animator.SetFloat("vertical", direcaoPlayer.y);
                animator.SetFloat("velocidade", direcaoPlayer.sqrMagnitude);
            }

        }
        
    }
    void FixedUpdate()
        {
        Playerbody2D.MovePosition(Playerbody2D.position + direcaoPlayer * moveSpeed * Time.fixedDeltaTime);
        }
   

    public static PlayerMove GetInstance()
    {
        return instance;
    }

    public bool GetLookingLeft()
    {
        return lookingLeft;
    }

    public float GetHorizontal()
    {
        return horizontal;
    }

    public float GetVertical()
    {
        return vertical;
    }
   
}