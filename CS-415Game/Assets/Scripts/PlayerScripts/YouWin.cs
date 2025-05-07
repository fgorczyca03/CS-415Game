using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
