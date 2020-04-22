using System.Collections.Generic;

namespace lab.core
{
    public interface IStateStats
    {
        List<StateStatistics> StateStatistics { get; }
        void ClearAllStats();
    }
}