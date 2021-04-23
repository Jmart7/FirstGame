using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool gameOver = false;
    public GameObject col;
    public Renderer fondo;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject caja;
    public float velocidad = 2;
    public bool start = false;
    public GameObject dejaVU;
    public GameObject coin;
    public float cooldown = 15f;
    public float timer = 0f;

    public List<GameObject> cols;
    public List<GameObject> obstacles;
    public List<GameObject> coins;

    // Start is called before the first frame update
    private void Start() {
        //Crear Mapa
        for (int i = 0; i < 21; i++) {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));         //primero el objeto, segundo la posicion inicial y ultimo la rotacion del objeto
        }

        //Crear Piedras

        obstacles.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
        obstacles.Add(Instantiate(caja, new Vector2(22, 1), Quaternion.identity));
        coins.Add(Instantiate(coin, new Vector2(16, 0), Quaternion.identity));

        //freeze time
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    [System.Obsolete]
    private void Update() {
        if (start == false) {
            {
                Time.timeScale = 1f;        //Starts the game
                start = true;
            }
        }

        if (start == true && gameOver == false) {
            timer += Time.deltaTime;
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime; //vector2 refers to a vector x and y, I'm moving while updating the offset.

            //Mover Mapa4
            for (int i = 0; i < cols.Count; i++) {
                if (cols[i].transform.position.x <= -10) {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mover obstacles
            float[] v = new float[4] { 19, 20, 21, 22 };
            float randomObsX;
            float randomObsY;
            for (int i = 0; i < obstacles.Count; i++) {
                if (obstacles[i].transform.position.x <= -10) {
                    if (i == 0)             //1st Stone
                        {
                        //obstacles.RemoveAt(i);
                        //DestroyObject(obstacles[i]);
                        //obstacles.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
                        randomObsX = Random.Range(11, 14); //Random between 11 and 14, it is the rand() of c#
                        randomObsY = -2;
                    }
                    else if (i == 1) {      //2nd Stone
                        //obstacles.RemoveAt(i);
                        //DestroyObject(obstacles[i]);
                        //obstacles.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
                        int randomIndex = Random.Range(0, 3); //chooses between 18, 19, 20 or 21.
                        randomObsX = v[randomIndex];
                        randomObsY = -2;
                    }
                    else                  //Box
                        {
                        //obstacles.RemoveAt(i);
                        //DestroyObject(obstacles[i]);
                        //obstacles.Add(Instantiate(caja, new Vector2(22, 1), Quaternion.identity));
                        randomObsX = Random.Range(23, 25);
                        randomObsY = Random.Range(-1, 1);
                    }
                    obstacles[i].transform.position = new Vector3(randomObsX, randomObsY, 0);
                    //obstacles.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
                    //obstacles.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
                    //obstacles.Add(Instantiate(caja, new Vector2(22, 1), Quaternion.identity));
                }
                obstacles[i].transform.position = obstacles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Generate Coins
            for (int i = 0; i < coins.Count; i++) {
                if (coins[i] != null) {
                    coins[i].transform.position = coins[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad; //Mueve el coin.
                }
            }

            while (timer > cooldown)    //25 seconds interval.
                {
                float randomCoinsX = Random.Range(11, 18); //Random between 11 and 18.
                float randomCoinsY = Random.Range(-1, 3);  //Random between -1 and 3
                coins.Add(Instantiate(coin, new Vector2(randomCoinsX, randomCoinsY), Quaternion.identity)); //generates a new coin between 11 and 18 on the x-axis and between -1 and 3 for the y-axis
                timer -= cooldown;
                velocidad += 0.5f;
            }
        }
    }
}