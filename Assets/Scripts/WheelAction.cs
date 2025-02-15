using UnityEngine;
using UnityEngine.UI;



public class WheelAction : MonoBehaviour
{
    private bool spinWheelAnim = false;
    private bool targetSectorOverride = false;
    private int targetSector = 1;
    private int wheelSpinTime = 2;
    private float time = 0;
    private int numOfSectors = 8;   //update to match number of items in sectorChance
    private int[] sectorChance = {20, 10, 10, 10, 5, 20, 5, 20}; //update number of items in array to match numOfSectors

    
    public Button spinButton;
    public Image wheelBackground;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(spinWheelAnim){
            //disable button
            //animate wheel
            if(time < wheelSpinTime){
                AnimateWheel();
            }
            else{//after n time stop on targetSector

                //snap to target sector
                wheelBackground.transform.eulerAngles = new Vector3(0,0, (targetSector*45)-22.5f);
                //reset spinWheelAnim to false
                spinWheelAnim = false;
                //enable button

            }
        }
    }

    void AnimateWheel(){
        
        if(time<.15){
            wheelBackground.transform.Rotate(0, 0, -1  , Space.World);
        }
        else{
            wheelBackground.transform.Rotate(0, 0, 20, Space.World);
        }
        
    }

    public void OnClickPlay(){
        spinWheelAnim = true;
        time = 0;
        int rand = Random.Range(1, 100);// get rand 
        int prevSecChance = 0; 
        

        //find target sector based on rand
        //for n number of sectors add current chance probability until rand is reached
        if(!targetSectorOverride){
            targetSector = 0;
            for(int i = 1; i <= numOfSectors && targetSector==0; i++){
                int currentSecChance = sectorChance[i-1];
                if(rand <= prevSecChance + currentSecChance){
                    targetSector = i;
                }
                prevSecChance = prevSecChance + currentSecChance;
            }
        }
        
    }

    public void SetTargetSector(int n){

        targetSector = n;
    }

    public int GetTargetSector(){
        return targetSector;
    }
}
