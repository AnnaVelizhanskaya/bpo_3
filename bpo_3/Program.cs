using System;
// Базовый абстрактный класс "Шахматная фигура"
public abstract class ChessPiece
{
    public string Name { get; set; }
    public string Color { get; set; }
    public ChessPiece(string name, string color)
    {
        Name = name;
        Color = color;
    }
    // Деструктор
    ~ChessPiece()
    {
        Console.WriteLine($"Фигура {Name} ({Color}) уничтожена");
    }
    public abstract void Move();
}
// Абстрактный класс "Легкая фигура" - наследник класса "Шахматная фигура"
public abstract class LightPiece : ChessPiece
{
    public LightPiece(string name, string color) : base(name, color)
    {
    }
    // Деструктор
    ~LightPiece()
    {
        Console.WriteLine($"Легкая фигура {Name} ({Color}) уничтожена");
    }
}
// Абстрактный класс "Тяжелая фигура" - наследник класса "Шахматная фигура"
public abstract class HeavyPiece : ChessPiece
{
    public HeavyPiece(string name, string color) : base(name, color)
    {
    }
    // Деструктор 
    ~HeavyPiece()
    {
        Console.WriteLine($"Тяжелая фигура {Name} ({Color}) уничтожена");
    }
}
// Класс "Пешка" - наследник класса "Легкая фигура"
public class Pawn : LightPiece
{
    public Pawn(string color) : base("Пешка", color)
    {
    }
    public override void Move()
    {
        Console.WriteLine("Пешка двигается вперед на одну клетку.");
    }
    // Деструктор 
    ~Pawn()
    {
        Console.WriteLine("Пешка уничтожена");
    }
}
// Класс "Король" - наследник класса "Тяжелая фигура"
public class King : HeavyPiece
{
    public King(string color) : base("Король", color)
    {
    }
    public override void Move()
    {
        Console.WriteLine("Король может двигаться на одну клетку в любом направлении.");
    }
    public void Castling()
    {
        Console.WriteLine("Возможность рокировки.");
    }
    // Деструктор
    ~King()
    {
        Console.WriteLine("Король уничтожен");
    }
}
// Класс "Слон" - наследник класса "Легкая фигура"
public class Bishop : LightPiece
{
    public Bishop(string color) : base("Слон", color)
    {
    }
    public override void Move()
    {
        Console.WriteLine("Слон двигается по диагонали.");
    }
    // Деструктор 
    ~Bishop()
    {
        Console.WriteLine("Слон уничтожен");
    }
}
// Класс "Ладья" - наследник класса "Тяжелая фигура"
public class Rook : HeavyPiece
{
    public Rook(string color) : base("Ладья", color)
    {
    }
    public override void Move()
    {
        Console.WriteLine("Ладья двигается по вертикали или горизонтали.");
    }
    // Деструктор 
    ~Rook()
    {
        Console.WriteLine("Ладья уничтожена");
    }
}
class Program
{
    static void Main(string[] args)
    {
        ChessPiece[] chessPieces = new ChessPiece[4];
        Console.WriteLine("Введите цвет пешки (белая или черная):");
        string pawnColor = Console.ReadLine();
        chessPieces[0] = new Pawn(pawnColor);
        Console.WriteLine("Введите цвет короля (белый или черный):");
        string kingColor = Console.ReadLine();
        chessPieces[1] = new King(kingColor);
        Console.WriteLine("Введите цвет слона (белый или черный):");
        string bishopColor = Console.ReadLine();
        chessPieces[2] = new Bishop(bishopColor);
        Console.WriteLine("Введите цвет ладьи (белая или черная):");
        string rookColor = Console.ReadLine();
        chessPieces[3] = new Rook(rookColor);
        foreach (ChessPiece piece in chessPieces)
        {
            Console.WriteLine($"Фигура: {piece.Name}");
            Console.WriteLine($"Цвет: {piece.Color}");
            piece.Move();
            if (piece is King kingPiece)
            {
                kingPiece.Castling();
            }
            Console.WriteLine();
        }
    }
}
