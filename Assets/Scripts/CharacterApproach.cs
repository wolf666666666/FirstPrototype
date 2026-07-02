using UnityEngine;

public class CharacterApproach : MonoBehaviour
{
    public Transform endPoint;
    public float speed = 3f;
    public static CharacterApproach instance;
    public bool canWalk = false;
    public GameObject endPointObject;

    public void Update()
    {
        if (canWalk == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == endPointObject)
        {
            canWalk = false;
        }
    }

    public void Walk()
    {
        canWalk = true;
    }
}
