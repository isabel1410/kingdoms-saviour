using UnityEngine;

public class WaveController : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Animator Animator;
    public GameObject ActivateCollider;

    private GameObject enemies;
    private bool activated;

    private bool AreEnemiesDefeated
    {
        get
        {
            foreach (Transform enemy in enemies.transform)
            {
                if (enemy.gameObject.activeSelf)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Activates the enemies in the wave.
    /// </summary>
    public void Activate()
    {
        if (Animator != null)
            Animator.SetBool("Triggered", true);
        PlayerMovement.PauseMovement();
        activated = true;
        ActivateCollider.SetActive(false);
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

        // Enemies won't perform animations on start
        if (Animator != null)
            Animator?.SetBool("Triggered", false);
    }

    private void Update()
    {
        if (activated && AreEnemiesDefeated)
        {
            activated = false;
            PlayerMovement.ResumeMovement();
        }
    }

    [ContextMenu("Finish wave")]
    public void FinishWave()
    {
        foreach (Transform enemy in enemies.transform)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
