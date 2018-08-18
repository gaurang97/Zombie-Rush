using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Platform {

    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float speedRock;
	


	void Start () {
        StartCoroutine(Move(bottomPosition));
	}

    protected override void Update()
    {
        if(GameManager.instance.PlayerActive== true)
        {
            base.Update();
        }
        
    }

    IEnumerator Move(Vector3 position)
    {
        while (Mathf.Abs((position - transform.localPosition).y) > 0.2f)
        {
            Vector3 direction = position == topPosition ? Vector3.up : Vector3.down;
            transform.localPosition = transform.localPosition + (direction * speedRock * Time.deltaTime);

            yield return null; 
        }

        yield return new WaitForSeconds(0.3f);

        Vector3 newPosition = position == topPosition ? bottomPosition : topPosition;
        StartCoroutine(Move(newPosition));
    }
	
}
