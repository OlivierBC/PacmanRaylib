using Raylib_cs;

class Map
{
    // 0 = wall, > 0 == walkable: 1 = pellet, 2 = power pellet, 3(goUp) / 4(goRight) / 5(goLeft) = OneDirectionalPaths 
    int[,] map = new int[,]
{
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,0,0,0,0,1,0,0,0,0,0,1,1,2,0,0,0,0,0,1,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,0,1,1,1,1,1,1,0},
        {0,1,0,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,1,0},
        {0,1,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,1,0,1,0,1,1,1,1,1,0,1,0},
        {0,1,0,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,1,0,0,0,1,0,0,0,1,0},
        {0,1,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,0,1,0},
        {0,1,0,0,0,0,1,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,1,0},
        {0,1,1,1,1,1,1,0,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,0,0,0,0,0,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0},
        {0,1,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,1,0},
        {0,1,1,1,1,0,1,2,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,0},
        {0,1,0,0,1,0,1,0,0,1,0,1,0,0,3,0,0,1,0,0,0,0,0,1,0,0,0,1,0},
        {0,1,1,0,1,0,1,1,1,1,0,1,0,4,3,5,0,1,0,1,1,1,1,1,1,1,0,2,0},
        {0,1,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,1,0},
        {0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0},
        {0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,0},
        {0,1,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,0,1,0},
        {0,1,0,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,1,0,1,0},
        {0,1,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,0,2,1,1,1,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0},
        {0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0},
        {0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
        {0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
};
    bool[,] pellets;
    bool[,] powerPellets;

    public Map()
    {
        //Set pellets
        pellets = new bool[map.GetLength(0), map.GetLength(1)];
        powerPellets = new bool[map.GetLength(0), map.GetLength(1)];
        for (int rowNum = 0; rowNum < pellets.GetLength(0); rowNum++)
        {
            for (int colNum = 0; colNum < pellets.GetLength(1); colNum++)
            {
                pellets[rowNum, colNum] = map[rowNum, colNum] == 1;
                powerPellets[rowNum, colNum] = map[rowNum, colNum] == 2;
            }
        }
    }

    // Ensure that target location is not a wall and within map limits
    public bool IsWalkable(int x, int y)
    {
        if (y < 0 || y >= map.GetLength(0)) return false;
        if (x < 0 || x >= map.GetLength(1)) return false;

        return map[y, x] > 0;
    }

    public bool EatPelletAt(int x, int y, out bool isPowerPellet)
    {
        isPowerPellet = false;
        if (y < 0 || y >= pellets.GetLength(0)) return false;
        if (x < 0 || x >= pellets.GetLength(1)) return false;

        if (powerPellets[y, x])
        {
            powerPellets[y, x] = false;
            isPowerPellet = true;
        }

        if (!pellets[y, x]) return false;

        pellets[y, x] = false;
        return true;
    }
    public bool AnyPelletsLeft()
    {
        for (int y = 0; y < pellets.GetLength(0); y++)
            for (int x = 0; x < pellets.GetLength(1); x++)
                if (pellets[y, x] || powerPellets[y, x])
                    return true;

        return false;
    }

    public void Draw(int tileSize)
    {
        for (int rowNum = 0; rowNum < map.GetLength(0); rowNum++)
        {
            for (int colNum = 0; colNum < map.GetLength(1); colNum++)
            {
                //Draw wall or "path"
                Raylib.DrawRectangle(colNum * tileSize, rowNum * tileSize, tileSize, tileSize,
                    map[rowNum, colNum] > 0 ? Color.Black : Color.DarkBlue);

                // Draw pellets
                if (pellets[rowNum, colNum])
                    Raylib.DrawCircle(colNum * tileSize + tileSize / 2, rowNum * tileSize + tileSize / 2, tileSize * .1f, Color.White);
                if (powerPellets[rowNum, colNum])
                    Raylib.DrawCircle(colNum * tileSize + tileSize / 2, rowNum * tileSize + tileSize / 2, tileSize * .3f, Color.White);
            }
        }
    }
}