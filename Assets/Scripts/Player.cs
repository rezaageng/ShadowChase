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
}
