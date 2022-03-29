using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    
    private float HInput;
    private float VInput;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");

        if (HInput != 0)
        {
            rigidbody.velocity = new Vector2(HInput * speed, rigidbody.velocity.y);
        }
        if (VInput != 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, VInput * speed);
        }
    }
}
