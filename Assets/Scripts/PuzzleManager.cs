using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Prefabs das pe�as do quebra-cabe�a
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
                    return; // Se algum slot n�o est� ocupado, ainda n�o completou
            }
            // Todos os slots est�o ocupados
            WinGame();
        }
    void WinGame()
    {
        Debug.Log("Voc� completou o quebra-cabe�a e ganhou o jogo!");
        // Voc� pode adicionar outras a��es aqui, como carregar uma cena de vit�ria
    }
}

