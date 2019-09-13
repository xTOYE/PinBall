using UnityEngine;
using System.Collections;

public class Floatpiece : MonoBehaviour
{
    // Sound & Animation
    public GameObject handcamObj;
    public GameObject golightObj;
    private SpriteRenderer handcamRenderer;
    private SpriteRenderer golightRenderer;
    private AnimateController handcamAniController;
    private AnimateController golightAniController;
    private SoundController sound;

    // Score
    private ScoreBoard scoreBoard;

    // #1

    void Start()
    {
        // Get scoreboard and sound object
        GameObject obj = GameObject.Find("scoreText");
        scoreBoard = obj.GetComponent<ScoreBoard>();
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        // Animation objects
        handcamRenderer = handcamObj.GetComponent<Renderer>() as SpriteRenderer;
        golightRenderer = golightObj.GetComponent<Renderer>() as SpriteRenderer;
        handcamAniController = handcamObj.GetComponent<AnimateController>();
        golightAniController = golightObj.GetComponent<AnimateController>();
        //#2
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            //#3
            sound.bonus.Play();
            scoreBoard.gamescore = scoreBoard.gamescore + 10;
            golightRenderer.sprite = golightAniController.spriteSet[0];
            StartCoroutine(BeginFloat());

        }
    }

    // #4
    IEnumerator BeginFloat()
    {
        while (true)
        {
            
            // Play animation loop
            int index = (int)Mathf.PingPong(handcamAniController.fps * Time.time, handcamAniController.spriteSet.Length);
            handcamRenderer.sprite = handcamAniController.spriteSet[index];
            yield return new WaitForSeconds(0.1f);

            // Stop & Reset Timer 
            sound.bonus.Stop();
            golightRenderer.sprite = golightAniController.spriteSet[1];
            handcamRenderer.sprite = handcamAniController.spriteSet[handcamAniController.spriteSet.Length - 1];
            break;
        } 
    }
}

