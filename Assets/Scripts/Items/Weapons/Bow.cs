using UnityEngine;

public class Bow : Weapon
{
    public RaycastHit hit;

    public Bow(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        base.Use();
        ////Deal damage to enemy
        //throw new System.NotImplementedException("Deal damage to enemy.");
        Debug.Log("Arrow fired");
        //if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Range))
        //{
        //    Debug.Log(hit.transform.name);
        //}
    }

}
