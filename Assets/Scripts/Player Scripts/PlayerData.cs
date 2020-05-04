[System.Serializable]
public class PlayerData 
{
    // data ... get from game
    
    public float pX, pY, pZ;
   

    public PlayerData(PlayerMovement player)
    {
        
       
        //position
        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;
      
       
    }
}    
