using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

    public void gameRestart() {
        SceneManager.LoadScene(0);
    }
}