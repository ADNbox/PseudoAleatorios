using UnityEngine;
using System.Collections;

public class GeneradorCuevas : MonoBehaviour {

    public int anchoCueva = 5;
    public int alturaCueva = 5;
    public int semilla = 26;
    public bool semillaAleatoria = false;
    [Range(0, 100)]
    public int porcentajeMuro = 50;
    public int iteracionesSuavizado = 1;

    private int[,] cueva;

    // Use this for initialization
    void Start() {
        CrearCueva();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CrearCueva();
           
        }
    }

    void CrearCueva() {
        cueva = new int[anchoCueva, alturaCueva];
        LlenarCuevaAleatoriamente();

        for (int i = 0; i < iteracionesSuavizado; i++) {
            SuavizarMapa();
        }
    }
    void LlenarCuevaAleatoriamente() {
        Random.seed = (semillaAleatoria) ? Random.Range(int.MinValue, int.MaxValue) : semilla;
        for (int i = 0; i < anchoCueva; i++) {//filas
            for (int j = 0; j < alturaCueva; j++) {//columnas
                if (i == 0 || i == (anchoCueva - 1) || j == 0 || j == (alturaCueva - 1))
                {
                    cueva[i, j] = 1;
                }
                else {
                    cueva[i, j] = 0;
                }
            }

        }

    }
    void SuavizarMapa() {
        for (int i = 0; i < anchoCueva; i++)
        {//filas
            for (int j = 0; j < alturaCueva; j++) {//columnas
                int cantidadVecinosMuro = ObtenerVecinosMuro(i, j);

                if (cantidadVecinosMuro > 4)
                {
                    cueva[i, j] = 1;
                }
                else {
                    cueva[i, j] = 0;
                }
            }
        }
    }
    int ObtenerVecinosMuro(int x, int y) {
        int cantidadMuros = 0;
        for (int i = x - 1; i < x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < anchoCueva && j >= 0 && j < alturaCueva)
                {
                    if (i != x || j != y)
                    {
                        cantidadMuros += cueva[i, j];
                    }
                    else {
                        cantidadMuros++;
                    }
                }

            }
        }
            return cantidadMuros;
        
    }

    void OnDrawGizmos()
    {
        if (cueva != null)
        {for (int i = 0; i < anchoCueva; i++) {//Filas
                for (int j = 0; j < alturaCueva; j++) {//columnas
                    Gizmos.color = (cueva[i, j] == 0) ? Color.white : Color.black;
                    Gizmos.DrawCube(new Vector3(i,j,0f), new Vector3(0.9f,0.9f,0.9f));
                }
            }


        }
    }

}
