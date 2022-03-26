using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manejador de la puntuacion de en una partida
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    /// <summary>
    /// Texto a proyectar de la puntuacion actual de la partida
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// Texto a proyectar de la puntuacion mas alta de la partida
    /// </summary>
    public Text bestScoreText;

    /// <summary>
    /// Puntuacion actual de la partida
    /// </summary>
    private int score = 0;
    /// <summary>
    /// Puntuacion mas alta de la partida
    /// </summary>
    private int bestScore = 0;
    
    /// <summary>
    /// Nivel en el que se encuentra el jugador
    /// </summary>
    private int gameStage = -1;

    /// <summary>
    /// Nivel en el que se encuentra el jugador
    /// </summary>
    private float gameDifficulty = 1;

    // Se ejecuta antes del Start()
    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("bestScoreStage" + gameStage.ToString());
        scoreText.text = "Test Score: " + score.ToString();
        bestScoreText.text = "Test Best: " + bestScore.ToString();
    }

    /// <summary>
    /// Metodo para seleccionar el nivel en el que esta el jugador, 
    /// que permite guardar su mejor puntuacion hasta el momento
    /// </summary>
    /// <param name="stage">Nivel en el que esta el jugador</param>
    public void selectStage(int stage)
    {
        gameStage = stage;
        PlayerPrefs.GetInt("bestScoreStage" + gameStage.ToString());
        scoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best: " + bestScore.ToString();
    }

    /// <summary>
    /// Metodo que anyade puntos al contador y 
    /// guarda la mejor puntuacion hasta el momento en un nivel del juego
    /// </summary>
    /// <param name="points">Puntos que se deben sumar</param>
    public void addPoints(int points)
    {
        score += points * (int)System.Math.Round(gameDifficulty, 0);
        scoreText.text = "Score: " + score.ToString();

        if (bestScore < score)
        {
            PlayerPrefs.SetInt("bestScoreStage" + gameStage.ToString(), bestScore);
        }
    }

    /* Update is called once per frame
    void Update()
    {
        
    }
    */
}
