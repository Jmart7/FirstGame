using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {
    private Text text;
    public static int coinAmount;

    private void Start() {
        text = GetComponent<Text>();
        DontDestroyOnLoad(text);
    }

    private void Update() {
        text.text = coinAmount.ToString();
    }
}