using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Vector2 input;
    public float walkSpeed;
    // Use this for initialization
    private Rigidbody2D rb;
    public bool inDialogue , canMove;
    private Animator anim;
    public GameObject playerAbility, abilitySelect;
    private int abilityCoolDown;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inDialogue = false;
        canMove = true;
        anim = GetComponent<Animator>();
        abilitySelect.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //BASIC MOVEMENT
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(input.x) > 0.5f)
            rb.velocity = new Vector2(input.x * walkSpeed, rb.velocity.y);

        if (Mathf.Abs(input.y) > 0.5f)
            rb.velocity = new Vector2(rb.velocity.x, input.y * walkSpeed);

        if (input.x == 0)
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (input.y == 0)
            rb.velocity = new Vector2(rb.velocity.x, 0);

        if (!canMove)
        {
            rb.velocity = new Vector2(0, 0);

        }
        //ANIMATION
        anim.SetBool("InDialogue", inDialogue);
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);

    }

    private void Update()
    {
        //USE ABILITY CHARGE IF ANY ARE AVAILABLE
        if (Input.GetKeyDown("space") && GameInfo.AbilityCharges >= 1)
        {
            Instantiate(playerAbility, transform.position, Quaternion.identity);
            GameInfo.AbilityCharges--;
            canMove = false;
        }
        if (Input.GetKeyUp("space"))
        {
            canMove = true;
        }
        //CHOOSE ABILITY BUTTON Q
        if (Input.GetKeyDown("q"))
        {
            abilitySelect.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyUp("q"))
        {
            abilitySelect.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ChooseNoise()
    {
        playerAbility = (GameObject)(Resources.Load("Prefabs/PlayerNoise"));
    }

    public void ChooseTrap()
    {
        playerAbility = (GameObject)(Resources.Load("Prefabs/PlayerTrap"));
    }
}
