using UnityEngine;

public class CoinScript : MonoBehaviour {

    private void Start() {
        CoinCounter.coinAmount = PlayerPrefs.GetInt("CoinCounter");
    }

    private void OnTriggerEnter2D(Collider2D col) {
        CoinCounter.coinAmount += 1000;
        PlayerPrefs.SetInt("CoinCounter", CoinCounter.coinAmount);
        Destroy(gameObject);
    }
}