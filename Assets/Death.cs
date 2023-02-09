using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public void Ooof()
    {
      SceneManager.LoadScene(1);

    }
    
    public void Menu()
    {
      SceneManager.LoadScene(0);

    }
    
}
