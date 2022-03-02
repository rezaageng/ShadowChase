using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject[] shadowPrefabs;
  private GameObject spawnedShadow;
  [SerializeField]
  private Transform leftPos, rightPost;
  private int randomIndex;
  private int randomSide;

  // Start is called before the first frame update
  void Start()
  {
    // start couroutine
    StartCoroutine(SpawnShadow());
  }

  IEnumerator SpawnShadow()
  {
    while (true)
    {
      yield return new WaitForSeconds(Random.Range(1f, 5f));

      randomIndex = Random.Range(0, shadowPrefabs.Length);
      randomSide = Random.Range(0, 2);

      spawnedShadow = Instantiate(shadowPrefabs[randomIndex]);

      // Left side
      if (randomSide == 0)
      {
        spawnedShadow.transform.position = leftPos.position;
        spawnedShadow.GetComponent<Shadow>().speed = Random.Range(4f, 10f);
      }
      // Right Side
      else
      {
        spawnedShadow.transform.position = rightPost.position;
        spawnedShadow.GetComponent<Shadow>().speed = -Random.Range(4f, 10f);
        spawnedShadow.GetComponent<SpriteRenderer>().flipX = true;
      }
    }
  }

}
