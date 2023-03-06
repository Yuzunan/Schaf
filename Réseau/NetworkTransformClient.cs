using Unity.Netcode.Components;

namespace Schaf.Réseau
{
    public class NetworkTransformClient : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}
