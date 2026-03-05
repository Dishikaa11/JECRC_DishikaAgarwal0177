using System;
namespace AbstractDemo
{
    abstract class DrawingObject
    {
        public abstract void Draw();
    }
    class Line : DrawingObject
    {
        public override void Draw()
        {
            Console.WriteLine("I am a line");
        }
    }

    class Circle : DrawingObject
    {
        public override void Draw()
        {
            Console.WriteLine("i m a circle");
        }
    }

    class Square : DrawingObject
    {
        public override void Draw()
        {
            Console.WriteLine("i m a Square");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DrawingObject[] objects = new DrawingObject[3];
            objects[0] = new Line();
            objects[1] = new Circle();
            objects[2] = new Square();

            foreach(DrawingObject obj  in objects)
            {
                obj.Draw();
            }
            Console.ReadLine();

        }
    }

}