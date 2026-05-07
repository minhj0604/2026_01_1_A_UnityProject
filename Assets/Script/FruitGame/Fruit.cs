using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitType;               //과일 index 설정 (0:사과, 1:블루베리, 2:코코넛)
    public bool hasMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*   if (hasMerged)
           {
               return;
           }
           Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

           if (otherFruit != null && !otherFruit.hasMerged && otherFruit.fruitType == fruitType)
           {
               hasMerged = true;
               otherFruit.hasMerged = true;

               Vector3 mergePosition = (transform.position + otherFruit.transform.position) / 2f;

               Destroy(otherFruit.gameObject);
               Destroy(gameObject);
           } */
    }

}
