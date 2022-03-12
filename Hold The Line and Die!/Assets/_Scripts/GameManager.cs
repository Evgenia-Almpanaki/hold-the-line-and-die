using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> enemySpawns;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private AudioClip enemyCollisionClip;
    [SerializeField] private AudioClip lineChangeClip;

    private AudioSource audioSource;
    private SliderBehaviour hpSlider;
    private float timeLimitNew = 5f;
    private float timeLimit = 5f;
    private float hp = 100;

    public enum ClipType { LINE_CHANGE = 0, ENEMY_COLLISION = 1 }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        hpSlider = FindObjectOfType<SliderBehaviour>();
        Spawn();
    }

    private void Update()
    {
        if (timeLimit < 0)
            Spawn();
        timeLimit -= Time.deltaTime;

        ChangeHealth(Time.deltaTime * 3.3f);
    }

    /// <summary>
    /// Spawns new enemy.
    /// </summary>
    private void Spawn()
    {
        int random = Random.Range(0, 5);
        GameObject enemy = Instantiate(enemyPrefab, enemySpawns[random].transform.position, Quaternion.identity);
        timeLimitNew = Mathf.Clamp(timeLimitNew * 0.95f, .5f, 5f);
        timeLimit = timeLimitNew;
    }

    /// <summary>
    /// Changes the player's health.
    /// </summary>
    /// <param name="healthAmount">The amount to be added to the player's existing health.</param>
    public void ChangeHealth(float healthAmount)
    {
        hp = Mathf.Clamp(hp + healthAmount, -100, 100);
        if (hp <= 0)
        {
            GameOver(false);
            return;
        }
        hpSlider.UpdateSliderUI(hp);
    }

    /// <summary>
    /// Plays a clip once.
    /// </summary>
    /// <param name="cliptype">The clip type to be played</param>
    public void PlayClip(ClipType cliptype)
    {
        if(cliptype == ClipType.ENEMY_COLLISION)
            audioSource.PlayOneShot(enemyCollisionClip);
        else if (cliptype == ClipType.LINE_CHANGE)
            audioSource.PlayOneShot(lineChangeClip);
    }

    /// <summary>
    /// Loads the game over scene with the correct result.
    /// </summary>
    /// <param name="gameover">The game result</param>
    public static void GameOver(bool gameover)
    {
        GameOverText.setGameResult(gameover);
        LevelManager.Load(LevelManager.Scene.GAMEOVER_SCENE);
    }    
}
