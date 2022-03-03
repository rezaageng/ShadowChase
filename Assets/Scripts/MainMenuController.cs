using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
  public void PlayGame()
  {
    int clickedObj = int.Parse(EventSystem.current.currentSelectedGameObject.name);
    int[] a = new int[10];
    a[clickedObj] = 10;
    // SceneManager.LoadScene("Gameplay");
  }
}
