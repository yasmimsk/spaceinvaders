using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogo : MonoBehaviour
{
    private bool carregado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (carregado)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(0, LoadSceneMode.Additive);
            } 

            carregado = !carregado;
        }
    }
}
