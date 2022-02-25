using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  [SerializeField]
  private float MinX, MaxX;
  private Transform player;
  private Vector3 tempPos;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  // Update is called once per frame
  void LateUpdate()
  {
    tempPos = transform.position;
    tempPos.x = player.position.x;

    if (tempPos.x < MinX)
    {
      tempPos.x = MinX;
    }
    else if (tempPos.x > MaxX)
    {
      tempPos.x = MaxX;
    }

    transform.position = tempPos;

  }
}
