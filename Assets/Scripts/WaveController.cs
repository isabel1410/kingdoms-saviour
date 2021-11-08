using UnityEngine;

public class WaveController : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Animator Animator;
    public bool enemiesActivated;
    private GameObject enemies;

    /// <summary>
    /// Activates the enemies in the wave.
    /// </summary>
    public void Activate()
    {
        if (Animator != null)
            Animator.SetBool("Triggered", true);
        enemiesActivated = true;
        PlayerMovement.PauseMovement();
        Debug.Log(name + " activated");
    }

    /// <summary>
    /// Loads the enemies in the wave.
    /// </summary>
    public void Load()
    {
        enemies.SetActive(true);
        Debug.Log(name + " loaded");
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemies = transform.Find("Enemies").gameObject;

        // Hide on start (useful for editing puroposes)
        enemies.SetActive(false);
        enemiesActivated = false;

        // Enemies won't perform animations on start
        if (Animator != null)
            Animator?.SetBool("Triggered", false);
    }
}
