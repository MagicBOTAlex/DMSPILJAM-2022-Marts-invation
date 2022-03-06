using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogHandler : MonoBehaviour
{
    public GameObject[] Dialongs;
    public int NextSceneIndex;
    int currentPage = 0;

    private void OnMouseDown()
    {
        currentPage++;
        if (currentPage < Dialongs.Length)
        {
            Dialongs[currentPage - 1].gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("TextSkip");
            Dialongs[currentPage].gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
