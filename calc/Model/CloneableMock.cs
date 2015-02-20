using System;

namespace calc.Model
{
    public class CloneableMock : ICloneable
    {
        private int _cloneCallCount = 0;

        public int GetCloneCallCount()
        {
            return _cloneCallCount;
        }

        public object Clone()
        {
            _cloneCallCount++;
            return new CloneableMock();
        }
    }
}
