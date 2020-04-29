using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGunController : MonoBehaviour
{
    public Transform gunTip;
    public GameObject balloonPrefab;
    public float startScale = 0.1f;
    public float growRate = 1.5f;
    public float maxScale = 1.0f;
    public float shootVelocity = 3.0f;

    private GameObject balloon;
    private Rigidbody rb;

    private void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void CreateBalloon()
    {
        balloon = Instantiate(balloonPrefab, gunTip.transform);
        balloon.transform.localScale = new Vector3(startScale, startScale, startScale);
        rb = balloon.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void ReleaseBalloon()
    {
        balloon.transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = gunTip.forward * shootVelocity;

        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }

    public void GrowBalloon()
    {
        if (balloon.transform.localScale.x > maxScale)
            return;

        Vector3 changeScale = balloon.transform.localScale * growRate * Time.deltaTime;
        balloon.transform.localScale += changeScale;
}
}
