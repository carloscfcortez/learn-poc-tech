// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

DerivedClassTest derivedClass = new DerivedClassTest(1, 2);


Console.WriteLine($"someAandB: {derivedClass.someAandB()}");

Console.WriteLine($"subtractAandBNonAbstract: {derivedClass.subtractAandBNonAbstract()}");

TestDerivedSeeSeleadClass test2 = new TestDerivedSeeSeleadClass(2, 3);

test2.a = 1;


public class DerivedClassTest : TestAbstractClass
{
    public DerivedClassTest(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public override int someAandB()
    {
        return a + b;
    }

    public sealed override int subtractAandBNonAbstract()
    {
        return a - b;
    }

}

public class TestDerivedSeeSeleadClass : DerivedClassTest
{
    public new int a { get; set; }

    public TestDerivedSeeSeleadClass(int a, int b) : base(a, b)
    {

    }
}



public abstract class TestAbstractClass
{

    public int a { get; set; }

    public int b { get; set; }

    public abstract int someAandB();

    public virtual int subtractAandBNonAbstract()
    {
        return a - b;
    }
}

