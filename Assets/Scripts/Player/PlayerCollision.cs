using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Player playerScript;
    public MeshRenderer meshRenderer;

    public GameController gameController;

    public ParticleSystem destroyParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Instantiate(destroyParticle.gameObject, transform.position, transform.rotation);
            meshRenderer.enabled = false;
            gameController.GameOver();
            playerScript.enabled = false;
        }
    }

}
