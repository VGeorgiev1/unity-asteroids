using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour {

    // Use this for initialization
    public void get_in_game() {
        SceneManager.LoadScene("Main");
    }
    public void turn_off() {
        Application.Quit();
    }
}
