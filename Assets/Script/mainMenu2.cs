using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu2 : MonoBehaviour {
    public GameObject yourName;

    public void playTheGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void enterShop() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitTheGame() {
        Debug.Log("cerraste el juego crack");
        Application.Quit();
    }

    public void playYourName() {
        yourName.SetActive(true);
    }
}