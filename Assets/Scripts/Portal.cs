using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private Transform ColorTeleport;

    [SerializeField] private Transform GreyTeleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GreyCat"))
        {
            collision.transform.position = GreyTeleport.position;
        }
        else if (collision.CompareTag("ColorCat"))
        {
            collision.transform.position = ColorTeleport.position;
        }
    }
}
