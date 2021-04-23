using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour {
    public Text scoreText;
    public float score = 0;

    // Update is called once per frame
    private void Update() {
        score = score + 10f * Time.deltaTime;
        scoreText.text = score.ToString("0");
    }
}