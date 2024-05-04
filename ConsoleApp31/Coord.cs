namespace ConsoleApp31;

internal struct Coord
{
    private char _xCoord;
    private int _yCoord;
    public Coord(char x, int y)
    {
        xCoord = x;
        yCoord = y;
    }
    public char xCoord
    {
        get { return _xCoord; }
        set { _xCoord = value; }
    }
    public int yCoord
    {
        get { return _yCoord; }
        set { _yCoord = value; }
    }

}

enum Figure
{
    K, //king
    Q, //queen
    B, //bishop
    R, //rook
    N   //knight(dzi)
}


enum tox
{
    A, B, C, D, E, F, G, H
}