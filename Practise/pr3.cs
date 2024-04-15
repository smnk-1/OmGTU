using System.Linq;

class TrapezoidalRule {
    public static double Solve(Func<double, double> f, double a, double b, double dx) {
        int n = (int)((b-a)/dx);
        return (f(a)/2 + Enumerable.Range(1, n-1).Select((i)=> f(a+(i*dx))).Sum() + f(b)/2)*dx;
    }
}

Func<double, double> f = (double x) => -x*x + 9;

var answ = TrapezoidalRule.Solve(f, -3, 3, 0.1);
answ
