using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float hrStrengh;
    private float originalHrStrengh;
    public float vrtStrengh;
    public float destructionTime;

    // Start is called before the first frame update
    void Start()
    {
        originalHrStrengh = hrStrengh;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().enabled = false;

            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            if (other.transform.position.x < transform.position.x)
                hrStrengh *= -1;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hrStrengh, vrtStrengh), ForceMode2D.Impulse);

            Destroy(other.gameObject, destructionTime);

            hrStrengh = originalHrStrengh;
        }

    }
}
