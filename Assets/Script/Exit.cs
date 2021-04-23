using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    public int changeSora;
    public int amountOfMoney;
    public int quantityOfPowers;

    public void Start() {
        amountOfMoney = PlayerPrefs.GetInt("CoinCounter");
        changeSora = PlayerPrefs.GetInt("Sora");
        quantityOfPowers = PlayerPrefs.GetInt("Powers");
    }

    public void exitShop() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void buySora() {
        if (amountOfMoney >= 1000 && changeSora != 1) {
            CoinCounter.coinAmount = -1000;
            PlayerPrefs.SetInt("CoinCounter", CoinCounter.coinAmount);
            PlayerPrefs.SetInt("Sora", 1);
            //aca falta implementar destruir el texto o cambiarlo por otro texto como "bought"
        }
        else if (amountOfMoney < 1000) {
            Debug.Log("no tenes suficiente oro");
        }
        else {
            Debug.Log("ya tenes a sora");
        }
    }

    public void buyPower() {
        if (amountOfMoney >= 100) {
            quantityOfPowers++;
            amountOfMoney = amountOfMoney - 100;
            PlayerPrefs.SetInt("Powers", quantityOfPowers);
            PlayerPrefs.SetInt("CoinCounter", CoinCounter.coinAmount);
        }
        else {
            Debug.Log("no tenes suficiente oro");
        }
    }
}