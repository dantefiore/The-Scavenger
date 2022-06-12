using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GenericDmg : MonoBehaviour
{
    [SerializeField] private float dmg; //the amount of damage dealt
    [SerializeField] private string targetTag;    //the tag it can attack

    private void OnTriggerEnter(Collider other)
    {
        //the objects tag is the same as the tag variables
        if (other.gameObject.CompareTag(targetTag) && other.isTrigger)
        {
            //takes in the enemies health
            GenericHealth temp = other.gameObject.GetComponent<GenericHealth>();
            
            //if the health is not null, it does damage
            if (temp != null)
            {
                temp.Damage(dmg);
            }
        }
    }
}

