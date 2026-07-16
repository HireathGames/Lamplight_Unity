using UnityEngine;
using UnityEngine.Audio;
public class BellRingerMod : CombatModifier
{
    private Player player;
    private AudioSource ring;
    private Transform hand;
    private int cardsPlayed;
    public BellRingerMod(Player target, Transform transform, AudioSource sound)
    {
        player = target;
        hand = transform;
        ring = sound;
    }
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        hand.Rotate(new Vector3(0, 30, 0));
        cardsPlayed++;
        if (cardsPlayed >= 12)
        {
            player.mania--;
            cardsPlayed = 0;
            ring.Play();
        }
    }
}
