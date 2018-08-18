using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    [SerializeField] private float speed = 1f;
    public float pos;
    [SerializeField] float resetPos = 104.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (GameManager.instance.GameOver != true)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
            if (transform.localPosition.x < pos)
            {
                Vector3 newPos = new Vector3(resetPos, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
	}

}
