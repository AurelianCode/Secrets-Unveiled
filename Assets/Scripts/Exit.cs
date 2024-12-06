using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    
  

    private IEnumerator LoadScenes()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            Debug.Log("loading scene");

            StartCoroutine(LoadScenes());
            
        }
    }
}
