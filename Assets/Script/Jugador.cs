using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour {
    public AudioClip jumpClip;
    public AudioSource jumpSound;
    public GameManager gameManager;
    public float fuerzaDeSalto;
    public int saltos = 2;
    protected bool youLost = false;
    private int quantityOfPowers;
    public bool powerActivated = false;
    public float cooldown = 15f;
    public float timer = 0f;
    //public GameObject LevelLoader;
    //public LevelLoader levelloader;

    private Rigidbody2D rigidBody2D;
    private Animator animator;

    // Start is called before the first frame update
    private void Start() {
        //jumpSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        quantityOfPowers = PlayerPrefs.GetInt("Powers");
        //levelloader = GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (saltos > 0 && youLost == false) {
                saltos--;                                               // Le queda un salto antes de llegar al piso
                rigidBody2D.AddForce(new Vector2(0, fuerzaDeSalto));    //le agrega fuerza para saltar
                animator.SetBool("estaSaltando", true);                 //Cambia la animacion a la de salto
                //jumpSound.PlayOneShot(jumpClip, 0.3f);                      //hace el sonidito de jumpSound
            }
        }

        if (powerActivated == true) {
            timer += Time.deltaTime;
        }

        while(timer > cooldown) {
            timer = 0f;
            powerActivated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "suelo") {
            animator.SetBool("estaSaltando", false);    // Cada vez que choque contra el piso, se activa de vuelta la animacion de correr
            saltos = 2;                                 // vuelve a tener dos saltos.
        }
        if (collision.gameObject.tag == "Obstaculo") {
            Debug.Log("Te chocaste un obstaculo");
            //if (powerActivated == true) {
            //    Debug.Log("el poder esta activo");
            //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //}
            //else {
                /*if (quantityOfPowers > 0) {
                    Debug.Log("poder activado");
                    powerActivated = true;
                    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }
                else {*/
                    Debug.Log("te chocaste una piedra");
                    fuerzaDeSalto = 0;
                    youLost = true;
                    StartCoroutine(LoadLevelAfterDelay());
                //}
            //}
        }
    }

    

    

    private IEnumerator LoadLevelAfterDelay() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}