using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == "level 1")
            {
                SceneManager.LoadScene("level 2");
            }
            else if(scene.name == "level 2")
            {
                SceneManager.LoadScene("level 3");
            }
            else
            {

            }
            
        }
    }
}
