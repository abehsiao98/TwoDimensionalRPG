using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.SpatialCoordinates.Enums;
using TwoDimensionalRPG.Utilities;

namespace TwoDimensionalRPG.MapObjects.SpatialCoordinates;

public class Coordinate
{
    private static HashSet<(int X, int Y)> _exitCoordinate = new();
    public int X { get; private set; }
    public int Y { get; private set; }
    public Coordinate() => MoveToRandomCoordinate();
    public void MoveToRandomCoordinate()
    {
        var x = 0;
        var y = 0;
        do
        {
            x = RandomSingleton.Instance.Next(0, GameConfig.Map.MaxWidth);
            y = RandomSingleton.Instance.Next(0, GameConfig.Map.MaxHeight);
        } while (!IsValidCoordinate(x, y));
        UpdateCoordinate(x, y);
    }
    public (bool, int x, int y) TryMove(Direction direction)
    {
        (int x, int y) = direction switch
        {
            Direction.Up => (X, Y + 1),
            Direction.Down => (X, Y - 1),
            Direction.Left => (X - 1, Y),
            Direction.Right => (X + 1, Y),
            _ => (X, Y)
        };
        return (IsValidCoordinate(x, y), x, y);
    }
    public void Move(int x, int y) => UpdateCoordinate(x, y);
    public void RemoveCoordinate() => _exitCoordinate.Remove((X, Y));
    private bool IsValidCoordinate(int x, int y) => x >= 0 && x < GameConfig.Map.MaxWidth && y >= 0 && y < GameConfig.Map.MaxHeight && !_exitCoordinate.Contains((x, y));
    private void UpdateCoordinate(int x, int y)
    {
        if (_exitCoordinate.Contains((X, Y)))
            _exitCoordinate.Remove((X, Y));
        (X, Y) = (x, y);
        _exitCoordinate.Add((X, Y));
    }
}