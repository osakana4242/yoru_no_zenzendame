using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace OSK42
{
    [System.Serializable]
    public class TextPlayableAsset : PlayableAsset
    {
        public string text;

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var bh = new TextPlayableBehaviour();
            bh.text = this.text;
            //Debug.LogFormat( "{0} {1} {2}", this.GetInstanceID(), this.name, this.text );
            var playable = ScriptPlayable<TextPlayableBehaviour>.Create(graph, bh);
            return playable;
        }
    }
}