using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestScripts
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestScriptsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestScriptsWithEnumeratorPasses()
    {
        //unlcear on directions for unit testing, test runs 1000 spins and outputs results
        SceneManager.LoadScene(0);

        yield return new WaitForSeconds(2f);

        GameObject MainCanvas = GameObject.Find("MainCanvas");
        WheelAction WheelAction = MainCanvas.GetComponent<WheelAction>();
        
        yield return new WaitForSeconds(1f);
        
        int[] results = new int[9]; // use 1-8
        for(int i = 0; i < results.Length; i++){
            results[i] = 0;
        }
        for(int i = 1; i<= 1000;i++){
            WheelAction.OnClickPlay();
            yield return new WaitForSeconds(3);
            int targetSector = WheelAction.GetTargetSector();
            results[targetSector] += 1;
        }
        string resultString ="SPIN RESULTS!\n";
        for(int i = 1; i < results.Length; i++){
            switch(i){
                case 1:
                resultString += "Life 30 min: ";
                break;
                case 2:
                resultString += "Brush 3x: ";
                break;
                case 3:
                resultString += "Gems 35: ";
                break;
                case 4:
                resultString += "Hammer 3x: ";
                break;
                case 5:
                resultString += "Coins 750: ";
                break;
                case 6:
                resultString += "Brush 1x: ";
                break;
                case 7:
                resultString += "Gems 75: ";
                break;
                case 8:
                resultString += "Hammer 1x: ";
                break;
            }
            resultString += results[i] + "\n";
        }
        Debug.Log(resultString);

        
        yield return null;
    }
}
