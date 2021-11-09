using UnityEngine;

public class WaveController : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Animator Animator;
    public bool enemiesActivated;
    GameObject[] enemies;

    /// <summary>
    /// Activates the enemies in the wave.
    /// </summary>
    public void Activate()
    {
        enemiesActivated = true;
        PlayerMovement.PauseMovement();
        Debug.Log(name + " activated");

        // Each enemy triggers and will start to attack
        foreach (GameObject enemy in enemies)
        {
            enemy.gameObject.GetComponentInChildren<Animator>().SetBool("Triggered", true);
            StartCoroutine(enemy.transform.gameObject.GetComponentInChildren<Enemy>().Attack(enemy));
            //enemy.transform.gameObject.GetComponentInChildren<Enemy>().Attack(enemy);
        }
    }

    /// <summary>
    /// Loads the enemies in the wave.
    /// </summary>
    public void Load()
    {
        // Set every enemy active
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
        Debug.Log(name + " loaded");
    }

    // Start is called before the first frame update
    private void Start()
    {
        //enemies = transform.Find("Enemies").gameObject;
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Debug.Log(enemies);

        // Hide on start (useful for editing puroposes)
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);

            // Enemies won't perform animations on start
            enemy.gameObject.GetComponentInChildren<Animator>().SetBool("Triggered", false);
        }
        enemiesActivated = false;
    }
}
