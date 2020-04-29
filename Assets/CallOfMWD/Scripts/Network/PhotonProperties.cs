using System.Collections.Generic;

namespace lab.mwd
{
    public static class PhotonProperties
    {
        private static readonly Dictionary<RoomProperty, string> customProp = new Dictionary<RoomProperty, string>
        {
            { RoomProperty.NetworkRole, "NetworkRole" },
        };

         public static string CustomProp(RoomProperty prop) => customProp[prop];
    }
}