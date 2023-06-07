using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private Odometer odo;
    private Connection conn;
    public GameObject player;
    public GameObject StartButton;


    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        odo = GetComponent<Odometer>();
        conn = GetComponent<Connection>();
        conn.ParseAnswer = odo.ParseAnswer;
    }

    public void StartVideo()
    {
        player.SetActive (true);
        StartButton.SetActive (false);

    }

    void Update()
    {
        
    }
}
