namespace DelegateDemo
{
    class UsingDelegates
    {
        //we can create delegate inside or outside the class but we can't create delegate inside the method
        public delegate void ArithmaticOperation(int x, int y);

        //we can't access this addsimple method bcoz its not having any parameter but our delegate is having 2 parameters so we can't access this method
        static void AddSimple()
        {
            Console.WriteLine(" ");
        }

        static void Add(int x, int y)
        {
            Console.WriteLine($"Addition: {x + y}");
        }

        static void Sub(int x, int y)
        {
            Console.WriteLine(x-y);
        }

        static void Mul(int x, int y)
        {
            Console.WriteLine(x*y);
        }

        static void Div(int x, int y)
        {
            Console.WriteLine(x / y);
        }

        static void Main(string[] args)
        {
            //-----------------Single cast delegate it iss --------------
            //ArithmaticOperation obj = new ArithmaticOperation(Add);
            //obj(45, 30);
            //ArithmaticOperation obj1 = new ArithmaticOperation(Sub);
            //obj1(45, 30);

            //-----------------Multi cast delegate it iss --------------
            ArithmaticOperation obj = new ArithmaticOperation(Add);
            obj += new ArithmaticOperation (Sub);
            //using -= operator we can remove the method from the invocation list of the delegate mtlb y stat execute nhi hogi
            //using += operator we can add the method in the invocation list of the delegate mtlb y stat execute hogi
            obj -= new ArithmaticOperation (Mul);
            obj += new ArithmaticOperation (Div);
            obj += new ArithmaticOperation (Mul);
            obj(45, 30);
            Console.ReadLine();
        }

    }
    
}