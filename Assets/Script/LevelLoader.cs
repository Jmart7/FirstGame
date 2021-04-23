using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevel(int levelIndex) {
        // play animation
        transition.SetTrigger("Start");
        // wait
        yield return new WaitForSeconds(transitionTime);
        // load scene
        SceneManager.LoadScene(levelIndex);
    }
}