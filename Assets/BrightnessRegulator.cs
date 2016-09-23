using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour {
    // Materialを入れる
    Material myMaterial;
    
    // Emissionの最小値
    private float minEmission = 0.3f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    // 発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    // ★変数の初期化と呼び出し
    public int[] points = { 0, 10, 20, 30, 40 };  //タグ別の点数を
    public Score score;

	// Use this for initialization
	void Start () {
        // タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        } else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        } else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.blue;
        }

        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        // オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        // ★点数を表示するオブジェクトを取得、Scoreクラス呼び出し
        score = GameObject.Find("ScoreObj").GetComponent<Score>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            // 現在の角度を小さくする
            this.degree -= this.speed;

        }
	
	}

    // 衝撃時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // 角度を180度に設定
        this.degree = 180;

        // ★衝撃時のオブジェクトによって点数を変更し、point[0]に代入
        if (tag == "SmallStarTag")
        {
            this.points[0] = points[1];
            Debug.Log("小さな星に当たった。" + points[1] + "pt");  // ★コンソールに得点を表示
        }
        else if (tag == "LargeStarTag")
        {
            this.points[0] = points[2];
            Debug.Log("大きな星に当たった。" + points[2] + "pt");
        }
        else if (tag == "SmallCloudTag")
        {
            this.points[0] = points[3];
            Debug.Log("小さな雲に当たった。" + points[3] + "pt");
        }
        else if (tag == "LargeCloudTag")
        {
            this.points[0] = points[4];
            Debug.Log("大きな雲に当たった。" + points[4] + "pt");
        }


        // ★スコアを加算
        score.AddScore(points[0]);

    }
}
