using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introController : MonoBehaviour
{

    public void MoveToGame()
    {
        SceneManager.LoadScene(1);
    }
}
