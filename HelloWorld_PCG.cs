using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelloWorld_PCG : MonoBehaviour {

    public int seed = 1;
    private string palabraFinal;
    private List<string> letras = new List<string>();
    void Awake() {
        letras.Add("H");
        letras.Add("o");
        letras.Add("l");
        letras.Add("a");
        letras.Add("M");
        letras.Add("u");
        letras.Add("n");
        letras.Add("d");
        letras.Add("o");

    }

    // Use this for initialization
    void Start() {

        Random.seed = seed;
        for (int i = 0; i < letras.Count; i++) {
            palabraFinal += letras[i];
        }
        Debug.Log("Nuestra palabra inicialmente es: " + palabraFinal);

        palabraFinal = "";

        while (letras.Count > 0) {
            int index = Random.Range(0, letras.Count);
            palabraFinal += letras[index];
            letras.RemoveAt(index);

        }
        Debug.Log("Nuestra palabra finalmente es: " +palabraFinal);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
