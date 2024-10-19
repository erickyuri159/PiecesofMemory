using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Prefabs das peças do quebra-cabeça
    public Vector2 mapSize; // Tamanho do mapa
    public PuzzleSlot[] puzzleSlots;
    void Start()
    {
        SpawnPuzzlePieces();
        puzzleSlots = FindObjectsOfType<PuzzleSlot>();

        void SpawnPuzzlePieces()
        {
            foreach (GameObject piece in puzzlePieces)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(-mapSize.x / 2, mapSize.x / 2),
                    Random.Range(-mapSize.y / 2, mapSize.y / 2)
                );

                Instantiate(piece, randomPosition, Quaternion.identity);
            }
        }
       
    } public void CheckCompletion()
        {
            foreach (PuzzleSlot slot in puzzleSlots)
            {
                if (!slot.isOccupied)
                    return; // Se algum slot não está ocupado, ainda não completou
            }
            // Todos os slots estão ocupados
            WinGame();
        }
    void WinGame()
    {
        Debug.Log("Você completou o quebra-cabeça e ganhou o jogo!");
        // Você pode adicionar outras ações aqui, como carregar uma cena de vitória
    }
}

