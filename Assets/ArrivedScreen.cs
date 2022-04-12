using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrivedScreen : MonoBehaviour
{
    public ADModule rewardWindow;

    public TMP_Text valueText;

    public LTDescr leanScore;
    public LTDescr leanReward;

    [ContextMenu("Display Reward")]
    public void DisplayReward()
    {
        valueText.text = ((int)GameData.deliveryPoint).ToString();
        GameScreen.main.SetDpoint(GameScreen.main.score);
        LeanTween.delayedCall(1, rewardWindow.Appear);
        LeanTween.delayedCall(3, AnimateReward);
        LeanTween.delayedCall(5, World.End);
    }

    public void AnimateReward()
    {
        float reward = GameScreen.main.score * CargoHandler.value;
        leanScore = gameObject.LeanValue((i) => GameScreen.main.SetDpoint((int)i), GameScreen.main.score, 0, 1f).setEaseInOutSine().setOnComplete(() => GameScreen.main.SetDpoint(0));
        leanReward = gameObject.LeanValue((i) => valueText.text = ((int)i).ToString(), GameData.deliveryPoint, GameData.deliveryPoint + reward, 1f).setEaseInOutSine();
        GameData.deliveryPoint += reward;
        UserData.Save();
    }

}
