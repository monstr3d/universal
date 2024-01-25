using Trading.Library.Enums;

namespace Trading.Library
{
    public static class StaticExtensionTradingLibrary
    {
        public static PositionType ToPositionType(this double? position)
        {
            if (position == null)
            {
                return PositionType.None;
            }
            else
            {
                var a = position.Value;
                switch (a)
                {
                    case 0: return PositionType.None;
                    case 1: return PositionType.Short;
                    case 2: return PositionType.Long;

                }
                throw new ArgumentException("Illegal position type", " " + a);
            }
        }

        public static PositionDirection ToDirection(this PositionDirection direction, 
            
            PositionType position, PositionType last)
        {
            if (position == last)
            {
                return direction;
            }
            return direction == PositionDirection.Opened ? 
                PositionDirection.Closed : PositionDirection.Opened;
        }
    }
}