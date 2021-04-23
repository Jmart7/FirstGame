using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

    public void restartGame() {
        Debug.Log("estas reiniciando");
        SceneManager.LoadScene(0);
    }
}