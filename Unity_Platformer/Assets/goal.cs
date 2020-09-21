using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    [SerializeField]
    int goToLevel = 0;
    int pickups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickups = GameObject.FindGameObjectsWithTag("pickup").Length;
        if (pickups <= 0)
        {
            SceneManager.LoadScene(goToLevel);
        }
    }
}
