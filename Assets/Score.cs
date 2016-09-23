// ★課題用スクリプト
using UnityEngine;
using System.Collections;
// テキスト表示に使用するコンポーネント
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int score = 0;
    public Text scoreText;  // スコアを表示するテキストのコンポーネントをアタッチ

    // 
    public void AddScore(int addScore)
    {
        this.score += addScore;
        Debug.Log(score);  // コンソールにスコアを表示
        // score変数を文字列に変換して表示
        scoreText.text = score.ToString() + " pt";
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
