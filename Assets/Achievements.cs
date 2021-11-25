using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private bool _walkedTenMeters;
    private bool _walkedOneKilometer;
    private bool _walkedOneHundredMeters;
    private float _distanceMoved;

    private bool _deadThreeTimes;
    private int _deathCount;
    private bool _deadOneTime;

    public static float bulletCreated;
    private bool _oneHundredDodged;
    private bool _threeHundredDodged;
    private bool _fiveHundredDodged;

    private static int _peopleTouched;
    private bool _tenPersonTouched;
    private bool _fifthyPersonTouched;

    private bool _oneSecondPast;
    private bool _oneMinutePast;
    private bool _threeMinutesPast;

    public UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        CubeMovement.OnPlayerMoved += delegate(float distance)
        {
            _distanceMoved += distance;
            if (_distanceMoved >= 10f && !_walkedTenMeters)
            {
                UIManager.ShowAchievement("C'est bien tu sais mettre un pied devant l'autre", "Marcher 10 mètres");
                _walkedTenMeters = true;
            }
            if (_distanceMoved >= 100f && !_walkedOneHundredMeters)
            {
                UIManager.ShowAchievement("Eh, plus qu'Usain Bolt", "Marcher 100 mètres");
                _walkedOneHundredMeters = true;
            }
            if (_distanceMoved >= 1000f && !_walkedOneKilometer)
            {
                UIManager.ShowAchievement("Un kilomètre à pied, ça use, ça use...", "Marcher un kilomètre");
                _walkedOneKilometer = true;
            }
        };
        
        KillAndRespawn.OnPlayerDeath += delegate
        {
            _deathCount++;
            if (_deathCount >= 1 && !_deadOneTime)
            {
                UIManager.ShowAchievement("Les passages piétons c'est pour qu'il y ait des piétons !", "Sortir du carrefour 1 fois");
                _deadOneTime = true;
            }
            if (_deathCount >= 3 && !_deadThreeTimes)
            {
                UIManager.ShowAchievement("Le feu est toujours vert", "Mourrir 3 fois");
                _deadThreeTimes = true;
            }
        };
        Bullet.OnPlayerTouched += delegate
        {
            _peopleTouched++;
            if (_peopleTouched >= 10f && !_tenPersonTouched)
            {
                UIManager.ShowAchievement("Faut regarder où tu marches là !", "Rentrer dans 10 personnes");
                _tenPersonTouched = true;
            }

            if (_peopleTouched >= 50f && !_fifthyPersonTouched)
            {
                UIManager.ShowAchievement("Tiens, tu veux mes lunettes ?", "Rentrer dans 50 personnes");
                _fifthyPersonTouched = true;
            }
        };
        Score.ScoreUp += delegate
        {
            if (Score.GameScore >= 100 && !_oneHundredDodged)
            {
                UIManager.ShowAchievement("C'est un endroit connu en même temps", "Obtenir un score de 100");
                _oneHundredDodged = true;
            }
            if (Score.GameScore >= 300 && !_threeHundredDodged)
            {
                UIManager.ShowAchievement("Il y a beaucoup de monde par ici", "Obtenir un score de 300");
                _threeHundredDodged = true;
            }

            if (Score.GameScore >= 500 && !_fiveHundredDodged)
            {
                UIManager.ShowAchievement("Tu viens de débloquer l'ultra instinct", "Obtenir un score de 500");
                _fiveHundredDodged = true;
            }
        };
        TimeInGame.TimerIncrease += delegate
        {
            if (TimeInGame.timer >= 1f && !_oneSecondPast)
            {
                UIManager.ShowAchievement("Ah, ça viens de passer au vert", "Jouer pendant une seconde");
                _oneSecondPast = true;

            }
            if (TimeInGame.timer >= 60f && !_oneMinutePast)
            {
                UIManager.ShowAchievement("Il est vachement long ce feu quand même", "Jouer pendant une minute");
                _oneMinutePast = true;
            }
            if (TimeInGame.timer >= 180f && !_threeMinutesPast)
            {
                UIManager.ShowAchievement("Bon faudrait fermer le jeu maintenant", "Jouer pendant trois minutes");
                _threeMinutesPast = true;
            }
        };
    }
}
