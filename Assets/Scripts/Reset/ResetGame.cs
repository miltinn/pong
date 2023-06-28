using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void ResetKeys()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0); //Recarrega a cena inicial do jogo
    }
}
