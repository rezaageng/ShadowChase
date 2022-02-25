using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField]
  private float moveForce = 10f;
  [SerializeField]
  private float jumpForce = 11f;
  private float movementX;
  private Rigidbody2D rb;
  private SpriteRenderer sr;
  private Animator anim;
  private string WALK_ANIM = "Walk";
  private string JUMP_ANIM = "Jump";
  private bool isGrounded = true;
  private string GROUND_TAG = "Ground";

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    PlayerMoveKeyboard();
    AnimatePlayer();
    PlayerJump();
  }

  private void PlayerMoveKeyboard()
  {
    movementX = Input.GetAxisRaw("Horizontal");
    transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
  }

  private void AnimatePlayer()
  {
    if (movementX > 0)
    {
      sr.flipX = false;
      anim.SetBool(WALK_ANIM, true);
    }
    else if (movementX < 0)
    {
      sr.flipX = true;
      anim.SetBool(WALK_ANIM, true);
    }
    else
    {
      anim.SetBool(WALK_ANIM, false);
    }
  }

  private void PlayerJump()
  {
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      isGrounded = false;
      rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
      anim.SetBool(JUMP_ANIM, true);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag(GROUND_TAG))
    {
      isGrounded = true;
      anim.SetBool(JUMP_ANIM, false);
    }
  }
}
