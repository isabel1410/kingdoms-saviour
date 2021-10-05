using UnityEngine;

public class WaveController : MonoBehaviour
{
    public PlayerMovement Movement;
#if (UNITY_EDITOR)
    public bool Logging;
#endif

    [SerializeField] Animator animator;
    private GameObject enemies;
    private bool loaded;

    // Start is called before the first frame update
    private void Start()
    {
        enemies = transform.Find("Enemies").gameObject;

        //Hide on start
        enemies.SetActive(false);
        loaded = false;

        // Enemies won't perform animations on start
        animator.SetBool("Triggered", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if collider belongs to player (prevent arrows and such from activating wave)
        if (other.gameObject.CompareTag("Player"))
        {
            if (!loaded)
            {

                enemies.SetActive(true);
                loaded = true;
#if (UNITY_EDITOR)
                if (Logging)
                {
                    Debug.Log(name + " loaded");
                }
#endif
            }
            else
            {
                animator.SetBool("Triggered", true);
                Movement.Speed = 0;
#if (UNITY_EDITOR)
                if (Logging)
                {
                    Debug.Log(name + " activated");
                }
#endif
            }
        }
    }
}
