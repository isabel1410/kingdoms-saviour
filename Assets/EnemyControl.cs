using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject[] Waves;
    public WaypointsFree.WaypointsTraveler Traveler;
    private int colliderCount;

    // Start is called before the first frame update
    void Start()
    {
        colliderCount = 0;

        //Set waves to inactive, allowing developers to see it in the editor without having to disable the waves when testing
        for (byte counter = 0; counter < Waves.Length; counter++)
        {
            Waves[counter].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliders countered: " + colliderCount);
        
        switch (colliderCount)
        {
            case 0:
                Waves[0].SetActive(true);
                Debug.Log("Wave 1 set active");
                break;
            case 1:
                Traveler.MoveSpeed = 0;
                Debug.Log("Speed set to 0");
                break;
        }

        colliderCount++;
    }
}
