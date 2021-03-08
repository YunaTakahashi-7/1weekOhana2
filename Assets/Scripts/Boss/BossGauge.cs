using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BossGauge : MonoBehaviour
{
    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;
 
    private Boss boss;
    private Tween redGaugeTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = boss.life / boss.maxLife;
        var valueTo = (boss.life - reducationValue) / boss.maxLife;
 
        // 緑ゲージ減少
        GreenGauge.fillAmount = valueTo;
 
        if (redGaugeTween != null) {
            redGaugeTween.Kill();
        }
 
        // 赤ゲージ減少
        redGaugeTween = DOTween.To(
            () => valueFrom,
            x => {
                RedGauge.fillAmount = x;
            },
            valueTo,
            time
        );
    }
 
    public void SetBoss(Boss boss)
    {
        this.boss = boss;
    }
}
