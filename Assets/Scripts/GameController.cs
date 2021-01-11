using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Vector3 startPosition;
    public Vector3 startRotation;

    public GameObject props;
    private Vector3 originalPropsPosition;
    
    void Start()
    {
        originalPropsPosition = props.transform.position;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Respawn();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Respawn()
    {
        player.transform.position = startPosition;
        player.transform.rotation = Quaternion.Euler(startRotation);
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        props.transform.position = originalPropsPosition;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("DirtTrack3");
    }
}
