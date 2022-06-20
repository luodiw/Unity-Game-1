using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    public float movementX;
    public float movementY;

    // Start is called before the first frame update
    // Sets value of Rb reference to rigidbody component
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;

      SetCountText();
      // default set for the boolean condition of the "win text"
      winTextObject.SetActive(false);
    }

    // data type, variable name
    private void OnMove(InputValue movementValue)
    {
      Vector2 movementVector = movementValue.Get<Vector2>();
	    movementX = movementVector.x;
      movementY = movementVector.y;
      Debug.Log("Hello");
    }

    void SetCountText()
    {
      countText.text = "Count: " + count.ToString();
      if(count >=8)
      {
        winTextObject.SetActive(true);
      }
    }

    private void FixedUpdate()
    {
      Vector3 movement = new Vector3(movementX, 0.0f, movementY);

      rb.AddForce (movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("PickUp"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;

        SetCountText();
      }
    }

}
