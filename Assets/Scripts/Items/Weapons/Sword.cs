using UnityEngine;

public class Sword : Weapon
{
    //private string selected;
    //public RaycastHit hit;
    //public Camera playerCamera;


    public Sword(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        base.Use();
        //Deal damage to enemy
        //throw new System.NotImplementedException("Deal damage to enemy");
        Debug.Log("Sword used!");
        //if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Range))
        //{
        //    Debug.Log(hit.transform.name);
        //}
    }
}
