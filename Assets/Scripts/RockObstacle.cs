using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MovingObject {
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float rockSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move(bottomPosition));
	}

 //   Uses default Update from MovingObject class
 //   protected override void Update()
 //   {
 //       base.Update();
	//}

    private IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target -transform.localPosition).y) > 0.2f)
        {
            Vector3 direction = target.y == topPosition.y ?
                Vector3.up : Vector3.down;
            transform.localPosition += direction * rockSpeed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }
}
