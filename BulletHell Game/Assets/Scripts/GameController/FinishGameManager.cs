using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinishGameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject gamecontroller;
    public GameObject projectileController;
    public GameObject cam;
    public GameObject cameraAnchor;
    public GameObject scoreGameObject;
    public GameObject scoreboard;
    public GameObject rocketPlayer;
    public GameObject restartGame;

    private float playerHealth;
    public float timeShowScoreAfterDeath = 3f;
    public int finalScore;
    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<Health>().currentHealth;

        finalScore = scoreGameObject.GetComponent<Score>().scoreToUseForScripts;

        if (playerHealth < 0)
        {
            StartCoroutine(GameOver());
            
        }
        if (gamecontroller.GetComponent<GameController>().enabled ==false && Input.GetButtonDown("Reset"))
        {
            StartCoroutine(StartGame());
        }

            
            
    }

    IEnumerator GameOver()
    {
        //opreste Game manager.
        gamecontroller.GetComponent<GameController>().enabled = false;
        //opreste camera movement
        cameraAnchor.GetComponent<rotatePointWithMouse>().enabled = false;
        //opreste enemy
        enemy.GetComponent<Enemy_Pattern_1>().enabled = false;
        enemy.GetComponent<Enemy_Pattern_2>().enabled = false;
        enemy.GetComponent<Enemy_Pattern_3>().enabled = false;
        //opreste player
        player.GetComponent<ThirdPersonMovement>().enabled = false;
        //opreste proiectile
        projectileController.GetComponent<ProjectileController>().enabled = false;
        //add grayscale
        cam.GetComponent<PostProcess>().enabled = true;
        scoreGameObject.SetActive(false);
        rocketPlayer.SetActive(false);
        restartGame.SetActive(true);
        Cursor.visible = true;

        ScorePassedToAnotherScene.gameScore = scoreGameObject.GetComponent<Score>().scoreToUseForScripts;
        //asteapta cateva sec
        yield return new WaitForSeconds(timeShowScoreAfterDeath);

        //load scoreboard scene

        SceneManager.LoadScene("ScoreBoard");
        //scoreboard.SetActive(true);
    }


    IEnumerator StartGame()
    {
        player.GetComponent<Health>().currentHealth = 100;
        gamecontroller.GetComponent<GameController>().enabled = true;
        cameraAnchor.GetComponent<rotatePointWithMouse>().enabled = true;

        projectileController.GetComponent<ProjectileController>().enabled = true;
        cam.GetComponent<PostProcess>().enabled = false;
        Cursor.visible = false;
        scoreGameObject.SetActive(true);
        //scoreboard.SetActive(false);
        rocketPlayer.SetActive(true);
        restartGame.SetActive(false);
        yield return new WaitForSeconds(timeShowScoreAfterDeath);
        player.GetComponent<ThirdPersonMovement>().enabled = true;

    }
}
