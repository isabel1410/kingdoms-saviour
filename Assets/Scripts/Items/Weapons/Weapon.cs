

using UnityEngine;

public abstract class Weapon : Item
{
    public string Name;
    public float Damage;
    public float Range;

    public void Hit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }

}
