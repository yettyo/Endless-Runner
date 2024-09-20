using UnityEngine;
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    private int currentGameCoins = 0;
    private int totalCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Debug.Log("saved coins: " + totalCoins);
    }

    public void AddCoin()
    {
        currentGameCoins++;
        // You can also update the UI here to reflect the new coin count
        Debug.Log("current coins: " + currentGameCoins);
    }

    public void SaveCoins()
    {
        totalCoins += currentGameCoins;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
        currentGameCoins = 0; 
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
