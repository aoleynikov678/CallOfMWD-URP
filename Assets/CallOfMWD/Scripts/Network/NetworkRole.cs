using System.ComponentModel;

namespace lab.mwd
{
    public enum NetworkRole
    {
        [Description("Учитель")]
        Couch,
        [Description("Ученик")]
        Player
    }
}