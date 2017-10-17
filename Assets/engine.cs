using UnityEngine;
using System.Runtime.InteropServices;

public class engine : MonoBehaviour {


    [DllImport("__Internal")]
    private static extern string Receive();

    [DllImport("__Internal")]
    private static extern void Send(string str);

    // Use this for initialization
    void Start () {
        Debug.Log("Starting");
        string json = Receive();
        // Check SQL possibilities
        // Check HTTP GET requests
        Debug.Log(json);
        Send(PickWinner(json));
	}


    // Simple function to pick a winner
    string PickWinner(string data)
    {
        GameInfo game = GameInfo.CreateFromJSON(data);
        // check for null object (bad json)
        Debug.Log(game.homeTeam);
        Debug.Log(game.awayTeam);    
        game.homeScore = 0;
        game.awayScore = 0;
        do
        {
            game.homeScore = Random.Range(0, 6);
            game.awayScore = Random.Range(0, 6);
        } while (game.homeScore == game.awayScore);


        if (game.homeScore > game.awayScore)
        {
            game.winner = game.homeTeam;
        }
        else game.winner = game.awayTeam;

        Debug.Log("done");
        return game.ToJson();
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    // A game object -> created from json data
    [System.Serializable]
    public class GameInfo
    {
        public string homeTeam;
        public string awayTeam;
        public int homeScore;
        public int awayScore;
        public string winner;

        public GameInfo()
        {            
        }

        public static GameInfo CreateFromJSON(string jsonString)
        {

            return JsonUtility.FromJson<GameInfo>(jsonString);
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
