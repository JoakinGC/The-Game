using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI levelCleared;

	

	public TextMeshProUGUI totalFruits;

	public TextMeshProUGUI fuitsColleted;

	private int totalFuitsInLevel;

	private void Start(){
		totalFuitsInLevel = transform.childCount;
	}

    private void Update()
    {
        AllMoneyCollected();
		totalFruits.text = totalFuitsInLevel.ToString();
		fuitsColleted.text = transform.childCount.ToString();
    }

    public void AllMoneyCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, victoria");

            // Verificar si levelCleared no es nulo antes de manipularlo
            if (levelCleared != null)
            {
                levelCleared.gameObject.SetActive(true);
                StartCoroutine(ChangeSceneAfterDelay(1.0f));
            }
            else
            {
                Debug.LogWarning("El objeto 'levelCleared' no está asignado en el inspector.");
            }
        }
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            
            SceneManager.LoadScene(0);
        }
    }

}
